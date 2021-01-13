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
        IBL bl = BLFactory.GetBL("1");

        public AddLine()
        {
            InitializeComponent();
            ComboBox areaComboBox = new ComboBox();
            ComboBox first_StationComboBox = new ComboBox();
            first_StationComboBox.ItemsSource = bl.GetAllStation();
            ComboBox last_StationComboBox = new ComboBox();
            last_StationComboBox.ItemsSource = bl.GetAllStation();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource busLineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busLineViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // busLineViewSource.Source = [generic data source]
        }
    }
}
