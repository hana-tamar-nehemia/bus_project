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
            areaComboBox.SelectedIndex = 0;
            //**********************************************
            //first_StationComboBox.DisplayMemberPath = "Code";//show only specific Property of object
            //first_StationComboBox.DisplayMemberPath = "Name";//show only specific Property of object
            first_StationComboBox.SelectedValuePath = "Code";//selection return only specific Property of object
            first_StationComboBox.SelectedIndex = 0; //index of the object to be selected
            first_StationComboBox.DataContext = bl.GetAllStation();
            //***********************************************
            //last_StationComboBox.DisplayMemberPath = "Code";//show only specific Property of object
            //  last_StationComboBox.DisplayMemberPath = "Name";//show only specific Property of object
            last_StationComboBox.SelectedValuePath = "Code";//selection return only specific Property of object
            last_StationComboBox.SelectedIndex = 0; //index of the object to be selected
            last_StationComboBox.DataContext = bl.GetAllStation();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //System.Windows.Data.CollectionViewSource busLineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busLineViewSource")));
           //  Load data by setting the CollectionViewSource.Source property:
           // busLineViewSource.Source = [generic data source]
        }

      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BusLine.Line_Number = Convert.ToInt32(line_NumberTextBox.Text);
            BusLine.License_num= _bl.GetFreeBus().License_num;
            BusLine.Act = true;
            BusLine.First_Station = (int)last_StationComboBox.SelectedItem;//לא עושים ככה צריך לקחת את המספר תחנה של מה שנבחר לא סתם ככה מה שנבחר
            BusLine.First_Station = (int)last_StationComboBox.SelectedItem;//גם כאן
            BusLine.Area = (BO.Areas)areaComboBox.SelectedIndex;
            _bl.AddBusLine(BusLine);
            MessageBox.Show("added");
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void TextBox_OnlyNumbers_PreviewKeyDown(object sender, KeyEventArgs e)
        {


            TextBox text = sender as TextBox;
            if (text == null) return;
            if (e == null) return;

            //allow get out of the text box
            if (e.Key == Key.Enter || e.Key == Key.Return || e.Key == Key.Tab)
                return;

            //allow list of system keys (add other key here if you want to allow)
            if (e.Key == Key.Escape || e.Key == Key.Back || e.Key == Key.Delete ||
                e.Key == Key.CapsLock || e.Key == Key.LeftShift || e.Key == Key.Home
             || e.Key == Key.End || e.Key == Key.Insert || e.Key == Key.Down || e.Key == Key.Right)
                return;

            char c = (char)KeyInterop.VirtualKeyFromKey(e.Key);

            //allow control system keys
            if (Char.IsControl(c)) return;

            //allow digits (without Shift or Alt)
            if (Char.IsDigit(c))
                if (!(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightAlt)))
                    return; //let this key be written inside the textbox

            //forbid letters and signs (#,$, %, ...)
            e.Handled = true; //ignore this key. mark event as handled, will not be routed to other controls
            return;
        }

        private void line_NumberTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            line_NumberTextBox.Text = "";
        }
    }

}
