using HabbitFlow.Utilities;
using HabbitFlow.ViewModels;
using HabbitFlow.ViewModels.Auth;
using HabbitFlow.Views;
using HabbitFlow.Views.Auth;
using System.Windows;

namespace HabbitFlow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Создаем и показываем загрузочное окно
            LoadingWindow loadingWindow = new LoadingWindow();
            loadingWindow.Show();
            var navigationService = new NavigationService();
            var loginViewModel = new LoginViewModel(navigationService);
            // Используем Task.Run для фоновой работы
            Task.Run(() =>
            {
                // Имитация загрузки
                Thread.Sleep(3000);

                // Закрываем в UI потоке
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    LoginView login = new LoginView();
                    loadingWindow.Close();
                    login.Show();

                    navigationService.SetCurrentWindow(login);
                }));
            });

            base.OnStartup(e);
        }

    }
}



