using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
