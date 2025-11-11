using HabbitFlow.Utilities;
using HabbitFlow.Views;
using HabbitFlow.Views.Auth;
using System.Windows;
using System.Windows.Input;
using INavigationService = HabbitFlow.Utilities.INavigationService;
// Добавьте это в самый верх файла, перед всеми using
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;
namespace HabbitFlow.ViewModels.Auth
{
    public partial class LoginViewModel : ViewModelBase
    {
        public string Name { get; set; } = string.Empty;

        private readonly INavigationService _navigationService;

        public RelayCommand NavigateToRegCommand { get; }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Name = string.Empty;

            NavigateToRegCommand = new RelayCommand(
                execute: () => _navigationService.NavigateTo<RegistrationView>(),
                canExecute: () => true
            );
        }













        private string _username;
        private string _password;
        private ICommand _loginCommand;
        public RelayCommand NavigateToRegV;




        public string Username
        {
            get => _username;
            set
            {
                if (SetProperty(ref _username, value))
                {
                    // Обновляем состояние команды при изменении имени пользователя
                    (_loginCommand as RelayCommand)?.NotifyCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (SetProperty(ref _password, value))
                {
                    // Обновляем состояние команды при изменении пароля
                    (_loginCommand as RelayCommand)?.NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand LoginCommand => _loginCommand ??= new RelayCommand(
            execute: () => Login(),
            canExecute: () => CanLogin()
        );







        private void Login()
        {
            Console.WriteLine($"Logging in with: {Username}");

            if (IsValidLogin(Username, Password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                CloseLoginWindow();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private bool IsValidLogin(string username, string password)
        {
            return username == "admin" && password == "password";
        }

        private void CloseLoginWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is LoginView)
                {
                    window.Close();
                    break;
                }
            }
        }
    }
}