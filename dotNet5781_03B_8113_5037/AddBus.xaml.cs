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
using static dotNet5781_03B_8113_5037.MainWindow;

namespace dotNet5781_03B_8113_5037
{
    /// <summary>
    /// Interaction logic for AddBus.xaml
    /// </summary>
    public partial class AddBus : Window
    {
        Bus newbus;
        public AddBus(ObservableCollection<Bus> buses)
        {
            newbus = new Bus();
            InitializeComponent();
            buses.Add(newbus);
        }


        //private void busListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (newbus.lincegood(licens_plateTextBox.Text)==true)
                newbus.Licens_plate = licens_plateTextBox.Text;
            else
            {
                MessageBox.Show("worong licens plate\n enter again");
                return;
            }
            string s = kmtreatTextBox.Text;
            int a = int.Parse(s);

            if (newbus.kmgood(kmtreatTextBox.Text))
                newbus.Km = int.Parse(kmtreatTextBox.Text);

            newbus.Date = (DateTime)dateDatePicker.SelectedDate;
            newbus.Date_treatment = (DateTime)date_treatmentDatePicker.SelectedDate;

            if (newbus.kmtreatgood(kmtreatTextBox.Text))
                newbus.Km_between_treatment = int.Parse(kmtreatTextBox.Text); ;

            if (int.Parse(kmtreatTextBox.Text) < 20000)
                newbus.MyStatus = (Bus.Status)0;
            else
                newbus.MyStatus = (Bus.Status)3;
            this.Close();
        }
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{

        //    System.Windows.Data.CollectionViewSource busViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busViewSource")));
        //    // Load data by setting the CollectionViewSource.Source property:
        //    // busViewSource.Source = [generic data source]
        //    _ = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busViewSource")));
        //    // Load data by setting the CollectionViewSource.Source property:
        //    // busViewSource.Source = [generic data source]
        //    _ = (System.Windows.Data.CollectionViewSource)(this.FindResource("busViewSource"));
        //    // Load data by setting the CollectionViewSource.Source property:
        //    // busViewSource.Source = [generic data source]
        //}

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

    }

}
