using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{

    class Bus_line : Bus_line_station
    {
        int  line_number;
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

        private List<Bus_line_station> Station;
        public List<Bus_line_station> Push_Bus_Station
        {
            get { return Station; }
            set { Station = value; }
        }
        
        public new string ToString()
        {
            Console.WriteLine($"Bus line: {this.line_number}\n Activity area: {this.Area}\n");
            Console.WriteLine("Route:");
            Station.ForEach(Console.WriteLine($"{_code.code}\n"));
            return "end of route";
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

                if (Station[k]._code == num)
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
            for (int i = 0 ; i <= Station.Count(); i++)
            {
                if(Station[i].MyCode == num)
                {
                    return true;
                }
                return false;
            }
        }
        public int Find_index_station(BusStation a)
        {
            string num = a.MyCode;
            int i = 0;
            int size = Station.Count();
            while (i < size && this.Station[i]. != num)
            {
                i++;
            }
            if (this.Station[i].MyCode == num)
                return i;
            return -1;
        }
            


        
        public float km_between_2_station (BusStation a, BusStation b)
        {
            string staion1 = a.MyCode;
            string staion2 = b.MyCode;
            int i = this.Station.Count();
            float distance = 0;
            int index2 = this.Find_index_station(staion2);
            for (int index = this.Find_index_station(staion1); ++index <= index2;)
            {
                distance += Station[index].func_km_from_last_station;
            }
            return distance;
        }

        public Bus_line tat_road(Bus_line a, Bus_line b)
        {
            string staion1 = a.MyCode;
            string staion2 = b.MyCode;
            List<Bus_Station> new1;
            this.Station.Find_index_station();
            for (int index = this.;index <= index2;index++)
            {
               Station[index].func_km_from_last_station;
            }
        }
    }
}
       