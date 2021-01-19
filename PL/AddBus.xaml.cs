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
    /// Interaction logic for AddBus.xaml
    /// </summary>
    public partial class AddBus : Window
    {
        IBL bl;
        BO.Bus Bus = new BO.Bus();
        public AddBus(IBL _bl)

        {
            bl = _bl;
            Addbus = new Grid();
            bus_statusComboBox = new ComboBox();
            bus_statusComboBox.ItemsSource = Enum.GetValues(typeof(BO.Bus_status));
            Addbus.DataContext = Bus;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource busViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // busViewSource.Source = [generic data source]
        }

        private void btnGO_Click(object sender, RoutedEventArgs e)
        {
            Bus = (BO.Bus)Addbus.DataContext;
            bool a = true;
            bl.AddBus(Bus.License_num, Bus.Start_date, Bus.Km, Bus.Fuel_tank, Bus.Bus_status, a);
            this.Close();
        }
    }
}
