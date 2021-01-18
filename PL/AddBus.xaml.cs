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
    /// Interaction logic for AddBus.xaml
    /// </summary>
    public partial class AddBus : Window
    {
        BO.Bus Bus = new BO.Bus();
        public AddBus()
        {
            Addbus = new Grid();
            Addbus.DataContext = Bus;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource busViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // busViewSource.Source = [generic data source]
        }

        private void btnGO_Click(object sender, RoutedEventArgs e)
        {
            Bus = (BO.Bus)Addbus.DataContext;
            //לבדוק מה מגיע ואם מגיע משהו טוב
            //אז לעדכן את זה ברשימות של הדטה סורס
            this.Close();
        }
    }
}
