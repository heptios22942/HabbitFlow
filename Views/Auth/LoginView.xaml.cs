using HabbitFlow.ViewModels;
using System.Windows;
using System.Windows.Controls;
namespace HabbitFlow.Views.Auth
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>

    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();

            // Обработчик для PasswordBox
            PasswordBox.PasswordChanged += (s, e) =>
            {
                if (DataContext is LoginViewModel vm)
                {
                    // Простой способ передать пароль в ViewModel
                    // Временное решение - позже заменить на Behavior
                    vm.Password = PasswordBox.Password;
                }
            };
        }


    }
}
