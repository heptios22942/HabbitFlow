using HabbitFlow.Views;
using System.Windows;

namespace HabbitFlow.Services
{
    public interface INavigationService
    {
        void NavigateToMainWindow();
        void CloseLoginWindow();
    }

    public class NavigationService : INavigationService
    {
        public void NavigateToMainWindow()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        public void CloseLoginWindow()
        {
            Application.Current.MainWindow?.Close();
            Application.Current.MainWindow = null;
        }
    }
}