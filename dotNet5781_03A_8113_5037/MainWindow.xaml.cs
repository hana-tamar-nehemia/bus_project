﻿using dotNet5781_02_8113_5037;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5781_03A_8113_5037
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 40 stations
        // 10 lines
        Bus_lines_collection lines = new Bus_lines_collection();
        //private Bus_line currentDisplayBusLine;

        public MainWindow()
        {
        }

        private void lbBusLineStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
        //    InitializeComponent();
        //    List<Bus_station> Stations = new List<Bus_station>();
        //    for (int h = 1; h <= 40; h++)//40 station
        //    {
        //        Bus_station add_station = new Bus_station();
        //        add_station.MyCode = h;
        //        Stations.Add(add_station);
        //    }

        //    //creat 10 lines
        //    int k = 0;
        //    int station_num = -1;
        //    for (int j = 1; j < 11; j++)
        //    {
        //        Bus_line line = new Bus_line();//bus
        //        while (k != 4)
        //        {
        //            station_num++;
        //            Bus_line_station station = new Bus_line_station();//bus stasion 
        //            station.My_station = Stations[station_num];//station fizi
        //            line.MyStations.Add(station);
        //            k++;
        //        }
        //        //the line will be 10, 20 ,30.....100
        //        line.My_line_number = j * 10;
        //        line.set_last_and_first();
        //        lines.bus_line_list.Add(line);
        //        k = 0;
        //    }

        //    cbBusLines.ItemsSource = lines;
        //    cbBusLines.DisplayMemberPath = "My_line_number";
        //    cbBusLines.SelectedIndex = 0;
        //    ShowBusLine(lines.bus_line_list[cbBusLines.SelectedIndex].My_line_number);


        //}
        //void ShowBusLine(int num_line)
        //{
        //    currentDisplayBusLine = lines[num_line];
        //    UpGrid.DataContext = currentDisplayBusLine;
        //    lbBusLineStations.DataContext = currentDisplayBusLine.MyStations;
        //    tbArea.Text = currentDisplayBusLine.area;
        //}

        //private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ShowBusLine((cbBusLines.SelectedValue as Bus_line).My_line_number); 
        //}

//        private void lbBusLineStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {

//        }

//        private void tbArea_TextChanged(object sender, TextChangedEventArgs e)
//        {

//        }
//   }
//}
