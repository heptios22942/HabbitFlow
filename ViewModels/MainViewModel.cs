using HabbitFlow.Utilities;
using HabbitFlow.ViewModels.Analytics;
using HabbitFlow.ViewModels.Dashboard;
using HabbitFlow.ViewModels.Habits;
using System.Windows.Input;



namespace HabbitFlow.ViewModels
{
    public class MainViewModel : ViewModelBase  // ← ИЗМЕНИЛ НА ViewModelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();  // ← Убедитесь, что этот метод есть в ViewModelBase
            }
        }

        // Команды навигации
        public ICommand NavigateToDashboardCommand { get; }
        public ICommand NavigateToHabitGroupsCommand { get; }
        public ICommand NavigateToAnalyticsCommand { get; }

        public MainViewModel()
        {
            // Инициализация команд
            NavigateToDashboardCommand = new RelayCommand((param) => NavigateToDashboard());
            NavigateToHabitGroupsCommand = new RelayCommand((param) => NavigateToHabitGroups());
            NavigateToAnalyticsCommand = new RelayCommand((param) => NavigateToAnalytics());

            // Начальная навигация
            NavigateToDashboard();
        }

        private void NavigateToDashboard()
        {
            CurrentView = new DashboardViewModel();
        }

        private void NavigateToHabitGroups()
        {
            CurrentView = new HabitGroupListViewModel();
        }

        private void NavigateToAnalytics()
        {
            CurrentView = new AnalyticsDashboardViewModel();
        }
    }
}