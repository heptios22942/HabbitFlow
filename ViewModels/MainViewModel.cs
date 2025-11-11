using HabbitFlow.Utilities;
using HabbitFlow.ViewModels.Analytics;
using HabbitFlow.ViewModels.Dashboard;
using HabbitFlow.ViewModels.Habits;
using System.Windows.Input;
using HabbitFlow.ViewModels.Notification;
using HabbitFlow.ViewModels.Settings;
using HabbitFlow.ViewModels.User;


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
        public ICommand NavigateToUserCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }
        public ICommand NavigateToNotificationcommand { get; }

        public MainViewModel()
        {
            // Инициализация команд
            NavigateToDashboardCommand = new RelayCommand((param) => NavigateToDashboard());
            NavigateToHabitGroupsCommand = new RelayCommand((param) => NavigateToHabitGroups());
            NavigateToAnalyticsCommand = new RelayCommand((param) => NavigateToAnalytics());
            NavigateToUserCommand = new RelayCommand((param) => NavigateToUser());
            NavigateToSettingsCommand = new RelayCommand((param) => NavigateToSettings());
            NavigateToNotificationcommand = new RelayCommand((param) => NavigateToNotificationSettings());

            // Начальная навигация
            NavigateToDashboard();
        }
        private void NavigateToUser()
        {
            CurrentView = new UserVm();
        }
        private void NavigateToSettings()
        {
            CurrentView = new SettingsVM();
        }
        private void NavigateToNotificationSettings()
        {
            CurrentView = new NotificationSettingsVM();
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