using HabbitFlow.Views;
using HabbitFlow.Views.Auth;
using System;
using System.Windows;
using System.Windows.Input;
using HabbitFlow.ViewModels.Auth;
using HabbitFlow.Utilities;

namespace HabbitFlow.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        private string   _username;
        private string _password;
        private ICommand _loginCommand;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand => _loginCommand ??= new RelayCommand(
            execute: (_) => Login(),
            canexecute: (_) => CanLogin()
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