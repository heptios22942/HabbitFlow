using HabbitFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace HabbitFlow.Utilities
{
    public class NavigationService : INavigationService
    {
        private Window _currentWindow;
        private readonly Stack<Window> _navigationHistory = new Stack<Window>();

        public void NavigateTo<T>() where T : Window
        {
            NavigateTo<T>(null);
        }

        public void NavigateTo<T>(object parameter) where T : Window
        {
            // Создаем новое окно
            var newWindow = Activator.CreateInstance<T>();

            // Передаем параметр в ViewModel, если она поддерживает интерфейс
            if (parameter != null && newWindow.DataContext is IReceiveNavigationParameter parameterReceiver)
            {
                parameterReceiver.ReceiveParameter(parameter);
            }

            // Сохраняем текущее окно в истории
            if (_currentWindow != null)
            {
                _navigationHistory.Push(_currentWindow);
            }

            // Показываем новое окно и закрываем текущее
            newWindow.Show();
            _currentWindow?.Hide(); // Скрываем вместо закрытия для возможности GoBack
            _currentWindow = newWindow;
        }

        public void CloseCurrentWindow()
        {
            _currentWindow?.Close();
            _currentWindow = null;

            // Очищаем историю при закрытии
            _navigationHistory.Clear();
        }

        public void GoBack()
        {
            if (_navigationHistory.Count > 0)
            {
                var previousWindow = _navigationHistory.Pop();
                previousWindow.Show();
                _currentWindow?.Hide();
                _currentWindow = previousWindow;
            }
            else
            {
                // Если история пуста, закрываем приложение
                Application.Current.Shutdown();
            }
        }

        public void SetCurrentWindow(Window window)
        {
            _currentWindow = window;
        }
    }
}
