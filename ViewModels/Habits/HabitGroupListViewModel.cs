using HabbitFlow.Models;
using HabbitFlow.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Specialized; // Добавьте это

namespace HabbitFlow.ViewModels.Habits
{
    public class HabitGroupListViewModel : ViewModelBase

        
    {

  
        private readonly MainViewModel _mainVm;

        public ObservableCollection<HabitGroup> HabitGroups { get; }
        public bool IsEmpty => !HabitGroups.Any();

        public ICommand AddNewGroupCommand { get; }
        public ICommand AddCommand { get; }
        public HabitGroupListViewModel(MainViewModel mainVm)
        {
            _mainVm = mainVm;
            HabitGroups = mainVm.HabitGroups;

            // ⚠️ ЭТО САМОЕ ВАЖНОЕ - подписка на изменения коллекции
            HabitGroups.CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(IsEmpty));
            };

            AddNewGroupCommand = new RelayCommand(_ => _mainVm.NavigateToEditorGroup());
            AddCommand = new RelayCommand(_ => _mainVm.NavigateToEditorHabbit());
        }
    }
}