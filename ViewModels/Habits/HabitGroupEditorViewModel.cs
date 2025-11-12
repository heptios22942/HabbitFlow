using HabbitFlow.Models;
using HabbitFlow.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HabbitFlow.ViewModels.Habits
{
    public class HabitGroupEditorViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainVm;

        private string _name = "";
        private string _icon = "📚";
        private string _memo = "Моя памятка...";
        private bool _enableMotivation = true;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public string Icon { get => _icon; set { _icon = value; OnPropertyChanged(); } }
        public string Memo { get => _memo; set { _memo = value; OnPropertyChanged(); } }
        public bool EnableMotivation { get => _enableMotivation; set { _enableMotivation = value; OnPropertyChanged(); } }

        // Коллекция доступных иконок
        public ObservableCollection<string> AvailableIcons { get; } = new()
        {
            "📚", "🏃", "🧘", "💪", "🏋️", "🚴", "🎯", "⭐", "🔥", "💡",
            "📖", "✏️", "🎨", "🎵", "🏠", "🍎", "💧", "😴", "🌞", "🌙",
            "❤️", "💰", "🚀", "🎪", "🏆", "📊", "🔔", "⏰", "✅", "📝",
            "🎮", "👨‍💻", "👩‍🍳", "🚶", "🧠", "💼", "🛌", "🚿", "🍽️", "☕"
        };

        public ICommand SaveCommand { get; }
        public ICommand GoBackCommand { get; }

        public HabitGroupEditorViewModel(MainViewModel mainVm)
        {
            _mainVm = mainVm;
            SaveCommand = new RelayCommand(_ => Save());
            GoBackCommand = new RelayCommand(_ => _mainVm.NavigateToHabitGroups());
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Name)) return;
            _mainVm.AddHabitGroup(Name, Icon, Memo, EnableMotivation);
            _mainVm.NavigateToHabitGroups();
        }
    }
}