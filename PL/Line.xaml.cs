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
    /// Interaction logic for Line.xaml
    /// </summary>
    public partial class Line : Window
    {
        IBL bl = BLFactory.GetBL("1");

        public Line()
        {
            InitializeComponent();
            busLineListView.DataContext = bl.GetAllBusLine();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource busLineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busLineViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // busLineViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource lineStationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lineStationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // lineStationViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource adjStationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("adjStationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // adjStationViewSource.Source = [generic data source]
        }

        private void busLineListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnGO_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManagerOptions m = new ManagerOptions();
            m.ShowDialog();
        }
    }
}
