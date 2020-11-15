using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{
    enum Area_Activity {Jerusalem ,Krayot , Mercaz ,Shomron , Klali};
    public class Bus_line: IComparable<Bus_line>
    {
        int line_number;

        public int Line_number { get => line_number; set => line_number = value; }

        //****************************************************

        string Area;

        //*****************************************************
        private Bus_line_station first_station;

        public Bus_line_station First_station
        {
            get { return first_station; }
            set { first_station = value; }
        }

        //****************************************************
        private Bus_line_station last_station;

        public Bus_line_station Last_station
        {
            get { return last_station; }
            set { last_station = value; }
        }
        //****************************************************

        private List<Bus_line_station> Station;
        public List<Bus_line_station> Stations
        {
            get { return Station; }
            set { Station = value; }
        }

        public double Time_between { get; set; }


        ////////////////////////////FUNCTION///////////////////////////////////////////////////////////

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
                First_station = Station[0];
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

            First_station = Station[1];
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
        public float km_between_2_station(Bus_line_station a, Bus_line_station b)
        {
            int staion1 = a.MyCode;
            int staion2 = b.MyCode;
            int index2 = this.find_index(staion2);//find the second station
            int i = this.Station.Count();//count number of stations
            float distance = 0;
            for (int index1 = this.find_index(staion1); ++index1 <= index2;)//find the first station
            {
                distance += Station[index1].func_km_from_last_station;//sum of distance 
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
            int index2 = this.find_index(staion2);
            int i = this.Station.Count();
            TimeSpan time = new TimeSpan();
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
            int index1 = find_index(staion1);
            Bus_line tat_line = new Bus_line();
            if (index2 != -1 && index1 != -1)
            {
                for (index1 = find_index(staion1); index1 <= index2; index1++)
                {
                    tat_line.Station.Add(this.Station[index1]);
                }
                int i = this.Station.Count();//count stations
                tat_line.line_number = this.line_number;
                tat_line.Area = this.Area;
                last_station = tat_line.Station[i];
                First_station = tat_line.Station[0];
            }
            return tat_line;//if there isnt station the list will be empty
        }

       public int CompareTo(Bus_line other)
        {
            this.Time_between = (double)this.time_between_2_station(this.first_station, this.last_station).TotalMinutes;
            other.Time_between = (double)other.time_between_2_station(other.first_station, other.last_station).TotalMinutes;
            return this.Time_between.CompareTo(other.Time_between);
        }
    }
}
       