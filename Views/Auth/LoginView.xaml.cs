using HabbitFlow.Utilities;
using HabbitFlow.ViewModels.Auth;
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
            var nav = new NavigationService();
            nav.SetCurrentWindow(this);
            DataContext = new LoginViewModel(nav);

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
