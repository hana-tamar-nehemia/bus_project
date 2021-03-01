using BLAPI;
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
    /// Interaction logic for ManagerEnterCheck.xaml
    /// </summary>
    public partial class ManagerEnterCheck : Window
    {
        IBL _bl;
        public ManagerEnterCheck(IBL bl)
        {
            _bl = bl;
            InitializeComponent();
        }

         

        private void log_Click(object sender, RoutedEventArgs e)
        {
            string name = namel.Text;
            string password = passwordl.Text;
            bool flag;
              
                 flag = _bl.UserExistsM(name, password);
            
            if (flag == true)
            {
                this.Close();
                ManagerOptions m = new ManagerOptions(_bl);
                m.ShowDialog();
            }
            else
            {
                MessageBox.Show(" שם המשתמש או הסיסמא אינם נכונים ");
            }
        }
        private void sing_Click(object sender, RoutedEventArgs e)
        {
           string name = namel.Text;
           string password = passwordl.Text;
            _bl.AddUserM(name, password);
           this.Close();
           ManagerOptions m = new ManagerOptions(_bl);
           m.ShowDialog();
            
        }

    }
}
