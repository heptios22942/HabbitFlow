using HabbitFlow.Models;
using HabbitFlow.Models.Enums;
using HabbitFlow.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

namespace HabbitFlow.ViewModels.Habits
{
    public class HabitEditorViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainVM;

        private string _name = "";
        private string _plan = "Мой план действия...";
        private HabitType _selectedHabitType = HabitType.Good;
        private TimeSpan _reminderTime = new TimeSpan(9, 0, 0);
        private int? _durationMinutes = null;
        private bool _isSpecialCancelable = false;
        private HabitGroup _selectedGroup;
        private string _selectedIcon = "⭐";

        public ICommand CancelCommand { get; }
        public ICommand SaveCommand { get; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(HabitsCount));
            }
        }

        public string Plan
        {
            get => _plan;
            set
            {
                _plan = value;
                OnPropertyChanged(nameof(Plan));
            }
        }

        public HabitType SelectedHabitType
        {
            get => _selectedHabitType;
            set
            {
                _selectedHabitType = value;
                OnPropertyChanged(nameof(SelectedHabitType));
            }
        }

        public TimeSpan ReminderTime
        {
            get => _reminderTime;
            set
            {
                _reminderTime = value;
                OnPropertyChanged(nameof(ReminderTime));
                OnPropertyChanged(nameof(ReminderTimeString));
            }
        }

        public int? DurationMinutes
        {
            get => _durationMinutes;
            set
            {
                _durationMinutes = value;
                OnPropertyChanged(nameof(DurationMinutes));
                OnPropertyChanged(nameof(DurationString));
            }
        }

        public bool IsSpecialCancelable
        {
            get => _isSpecialCancelable;
            set
            {
                _isSpecialCancelable = value;
                OnPropertyChanged(nameof(IsSpecialCancelable));
            }
        }

        public HabitGroup SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
                OnPropertyChanged(nameof(HabitsCount));
            }
        }

        public string SelectedIcon
        {
            get => _selectedIcon;
            set
            {
                _selectedIcon = value;
                OnPropertyChanged(nameof(SelectedIcon));
            }
        }

        // Счетчик привычек в выбранной группе - ИСПРАВЛЕННЫЙ
        public string HabitsCount
        {
            get
            {
                if (SelectedGroup == null) return "0";
                // Считаем привычки из MainViewModel, которые принадлежат этой группе
                var count = _mainVM.Habits.Count(h => h.GroupId == SelectedGroup.Id);
                return count.ToString();
            }
        }

        public ObservableCollection<HabitGroup> AvailableGroups { get; }

        // Коллекция иконок для привычек
        public ObservableCollection<string> AvailableIcons { get; } = new()
        {
            "⭐", "❤️", "🏃", "🧘", "💪", "📚", "🎯", "🔥", "💡", "📖",
            "✏️", "🎨", "🎵", "🏠", "🍎", "💧", "😴", "🌞", "🌙", "💰",
            "🚀", "🏆", "📊", "🔔", "⏰", "✅", "📝", "🎮", "👨‍💻", "👩‍🍳"
        };

        public ObservableCollection<HabitType> HabitTypes { get; } = new()
        {
            HabitType.Good,
            HabitType.Bad
        };

        public ObservableCollection<string> TimeOptions { get; } = new()
        {
            "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00",
            "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00",
            "20:00", "21:00", "22:00"
        };

        public ObservableCollection<int?> DurationOptions { get; } = new()
        {
            null, 5, 10, 15, 20, 25, 30, 45, 60, 90, 120
        };

        public HabitEditorViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
            AvailableGroups = mainVM.HabitGroups;

            CancelCommand = new RelayCommand(_ => mainVM.NavigateToHabitGroups());
            SaveCommand = new RelayCommand(_ => SaveHabit(), _ => CanSaveHabit());

            if (AvailableGroups.Count > 0)
                SelectedGroup = AvailableGroups[0];
        }

        private void SaveHabit()
        {
            if (!CanSaveHabit()) return;

            var habit = new Habit
            {
                Name = Name.Trim(),
                Plan = Plan.Trim(),
                Type = SelectedHabitType,
                ReminderTime = ReminderTime,
                DurationMinutes = DurationMinutes,
                IsSpecialCancelable = IsSpecialCancelable,
                GroupId = SelectedGroup?.Id ?? 0
            };

            _mainVM.AddHabit(habit);

            // Обновляем счетчик после добавления привычки
            OnPropertyChanged(nameof(HabitsCount));

            _mainVM.NavigateToHabitGroups();
        }

        private bool CanSaveHabit()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   Name.Trim().Length >= 2 &&
                   SelectedGroup != null;
        }

        public string ReminderTimeString
        {
            get => ReminderTime.ToString(@"hh\:mm");
            set
            {
                if (TimeSpan.TryParse(value, out var time))
                {
                    ReminderTime = time;
                    OnPropertyChanged(nameof(ReminderTimeString));
                }
            }
        }

        public string DurationString
        {
            get => DurationMinutes?.ToString() ?? "Без ограничения";
            set
            {
                if (string.IsNullOrEmpty(value) || value == "Без ограничения")
                {
                    DurationMinutes = null;
                }
                else if (int.TryParse(value, out var minutes))
                {
                    DurationMinutes = minutes;
                }
                OnPropertyChanged(nameof(DurationString));
            }
        }
    }
}