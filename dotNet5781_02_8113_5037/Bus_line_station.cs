using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{
    class Bus_line_station:Bus_Station
    {
        private float km_from_last_station;
        public float func_km_from_last_station
        {
            get { return km_from_last_station; }
            set { km_from_last_station = value; }
        }

        private TimeSpan time_from_last_station;
        public TimeSpan func_time_from_last_station
        {
            get { return time_from_last_station; }
            set { time_from_last_station = value; }
        }
        public string _code()
        {
            return base.MyCode;
        }
    }
        
}
