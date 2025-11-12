using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using HabbitFlow.ViewModels.Habits;
namespace HabbitFlow.Views.Habbit
{
    /// <summary>
    /// Логика взаимодействия для HabbitsGroupEditorView.xaml
    /// </summary>
    public partial class HabbitsGroupEditorView : UserControl
    {
        public HabbitsGroupEditorView()
        {
            InitializeComponent();
            
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Открываем ссылку во внешнем браузере
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true // обязательно для внешних ссылок
            });
            e.Handled = true;
        }
    }
}
