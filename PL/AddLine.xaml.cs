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
        IBL _bl;

        BO.BusLine BusLine = new BO.BusLine();
        public AddLine(IBL bl)
        {
            _bl = bl;
            InitializeComponent();
            //grid1_add_line.DataContext = BusLine;
            ComboBox areaComboBox = new ComboBox();
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            ComboBox first_StationComboBox = new ComboBox();
            first_StationComboBox.ItemsSource = bl.GetAllStation();
            first_StationComboBox.DisplayMemberPath = "Code"+ "Name";
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
