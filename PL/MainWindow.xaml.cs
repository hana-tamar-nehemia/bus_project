﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");

        public MainWindow()
        {
            InitializeComponent();
            BO.AdjStation a = new BO.AdjStation();
        }

        private void rbStudents_Checked(object sender, RoutedEventArgs e)
        {
            ManagerEnterCheck m = new ManagerEnterCheck(bl);
            m.ShowDialog();
        }
    }
}
