using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class Buses
    {
        public int License_num { get; set; }
        public DateTime Start_data { get; set; }
        public double Km { get; set; }
        public double Fuel_tank { get; set; }
        public double Bus_status { get; set; }
        public override string ToString() => this.ToStringProperty();


    }
}
