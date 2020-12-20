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
using System.Threading;

namespace dotNet5781_03B_8113_5037
{
    /// <summary>
    /// Interaction logic for databus.xaml
    /// </summary>
    public partial class databus : Window
    {
        Bus selsected;
        public databus(Bus a)
        {
            data = new TextBox();
            DataContext = a;
            //data.Text = a.ToString();
            selsected = new Bus();
            selsected = a;
            //data.Text = a.ToString();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selsected.Km = 0;
            DataContext = selsected;
            MessageBox.Show("refueled");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            selsected.Date_treatment = DateTime.Now;
            Thread treat = new Thread(ontreat);
            treat.Start();
        }

        private void ontreat()
        {
            MessageBox.Show("on treat");
            selsected.MyStatus = (Bus.Status)3;
            Thread.Sleep(144000);
            selsected.MyStatus = 0;
        }


    }
    
}
