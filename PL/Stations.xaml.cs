using BLAPI;
using BO;
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
    /// Interaction logic for Stations.xaml
    /// </summary>
    public partial class Stations : Window
    {
        IBL _lb;
        Station station = new Station();
        public Stations(IBL lb)
        {
            _lb = lb;
            InitializeComponent();
            ListStation.DataContext = _lb.GetAllStation();
            ListStation.SelectedIndex = 0;
            station = (Station)ListStation.SelectedItem;
            linspast.ItemsSource = _lb.GetAllBusLimeByStation(station.Code).ToList();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource stationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("stationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // stationViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource busLineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busLineViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // busLineViewSource.Source = [generic data source]
        }
        private void ListStation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            station = (Station)ListStation.SelectedItem;
            if(station==null)
            {
                station= _lb.GetAllStation().First();
            }
            DetailsStation.IsEnabled = true;
            addressTextBox.Text = station.Address;
            latitudeTextBox.Text = Convert.ToString(station.Latitude);
            longitudeTextBox.Text = Convert.ToString(station.longitude);
            //Lstlinenumber.IsEnabled = true;
             //List<string> ls = _lb.GetAllBusLimeByStation(station.Code).ToList();
            linspast.IsEnabled = true;
            linspast.ItemsSource= _lb.GetAllBusLimeByStation(station.Code).ToList();//פונקציה שמחזירה את כל הקווים של שעוברים בתחנה
            //Listlinenumber.ItemsSource =_lb.GetAllBusLimeByStation(station.Code).ToList();//פונקציה שמחזירה את כל הקווים של שעוברים בתחנה

        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManagerOptions m = new ManagerOptions(_lb);
            m.ShowDialog();
        }
        private void remove_Click(object sender, RoutedEventArgs e)
        {

            station = (Station)ListStation.SelectedItem;
            MessageBoxResult res = MessageBox.Show(" ? למחוק את התחנה  ", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No)
                return;
            try
            {
                if (station != null )
                {
                    bool flag;
                    flag  =  _lb.DeleteStation(station.Code);
                    if (flag == true)
                    {
                        DetailsStation.IsEnabled = false;
                        ListStation.DataContext = _lb.GetAllStation();
                        linspast.IsEnabled = false;
                        remove.IsEnabled = false;
                        refreshScreen();
                    }
                    else
                        MessageBox.Show(" Unable to delete station ");
                }
            }
            catch (BO.BadBusLineException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddStation m = new AddStation(_lb);
            m.ShowDialog();
            ListStation.DataContext = _lb.GetAllStation();

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
           
            BO.Station st = ListStation.SelectedItem as BO.Station;
            UpDateStstion update = new UpDateStstion(_lb, st); 
            update.ShowDialog();
            refreshScreen();



        }
        private void refreshScreen()
        {
            ListStation.DataContext = _lb.GetAllStation();
            ListStation.SelectedIndex = 0;
            station = (Station)ListStation.SelectedItem;
        }


    }
}
