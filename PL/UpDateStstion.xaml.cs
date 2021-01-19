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
    /// Interaction logic for UpDateStstion.xaml
    /// </summary>
    public partial class UpDateStstion : Window
    {
        IBL _bl;
        public UpDateStstion(IBL bl , BO.Station station)
        {
            InitializeComponent();
            _bl = bl;
            grid1.DataContext = station;
            grid2.DataContext= station;
            grid3.DataContext = station;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource stationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("stationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // stationViewSource.Source = [generic data source]
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Stations m = new Stations(_bl);
            m.ShowDialog();
        }
    }
}
