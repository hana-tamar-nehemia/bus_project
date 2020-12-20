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
using static dotNet5781_03B_8113_5037.MainWindow;
using System.Threading;

namespace dotNet5781_03B_8113_5037
{
    /// <summary>
    /// Interaction logic for travel.xaml
    /// </summary>
    public partial class travel : Window
    {
        Bus selected;
        public travel(Bus togo)
        {
            selected = new Bus();
            selected = togo;
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                int a = int.Parse(k_m.Text);
            if (a + selected.Km < 1200)
            {
                selected.Km += a;
                int i = a / 80;
                Thread s = new Thread(onroad);
                s.Start(i);
            }
            else
                MessageBox.Show("the bus needs refueling");
            this.Close();
        }

        private void onroad(object i)
        {
            MessageBox.Show("on drive");
            selected.MyStatus = (Bus.Status)2;
            Thread.Sleep((int)i*6000);
            selected.MyStatus = 0;
        }

        private void k_m_TextChanged(object sender, TextChangedEventArgs e)
        {

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

        
    }
}
