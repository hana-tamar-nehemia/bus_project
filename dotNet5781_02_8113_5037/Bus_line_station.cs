using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{

   public class Bus_line_station : Bus_station
    {
        private float km_from_last_station;

        public float func_km_from_last_station
        {
            get { return km_from_last_station; }
            set
            {
                km_from_last_station = r.Next(7000);
            }
        }

     

        private TimeSpan time_from_last_station;
        public TimeSpan func_time_from_last_station
        {
            get { return time_from_last_station; }
            set {

                float time = km_from_last_station / 80; //in global minute
                int hour = (int)time / 60;//just hours
                int minute= (int)time % 60;//just minute
                time_from_last_station = TimeSpan.FromHours(hour);
                time_from_last_station = TimeSpan.FromMinutes(minute);
            }
        }
        public int _code()
        {
            return base.MyCode;
        }
        public override string ToString()
        {
            return "";
        }
    }
        
}
