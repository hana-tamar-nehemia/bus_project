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
            BO.BusLine busLineBO = new BO.BusLine();
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            BO.Areas a = busLineBO.Area;
            areaComboBox.SelectedIndex = (int)a;
            //**********************************************
            first_StationComboBox.DisplayMemberPath = "Code";//show only specific Property of object
            first_StationComboBox.DisplayMemberPath = "Name";//show only specific Property of object
            first_StationComboBox.SelectedValuePath = "Code";//selection return only specific Property of object
            first_StationComboBox.SelectedIndex = 0; //index of the object to be selected
            first_StationComboBox.DataContext = bl.GetAllStation();
            //***********************************************
            last_StationComboBox.DisplayMemberPath = "Code";//show only specific Property of object
            last_StationComboBox.DisplayMemberPath = "Name";//show only specific Property of object
            last_StationComboBox.SelectedValuePath = "Code";//selection return only specific Property of object
            last_StationComboBox.SelectedItem = 0; //index of the object to be selected
            last_StationComboBox.DataContext = bl.GetAllStation();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            // System.Windows.Data.CollectionViewSource busLineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busLineViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // busLineViewSource.Source = [generic data source]
        }
        //public int GetAllBusId()פונקציה שתחזיר מספר רישוי של אוטובוס פנוי
        //{
        //}

                 
             
             
         

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //BusLine.License_num = _bl.GetAllBusId();צריך ליצור פונקציה כזו
            BusLine.Line_Number = Convert.ToInt32(line_NumberTextBox.Text);
            BusLine.Act = true;
            //BusLine.Line_Id = LineID++;     לבדוק איך הסטטיק עובד
            BusLine.First_Station = (int)last_StationComboBox.SelectedItem;
            BusLine.First_Station = (int)last_StationComboBox.SelectedItem;
            BusLine.Area = (BO.Areas)areaComboBox.SelectedIndex;
            _bl.AddBusLine(BusLine);
            MessageBox.Show("added");
            this.Close();

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
