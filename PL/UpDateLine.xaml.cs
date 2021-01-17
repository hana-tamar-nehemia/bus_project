using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UpDateLine.xaml
    /// </summary>
    public partial class UpDateLine : Window//צריך לקשר לכאן את האינם של האיזורים לקומבו בוס וגם לקשר את הרשימה של המסלול לתחנות בהם עובר הקו
    {
        IBL _bl;

        BO.Areas area=new BO.Areas();

        BO.BusLine busLineSelected;
        public UpDateLine(IBL lb,BO.BusLine busLine)
        {
            InitializeComponent();
            _bl = lb;
            busLineSelected = busLine;
            line_num.Text = Convert.ToString(busLine.Line_Number);
            area_combox.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            area_combox.SelectedIndex = (int)busLine.Area;
            list_of_station = new ListBox();
            list_of_station.DataContext = busLine.ListLineStations;
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

        private void update_click(object sender, RoutedEventArgs e)//שמירת כל העדכונים שעשה ורענון החלוןשל הקווים בהתאם אחרי שהשתנה קו מסויים
        {
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//עדכון מרחק או זמן של קו אוטובוס
        {
            BO.LineStation b = new BO.LineStation();
            b = ((sender as Button).DataContext as BO.LineStation);
            EditT_D edit = new EditT_D(_bl, b, _bl.GetPrevLineStation(b));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//מחיקת תחנת קו מקו אוטובוס
        {

            BO.LineStation b = new BO.LineStation();
            b = ((sender as Button).DataContext as BO.LineStation);
            _bl.DeleteLineStationInBus(b.Code,b.Line_Id);
            _bl.UpdateBusLinePhat(busLineSelected);
            list_of_station.DataContext = busLineSelected.ListLineStations;
        }

        private void area_combox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = (area_combox.SelectedIndex);

            busLineSelected.Area = (BO.Areas)i;
        }
    }
}
