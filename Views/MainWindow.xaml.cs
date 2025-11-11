using HabbitFlow.ViewModels;
using System.Windows;
namespace HabbitFlow.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}
