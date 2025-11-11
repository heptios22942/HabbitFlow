using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HabbitFlow.Views.USERCONTROL
{
    /// <summary>
    /// Логика взаимодействия для TopBar.xaml
    /// </summary>
    public partial class TopBar : UserControl
    {
        public TopBar()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += TopBar_MouseLeftButtonDown;
        }

        private void TopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Находим родительское окно и начинаем перетаскивание
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.DragMove();
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Window.GetWindow(this).WindowState = WindowState.Minimized;


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window != null)
            {
                if (window.WindowState == WindowState.Minimized)
                {
                    window.WindowState = WindowState.Normal;
                    window.Focus(); // Чтобы окно получило фокус
                }
                else if (window.WindowState == WindowState.Normal)
                {
                    window.WindowState = WindowState.Maximized;
                }
                else if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal; // Возвращаем в нормальное состояние
                }
            }
        }



    }
}
