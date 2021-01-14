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
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for ManagerEnterCheck.xaml
    /// </summary>
    public partial class ManagerEnterCheck : Window
    {
        public ManagerEnterCheck()
        {
            InitializeComponent();
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            ManagerOptions m = new ManagerOptions();
            m.ShowDialog();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
