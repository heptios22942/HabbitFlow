using HabbitFlow.Models;
using HabbitFlow.Utilities;
using HabbitFlow.ViewModels.Analytics;
using HabbitFlow.ViewModels.Dashboard;
using HabbitFlow.ViewModels.Habits;
using HabbitFlow.ViewModels.Notification;
using HabbitFlow.ViewModels.Settings;
using HabbitFlow.ViewModels.User;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace HabbitFlow.ViewModels
{
    public class MainViewModel : ViewModelBase  // ← ИЗМЕНИЛ НА ViewModelBase
    {
        private object _currentView;
        public string CurrentUserName { get; set; } = "Пользователь";
        public DateTime CurrentTime => DateTime.Now;
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


        public ICommand NavigateToEditorGroupCommand { get; }
        public ICommand NavigateToEditorHabbitCommand { get; }

        public ICommand NavigateToListGroupCommand { get; }
        public ICommand NavigateToListHabbitCommand { get; }
        public MainViewModel()
        {
            // Инициализация команд
            NavigateToDashboardCommand = new RelayCommand((param) => NavigateToDashboard());
            NavigateToHabitGroupsCommand = new RelayCommand((param) => NavigateToHabitGroups());
            NavigateToAnalyticsCommand = new RelayCommand((param) => NavigateToAnalytics());
            NavigateToUserCommand = new RelayCommand((param) => NavigateToUser());
            NavigateToSettingsCommand = new RelayCommand((param) => NavigateToSettings());
            NavigateToNotificationcommand = new RelayCommand((param) => NavigateToNotificationSettings());


            NavigateToEditorGroupCommand =  new RelayCommand((param) => NavigateToEditorGroup());
            NavigateToEditorHabbitCommand =  new RelayCommand((param) => NavigateToEditorHabbit());

     
            NavigateToListHabbitCommand =  new RelayCommand((param) => NavigateToListHabbit());
            // Начальная навигация
            NavigateToDashboard();
        }
        /// <summary>
        /// это редактирование привычек и группы
        /// </summary>
        public void NavigateToEditorHabbit()
        {
            CurrentView = new HabitEditorViewModel(this);
        }


        public void NavigateToEditorGroup()
        {
            CurrentView = new HabitGroupEditorViewModel(this);
        }

        /// <summary>
         ///просмотр привычек
        /// </summary>
        /// 
       public void NavigateToListHabbit()
        {
            CurrentView = new HabitListViewModel();
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
        /// это просмотр группы
        public void NavigateToHabitGroups()
        {
            CurrentView = new HabitGroupListViewModel(this);
            OnPropertyChanged(nameof(CurrentView)); // Убедитесь, что уведомление отправляется
        }

        private void NavigateToAnalytics()
        {
            CurrentView = new AnalyticsDashboardViewModel();
        }

        
        public ObservableCollection<HabitGroup> HabitGroups { get; } = new();
        public ObservableCollection<Habit> Habits { get; } = new();
        public ObservableCollection<HabitExecution> Executions { get; } = new();

        // Метод для добавления новой группы
        public void AddHabitGroup(string name, string icon, string memo, bool enableMotivation)
        {
            var group = new HabitGroup
            {
                Name = name,
                Icon = icon,
                Memo = memo,
                EnableMotivation = enableMotivation,
                CreatedAt = DateTime.Now
            };

            group.Id = HabitGroups.Count > 0 ? HabitGroups.Max(g => g.Id) + 1 : 1;
            HabitGroups.Add(group);
        }

        public void AddHabit(Habit habit)
        {
            if (habit == null) return;
            habit.Id = Habits.Count > 0 ? Habits.Max(h => h.Id) + 1 : 1;
            Habits.Add(habit);
        }

        public void AddExecution(HabitExecution execution)
        {
            if (execution == null) return;
            execution.Id = Executions.Count > 0 ? Executions.Max(e => e.Id) + 1 : 1;
            Executions.Add(execution);
        }


        public HabitGroup? GetGroupById(int groupId) =>
    HabitGroups.FirstOrDefault(g => g.Id == groupId);

        public Habit? GetHabitById(int habitId) =>
            Habits.FirstOrDefault(h => h.Id == habitId);

        public List<Habit> GetHabitsByGroup(int groupId) =>
            Habits.Where(h => h.GroupId == groupId).ToList();

        public List<HabitExecution> GetExecutionsByHabit(int habitId) =>
            Executions.Where(e => e.HabitId == habitId).ToList();

        public List<HabitExecution> GetExecutionsByDate(DateTime date) =>
            Executions.Where(e => e.ExecutionDate.Date == date.Date).ToList();






    }
}