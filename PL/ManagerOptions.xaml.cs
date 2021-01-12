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
    /// Interaction logic for ManagerOptions.xaml
    /// </summary>
    public partial class ManagerOptions : Window
    {
        public ManagerOptions()
        {
            InitializeComponent();
        }

        private void btnGO_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbLines_Checked(object sender, RoutedEventArgs e)
        {
            this.Close();
            Line l = new Line();
            l.ShowDialog();
        }
    }
}
