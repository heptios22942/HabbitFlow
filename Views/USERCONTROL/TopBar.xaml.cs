using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
