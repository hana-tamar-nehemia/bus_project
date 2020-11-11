using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{

    class Bus_line: IComparable
    {
        int line_number;

        //****************************************************

        string Area = "";

        //*****************************************************

        private Bus_line_station first_station;

        public Bus_line_station Func_first_station
        {
            get { return first_station; }
            set { first_station = value; }
        }

        //****************************************************
        private Bus_line_station last_station;

        public Bus_line_station Func_last_station
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
        ////////////////////////////FUNCTION///////////////////////////////////////////////////////////
        int CompareTo(Bus_line bus2)
        {

            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            Console.WriteLine($"Bus line: {this.line_number}\n Activity area: {this.Area}\n");
            Console.WriteLine("Route:");
            int i = Station.Count();

            for (int k = 0; k <= i; k++)
            {
                Console.WriteLine($"{ Station[k]._code()}\n");
            }
            return "end of route";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="new_station"></param>
        public void Add_station(Bus_line_station new_station)
        {

            Console.WriteLine("after which station do you want to add the new station?");
            int after_this = int.Parse(Console.ReadLine());
            int index = this.find_index(after_this);//find the station to put after the new station
            if (index != -1)
            {
                Station.Insert(index, new_station);
                int i = Station.Count();
                first_station = Station[0];
                last_station = Station[i];
            }
            else
            {
                Console.WriteLine("there isnt such a ststion");
            }
        }
        public void remove_station(int num)
        {
            int i = Station.Count();
            int index = this.find_index(num);//find the station to put after the new station
            Station.Remove(Station[index]);

            first_station = Station[1];
            last_station = Station[i - 1];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int find_index(int num)
        {
            for (int i = 0; i <= Station.Count(); i++)
            {
                if (Station[i]._code() == num)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool bool_find(int num)
        {
            for (int i = 0; i <= Station.Count(); i++)
            {
                if (Station[i]._code() == num)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public float km_between_2_station (Bus_line_station a, Bus_line_station b)
        {
            int staion1 = a.MyCode;
            int staion2 = b.MyCode;
            int index2 = find_index( staion2);
            int i = this.Station.Count();
            float distance = 0;
            for (int index1 = find_index(staion1); ++index1 <= index2;)
            {
                distance += Station[index1].func_km_from_last_station;
            }
            return distance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public TimeSpan time_between_2_station(Bus_line_station a, Bus_line_station b)
        {
            int staion1 = a.MyCode;
            int staion2 = b.MyCode;
            int index2 = find_index(staion2);
            int i = this.Station.Count();
            TimeSpan time= new TimeSpan();
            for (int index1 = find_index(staion1); ++index1 <= index2;)
            {
                time.Add(Station[index1].func_time_from_last_station);
            }
            return time;
        }
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public Bus_line tat_road(Bus_line_station a, Bus_line_station b)
        {
            int staion1 = a.MyCode;
            int staion2 = b.MyCode;
            int index2 = find_index(staion2);
            Bus_line tat_line = new Bus_line();
            for (int index1 = find_index(staion1); index1 <= index2; index1++)
            {
                tat_line.Station.Add(this.Station[index1]);
            }
            int i = this.Station.Count();
            tat_line.line_number = this.line_number;
            tat_line.Area =this.Area;
            last_station = tat_line.Station[i];
            first_station=tat_line.Station[0];
            return tat_line;
        }
    }
}
       