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
    /// Interaction logic for Buses.xaml
    /// </summary>
    public partial class Buses : Window
    {
        IBL _bl;
        BO.Bus bus = new BO.Bus();
        public Buses(IBL bl)
        {
            InitializeComponent();
            _bl = bl;
            busListBox.ItemsSource =_bl.GetAllBuses().Where(p=> p.ActBus==true).ToList();
            busListBox.SelectedIndex = 0;
            dataBus.DataContext = busListBox.SelectedItem;
            bus = (BO.Bus)busListBox.SelectedItem;
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnGO_Click(object sender, RoutedEventArgs e)//הוספת אוטובוס
        {
            AddBus add = new AddBus(_bl);
            add.Show();
            busListBox.ItemsSource = _bl.GetAllBuses().Where(p => p.ActBus == true).ToList();
            busListBox.SelectedIndex = 0;
            dataBus.DataContext = busListBox.SelectedItem;
            bus = (BO.Bus)busListBox.SelectedItem;
            
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void busListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            dataBus.DataContext = busListBox.SelectedItem;
            bus = (BO.Bus)busListBox.SelectedItem;
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManagerOptions m = new ManagerOptions(_bl);
            m.ShowDialog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //למלא דלק לאוטובוס שנבחר
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpDateBus up = new UpDateBus(bus, _bl);
            up.ShowDialog();
            busListBox.ItemsSource = _bl.GetAllBuses().Where(p => p.ActBus == true).ToList();
            busListBox.SelectedIndex = 0;
            dataBus.DataContext = busListBox.SelectedItem;
            //bus = (BO.Bus)busListBox.SelectedItem;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
             
            MessageBoxResult res = MessageBox.Show("Delete selected bus line?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No)
                return;
            try
            {
                _bl.DeleteBus(bus.License_num);
                busListBox.ItemsSource = _bl.GetAllBuses().Where(p => p.ActBus == true).ToList();
                busListBox.SelectedIndex = 0;
                dataBus.DataContext = busListBox.SelectedItem;
                bus = (BO.Bus)busListBox.SelectedItem;
                refreshScreen();
            }
            catch (BO.BadBusLineException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        private void refreshScreen()
        {
            busListBox.ItemsSource = _bl.GetAllBuses().Where(p => p.ActBus == true).ToList();
            busListBox.SelectedIndex = 0;
            dataBus.DataContext = busListBox.SelectedItem;
            bus = (BO.Bus)busListBox.SelectedItem;
    }   }
}
