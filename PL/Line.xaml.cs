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
        IBL _bl;
        BO.BusLine busLine = new BO.BusLine();

        public Line(IBL lb)
        {
            InitializeComponent();
            _bl = lb;
            busLineListView.DataContext = _bl.GetAllBusLine();
            busLineListView.SelectedIndex = 0; //index of the object to be selected
            busLine = (BO.BusLine)busLineListView.SelectedItem;
            lineStationDataGrid.IsReadOnly = true;
            lineStationDataGrid.DataContext= busLine.ListLineStations; 
        }

        private void busLineListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            busLine = (BO.BusLine)busLineListView.SelectedItem;
            lineStationDataGrid = new DataGrid();
            lineStationDataGrid.DataContext = busLine.ListLineStations;
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{

        //    System.Windows.Data.CollectionViewSource busLineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busLineViewSource")));
        //    // Load data by setting the CollectionViewSource.Source property:
        //    // busLineViewSource.Source = [generic data source]
        //    System.Windows.Data.CollectionViewSource lineStationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lineStationViewSource")));
        //    // Load data by setting the CollectionViewSource.Source property:
        //    // lineStationViewSource.Source = [generic data source]
        //    //  System.Windows.Data.CollectionViewSource adjStationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("adjStationViewSource")));
        //    // Load data by setting the CollectionViewSource.Source property:
        //    // adjStationViewSource.Source = [generic data source]
        //   // System.Windows.Data.CollectionViewSource lineStationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lineStationViewSource")));
        //    // Load data by setting the CollectionViewSource.Source property:
        //    // lineStationViewSource.Source = [generic data source]
        //}



        private void btnGO_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManagerOptions m = new ManagerOptions(_bl);
            m.ShowDialog();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            UpDateLine update = new UpDateLine(_bl,(BO.BusLine)busLineListView.SelectedItem);//שולח את הקו שרוצים לעדכן
            update.ShowDialog();
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            BO.BusLine busLine = new BO.BusLine();
            busLine = (BO.BusLine)busLineListView.SelectedItem;
            MessageBoxResult res = MessageBox.Show("Delete selected bus line?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No)
                return;
            try
            {
                if (busLine != null)
                {
                    _bl.DeleteBusLine(busLine.License_num);
                    lineStationDataGrid.ItemsSource = null;
                    busLineListView.ItemsSource = _bl.GetAllBusLine();
                    btnGO.IsEnabled = false;
                   // remove.IsEnabled = false;
                }
            }
            catch (BO.BadBusLineException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
            
        private void add_line_Click(object sender, RoutedEventArgs e)
        {
           AddLine m = new AddLine(_bl);
            m.ShowDialog();
        }
    }
}
