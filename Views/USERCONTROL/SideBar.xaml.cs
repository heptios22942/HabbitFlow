using System.Windows;
using System.Windows.Controls;

namespace HabbitFlow.Views.USERCONTROL
{
    /// <summary>
    /// Логика взаимодействия для SideBar.xaml
    /// </summary>
    public partial class SideBar : UserControl
    {
        public SideBar()
        {
            InitializeComponent();
        }

        private void dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            dashboard.Focus();
        }

        
    }
}
