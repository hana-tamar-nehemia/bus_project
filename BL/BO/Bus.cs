using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Bus
    {
        public int License_num { get; set; }
        public DateTime Start_date { get; set; }
        public double Km { get; set; }
        public double Fuel_tank { get; set; }
        public int Bus_status { get; set; }
        public override string ToString() => this.ToStringProperty();



    }
}
