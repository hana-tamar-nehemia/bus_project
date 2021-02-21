using BLAPI;
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
    /// Interaction logic for AddStation.xaml
    /// </summary>
    public partial class AddStation : Window
    {
         IBL _bl;
        public AddStation(IBL bl)
        {
            _bl = bl;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource stationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("stationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // stationViewSource.Source = [generic data source]
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {


            int Code = int.Parse(codeTextBox.Text);
            Double Latitude = double.Parse(latitudeTextBox.Text);
            Double longitude = double.Parse(latitudeTextBox.Text);
            string Address = addressTextBox.Text;
            string Name = nameTextBox.Text;
            _bl.AddStation(Code, Name, Address, Latitude, longitude);
            MessageBox.Show("Added");
            this.Close();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
