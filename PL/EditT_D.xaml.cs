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
    /// Interaction logic for EditT_D.xaml
    /// </summary>
    public partial class EditT_D : Window
    {
        IBL _bl;
        BO.BusLine busline;
        BO.LineStation firststation;
        BO.LineStation selectedstation;
        BO.AdjStation adj = new BO.AdjStation();

        public EditT_D(IBL bl,BO.LineStation a, BO.LineStation b, BO.BusLine line)//משנים את b
        {
            _bl = bl;
            InitializeComponent();
            busline = line;
            firststation = a;
            selectedstation = b;
            code1.Text = (a.Code).ToString();
            code2.Text = (b.Code).ToString();
            name1.Text = (a.Name);
            name2.Text = (b.Name);
            adj = _bl.GetAdjStation(a.Code, b.Code);
            timeTextBox.Text = (adj.Time_Between).ToString();
            distanceTextBox.Text = (adj.Distance).ToString();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selectedstation.distance = Convert.ToInt32(distanceTextBox.Text);
            //selectedstation.time = (TimeSpan)timeTextBox.Text;
              _bl.UpDateLineStationD_T(selectedstation);
            adj.Distance = Convert.ToInt32(distanceTextBox.Text);
            //adj.Time_Between=(TimeSpan)timeTextBox.Text;
            _bl.UpDateLineStationD_T(selectedstation);
            _bl.UpdateAdjStation(adj);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource lineStationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lineStationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // lineStationViewSource.Source = [generic data source]
        }
    }
}
