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
        bool lincegood(int a)
        {
            if (a <= 100000000 && a > 9999999)
                return true;
            else
                return false;
        }
        public AddBus(IBL _bl)

        {
            bl = _bl;
            InitializeComponent();
            //Addbus.DataContext = Bus;
            bus_statusComboBox.ItemsSource = Enum.GetValues(typeof(BO.Bus_status));
            bus_statusComboBox.SelectedIndex = 0;
            


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource busViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // busViewSource.Source = [generic data source]
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnGO_Click(object sender, RoutedEventArgs e)
        {
             
            //Bus = (BO.Bus)Addbus.DataContext;
            Bus.Fuel_tank = int.Parse(fuel_tankTextBox.Text);
            Bus.ActBus = true;
            Bus.Bus_status = (BO.Bus_status)bus_statusComboBox.SelectedIndex;
            Bus.Km = int.Parse(kmTextBox.Text);
            Bus.License_num = int.Parse(license_numTextBox.Text);
            Bus.Start_date = start_dateDatePicker.DisplayDate;
            bool a = true;
            if (lincegood(Bus.License_num) == false)
            {
                MessageBox.Show("worong licens plate\n enter again");

            }
            else
            {
                try
                {

                    bl.AddBus(Bus.License_num, Bus.Start_date, Bus.Km, Bus.Fuel_tank, Bus.Bus_status, a);
                    MessageBox.Show("Added");
                    this.Close();
                }
                catch (BO.BadBusException ex)
                {
                    MessageBox.Show(ex.Message, "התחנה קימת", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
