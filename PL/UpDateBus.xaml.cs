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
    /// Interaction logic for UpDateBus.xaml
    /// </summary>
    public partial class UpDateBus : Window
    {
        BO.Bus Bus = new BO.Bus();
        public UpDateBus(BO.Bus bus, IBL bl)
        {
            InitializeComponent();
           // busdetail = new Grid();
            Bus = bus;
            bus_statusTextBox.ItemsSource = Enum.GetValues(typeof(BO.Bus_status));
            bus_statusTextBox.SelectedIndex = (int)bus.Bus_status;
            busdetail.DataContext = bus;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource busViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // busViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Bus = (BO.Bus)busdetail.DataContext;
            this.Close();
        }
    }
}
