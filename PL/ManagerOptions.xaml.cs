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
using BLAPI;
namespace PL
{
    /// <summary>
    /// Interaction logic for ManagerOptions.xaml
    /// </summary>
    public partial class ManagerOptions : Window
    {
        IBL _lb;

        public ManagerOptions(IBL lb)
        {
            _lb = lb;
            InitializeComponent();
        }

        private void btnGO_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbLines_Checked(object sender, RoutedEventArgs e)
        {
            this.Close();
            Line l = new Line(_lb);
            l.ShowDialog();
        }

        private void rbStudents_Checked(object sender, RoutedEventArgs e)
        {
            Buses buses = new Buses(_lb);
            buses.ShowDialog();
        }
    }
}
