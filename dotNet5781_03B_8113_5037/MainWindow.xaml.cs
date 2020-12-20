using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace dotNet5781_03B_8113_5037
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Bus> buses = new ObservableCollection<Bus>();
        public static Random r = new Random();


        public MainWindow()
        {
            string str;
            for (int b = 1111111; b < 1111121; b++)
            {
                int y = r.Next(5);
                str = b.ToString();
                Bus a = new Bus(DateTime.Now, str);
                buses.Add(a);
            }
            int i = 0;
            buses[i++].Km_between_treatment = 19999;
            buses[i++].Km = 1200;
            DateTime x = new DateTime(2010, 1, 3);
            buses[i].Date_treatment = x;
            buses[i].MyStatus = (Bus.Status)3;
            listofbus = new ListBox();
            DataContext = buses;

            InitializeComponent();

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(((Bus)listofbus.SelectedItem).ToString());
            //Bus a = sender as Bus;
            //MessageBox.Show(a.ToString());
            databus a = new databus((Bus)listofbus.SelectedItem);
            a.ShowDialog();
        }


        private void Button_Click(object sender, RoutedEventArgs e)//add
        {
            //כשילחצו יפתח החלון השני

            AddBus newbus = new AddBus(buses);
            newbus.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//תדלוק
        {
            Bus b = new Bus();
            b = ((sender as Button).DataContext as Bus);
            b.Km = 0;
            DataContext = b;
            MessageBox.Show("refueled");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Bus b = new Bus();
            b = ((sender as Button).DataContext as Bus);
            if (b.checkDate() == true)
            {
                travel a = new travel(b);
                a.ShowDialog();
            }
            else
                MessageBox.Show("refueled");
        }
    }
}

