using System.Windows;
using HabbitFlow.ViewModels.Auth;
using HabbitFlow.Utilities;
namespace HabbitFlow.Views.Auth
{
    /// <summary>
    /// Логика взаимодействия для RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : Window
    {
        public RegistrationView()
        {
            InitializeComponent();
            var nav = new NavigationService();
            nav.SetCurrentWindow(this);
          
            DataContext = new RegistrationViewModel(nav);
        }
    }
}
