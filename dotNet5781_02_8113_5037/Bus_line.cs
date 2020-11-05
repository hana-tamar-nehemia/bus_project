using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{
   class Bus_line:Bus_station
    {
        int line_number;
        //****************************************************
        string Area = "";
        //****************************************************

        private BusStation first_station;

        public BusStation Func_first_station
        {
            get { return first_station; }
            set { first_station = value; }
        }
      
        //****************************************************
        private BusStation last_station;

        public BusStation Func_last_station
        {
            get { return last_station; }
            set { last_station = value; }
        }
        //****************************************************

        private List<BusStation> Station;
        public List<BusStation> Push_Bus_Station
        {
            get { return Station; }
            set { Station = value; }
        }
        public void ToString()
        {
            Console.WriteLine($"Bus line: {this.line_number}\n Activity area: {this.Area}\n" +
                $"Route:\n" );
            Station.ForEach(Console.WriteLine($"{get.code}");)
            

           
        }
    }

    

}
