using System.Windows;

namespace HabbitFlow.Utilities
{
    public interface INavigationService
    {
        void NavigateTo<T>() where T : Window;
        void NavigateTo<T>(object parameter) where T : Window;
        void CloseCurrentWindow();
        void GoBack();
        void SetCurrentWindow(Window window);
    }
}
