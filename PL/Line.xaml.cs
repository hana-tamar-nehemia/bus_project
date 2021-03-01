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
            busLineListBox.DataContext = _bl.GetAllBus();
            busLineListBox.SelectedIndex = 0; //index of the object to be selected
            busLine = (BO.BusLine)busLineListBox.SelectedItem;
        }

        private void busLineListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnGO.IsEnabled = true;
            remove.IsEnabled = true;
            busLine = (BO.BusLine)busLineListBox.SelectedItem;
            //linestationListBox = new ListBox();
            if (busLine == null)
            {
                busLine = _bl.GetAllBus().First();
            }
            linestationListBox.DataContext = _bl.GetAllLineStationsOfBusLine(busLine.Line_Id); //busLine.ListLineStations; 
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

        //private void refreshScreen()
        //{

        //    busLineListBox.DataContext = _bl.GetAllBus();
        //    busLineListBox.SelectedIndex = selectindex;
        //}

        private void btnGO_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManagerOptions m = new ManagerOptions(_bl);
            m.ShowDialog();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            UpDateLine update = new UpDateLine(_bl,(BO.BusLine)busLineListBox.SelectedItem);//שולח את הקו שרוצים לעדכן
            update.ShowDialog();
            linestationListBox.DataContext = _bl.GetAllLineStationsOfBusLine(busLine.Line_Id); //busLine.ListLineStations; 
            busLineListBox.DataContext = _bl.GetAllBus();
            busLineListBox.SelectedIndex = 0; //index of the object to be selected
            busLine = (BO.BusLine)busLineListBox.SelectedItem;
            linestationListBox.DataContext = _bl.GetAllLineStationsOfBusLine(busLine.Line_Id); //busLine.ListLineStations; 


        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult res = MessageBox.Show("Delete selected bus line?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No)
                return;
            try
            {
                if (busLine != null)
                {
                    _bl.DeleteBusLine(busLine.License_num);
                    busLineListBox.DataContext = _bl.GetAllBus();
                    btnGO.IsEnabled = false;
                    remove.IsEnabled = false;

                    busLineListBox.DataContext = _bl.GetAllBus();
                    busLineListBox.SelectedIndex = 0; //index of the object to be selected
                    busLine = (BO.BusLine)busLineListBox.SelectedItem;
                    linestationListBox.DataContext = _bl.GetAllLineStationsOfBusLine(busLine.Line_Id); //busLine.ListLineStations; 
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
            busLineListBox.DataContext = _bl.GetAllBus();
            busLineListBox.DataContext = _bl.GetAllBus();
            busLineListBox.SelectedIndex = 0; //index of the object to be selected
            busLine = (BO.BusLine)busLineListBox.SelectedItem;
            linestationListBox.DataContext = _bl.GetAllLineStationsOfBusLine(busLine.Line_Id); //busLine.ListLineStations; 

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource busLineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busLineViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // busLineViewSource.Source = [generic data source]
        }
    }
}
