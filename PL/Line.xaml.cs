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
        BO.BusLine busLine = new BO.BusLine();

        public Line()
        {
            InitializeComponent();
            busLineListView.DataContext = bl.GetAllBusLine();
            //BO.LineStation b= new BO.LineStation { Code = 111, Name = "lll", distance = 3, time = new TimeSpan(9, 0, 0), Line_Station_Index = 6 };
            //lineStationDataGrid.DataContext=b;

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


        private void busLineListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnGO.IsEnabled = true;
            btnGO1.IsEnabled = true;
            busLine = (BO.BusLine)busLineListView.SelectedItem;
            lineStationDataGrid = new DataGrid();
            lineStationDataGrid.DataContext = bl.GetAllLineStationsOfBusLine(busLine.Line_Id);
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            UpDateLine update = new UpDateLine((BO.BusLine)busLineListView.SelectedItem);
            update.ShowDialog();
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            BO.BusLine busLine = new BO.BusLine();
            busLine = (BO.BusLine)busLineListView.SelectedItem;
            bl.DeleteBusLine(busLine.License_num);
            busLineListView.ItemsSource = bl.GetAllBusLine();
            lineStationDataGrid.ItemsSource = null;
            btnGO.IsEnabled = false;
            btnGO1.IsEnabled = false;
        }

        private void add_line(object sender, RoutedEventArgs e)
        {

        }
    }
}
