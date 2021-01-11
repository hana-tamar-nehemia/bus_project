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

namespace PL
{
    /// <summary>
    /// Interaction logic for LineStation.xaml
    /// </summary>
    public partial class LineStation : Window
    {
        public LineStation()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource lineStationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lineStationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // lineStationViewSource.Source = [generic data source]
        }
    }
}
