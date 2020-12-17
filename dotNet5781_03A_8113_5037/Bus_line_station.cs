using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{

    public class Bus_line_station
    {
        private Bus_station station;

        public Bus_station My_station
        {
            get { return station; }
            set { station = value; }
        }


        private float km_from_last_station;

        public float Func_km_from_last_station
        {
            get { return km_from_last_station; }
            set
            {

            }
        }


        private TimeSpan time_from_last_station;
        public TimeSpan Func_time_from_last_station
        {
            get { return time_from_last_station; }
            set
            { }
        }
        static Random r = new Random();
        public Bus_line_station()
        {
            km_from_last_station = r.Next(1000);
            float time = km_from_last_station / 80; //in global minute acoording to 80 kamash
            int hour = (int)time / 60;//the hours
            int minute = (int)time - 60 * hour;//just minute
            int second = (int)((time - (60 * hour) - minute) * 10);//just second
            time_from_last_station = new TimeSpan(hour, minute, second);
        }

        public override string ToString()
        {
            string dorest_to_string = $" Bus Station Code: {My_station.MyCode}, {My_station.My_station_location[1]}°N  {My_station.My_station_location[0]}°E   {Func_time_from_last_station}" ;
            return dorest_to_string;

        }
    }
}
