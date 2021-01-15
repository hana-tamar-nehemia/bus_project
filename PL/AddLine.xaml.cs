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
    /// Interaction logic for AddLine.xaml
    /// </summary>
    public partial class AddLine : Window
    {
        IBL _bl;

        BO.BusLine BusLine = new BO.BusLine();
        public AddLine(IBL bl)
        {
            InitializeComponent();
            _bl = bl;
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            first_StationComboBox.DisplayMemberPath = "Code";
            first_StationComboBox.SelectedIndex = 0; //index of the object to be selected
            last_StationComboBox.DisplayMemberPath = "Code";
            last_StationComboBox.SelectedIndex = 0; //index of the object to be selected
            first_StationComboBox.DataContext = bl.GetAllStation();
            last_StationComboBox.DataContext = bl.GetAllStation();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           // System.Windows.Data.CollectionViewSource busLineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busLineViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // busLineViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //BusLine.License_num = _bl.GetFreeBus();צריך ליצור פונקציה כזו
            BusLine.Line_Number = Convert.ToInt32(line_NumberTextBox.Text);
            //_bl.AddBusLine(BusLine); צריך ליצור
            MessageBox.Show("added");

        }

        private void first_StationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusLine.First_Station = first_StationComboBox.SelectedIndex;
        }

        private void last_StationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusLine.Last_Station = first_StationComboBox.SelectedIndex;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
