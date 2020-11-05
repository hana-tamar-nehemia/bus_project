using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{

    class Bus_line : BusStation
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
            Console.WriteLine($"Bus line: {this.line_number}\n Activity area: {this.Area}\n");
            Console.WriteLine("Route:");
            Station.ForEach(Console.WriteLine($"{MyCode.code}\n"));
            Console.WriteLine("Route back:");
            Station.ForEach(Console.WriteLine($"{MyCode.code}\n"));

            for (int i = Station.Count(); i >= 0; i--)
            {
                Console.WriteLine($"{Station[i].MyCode.code}/n");
            }
        }
        public void Add_station(string num)
        {
            int i = Station.Count();
            for (int k = 0; k != i; k++)
            {
               
            }
            first_station = Station[1];
            last_station = Station[i+1];
        }
        public void remove_station(string num)
        {
            int index_remove;
            int i = Station.Count();
            for (int k = 0; k != i; k++)
            {

                if (Station.Mycode == num)
                {
                    Station.Remove(Station[k]);
                    index_remove = k;
                    k = i;
                }
            }
            first_station = Station[1];
            last_station = Station[i - 1];
        }
        public bool if_the_station_exsist_in_this_line(string num)
        {
            for (int i =0 ; i >= Station.Count(); i++)
            {
                if(Station[i].Mycode == num)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
       