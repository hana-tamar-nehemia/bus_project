using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{
    public class Bus_line : IComparable<Bus_line>
    {
        private int line_number;

        public int My_line_number
        {
            get { return line_number; }
            set { line_number = value; }
        }

        private List<Bus_line_station> stations = new List<Bus_line_station>();

    public List<Bus_line_station> MyStations
    {
        get { return stations; }
        set
        {
            stations = value;
        }
    }


    private int go1 = 1;

        public int My_go1
        {
            get { return go1; }
            set { go1 = value; }
        }

        private int go2 = 1;

        public int My_go2
        {
            get { return go2; }
            set { go2 = value; }
        }
        //****************************************************

        private string area = "";

        public string My_area
        {
            get { return area; }
            set { area = value; }
        }

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


        
        private TimeSpan time;

        public TimeSpan MyTime
        {
            get { return time; }
            set { time = Time_between_2_station(first_station,Last_station); }
        }



        ////FUNCTION//////////////////
        public int Find_station(int num)
        {
            for (int i = 0; i <= stations.Count(); i++)
            {
                if (stations[i].My_station.MyCode == num)
                {
                    return i;
                }
            }
            return -1;
        }
        public bool Bool_find(int num)
        {
            for (int i = 0; i <= stations.Count(); i++)
            {
                if (stations[i].My_station.MyCode == num)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            int i = stations.Count();
            Console.WriteLine($"Bus line: {this.line_number}\n Activity area: {this.area}\n");
            if (My_go1 == 1)
            {
                Console.WriteLine($"{My_line_number} route\n");
                for (int k = 0; k <= i; k++)
                {
                    Console.WriteLine("=>");
                    Console.WriteLine($"{ stations[k].My_station.MyCode}");
                }
            }
            Console.WriteLine("\n");
            if (My_go2 == 1)
            {
                Console.WriteLine($"{My_line_number} return :\n");
                for (int k = i; k > 0; k--)
                {
                    Console.WriteLine("=>");
                    Console.WriteLine($"{ stations[k].My_station.MyCode}");
                }
            }
                return "end.";
        }

        public void Add_station(Bus_line_station new_station)
        {
            Console.WriteLine("after which station do you want to add your station?");
            int after_this = int.Parse(Console.ReadLine());
            int index = this.Find_station(after_this);//find the station to put after the new station
            if (index != -1)
            {
                stations.Insert(index, new_station);
                int i = stations.Count();
                First_station = stations[0];
                last_station = stations[i];
                time = this.Time_between_2_station(First_station, last_station);
            }
            else
            {
                throw new MyException("the station isnt exsist");
            }
        }
        public void Remove_station(int num)
        {
            int i = stations.Count();
            int index = this.Find_station(num);//find the station to remove
            if (index != -1)
            {
                stations.Remove(stations[index]);
                First_station = stations[1];
                last_station = stations[i - 1];
                time = this.Time_between_2_station(First_station, last_station);
                Console.WriteLine("removed");
            }
            else
            {
                throw new MyException("the station isnt exsist");
            }
        }

        public float Km_between_2_station(Bus_line_station a, Bus_line_station b)
        {
            int staion1 = a.My_station.MyCode;
            int staion2 = b.My_station.MyCode;
            int index2 = this.Find_station(staion2);
            int index1 = Find_station(staion1);
            if (index2 != -1 && index1 != -1)
            {
                int i = this.stations.Count();//count number of stations
                float distance = 0;
                for (index1 = this.Find_station(staion1) + 1; index1 <= index2; index1++)//find the first station 
                {
                    distance += stations[index1].Func_km_from_last_station;//sum of distance 
                }
                return distance;
            }
            else
            {
                throw new MyException("not the two of station exsist in this line");
            }
        }

        public TimeSpan Time_between_2_station(Bus_line_station a, Bus_line_station b)
        {
            int staion1 = a.My_station.MyCode;
            int staion2 = b.My_station.MyCode;
            int index2 = this.Find_station(staion2);
            int index1 = Find_station(staion1);
            if (index2 != -1 && index1 != -1)
            {
                int i = this.stations.Count();
                TimeSpan time = new TimeSpan();
                for (index1 = Find_station(staion1) + 1; index1 <= index2; index1++)
                {
                    time.Add(stations[index1].Func_time_from_last_station);
                }
                return time;
            }
            else
            {
                throw new MyException("not the two of station exsist in this line");
            }
        }
        public Bus_line Tat_road(int num,int num2)
        {
            int i1 = this.Find_station(num);
             int i2 = this.Find_station(num2);
            if ( i1 != -1 &&  i2 != -1 )
            {
                Bus_line tat_line = new Bus_line();
                if (i1 < i2)
                {

                    for (i1= this.Find_station(num); i1 <= i2; i1++)
                    {
                        tat_line.stations.Add(this.stations[i1]);
                    }
                }
                else
                {
                    if(i2<i1)
                    for (i2 = this.Find_station(num2); i2 >= i1; i2--)
                    {
                        tat_line.stations.Add(this.stations[i1]);
                    }
                }
                int i = this.stations.Count();//count stations
                tat_line.line_number = this.line_number;
                tat_line.area = this.area;
                last_station = tat_line.stations[i];
                First_station = tat_line.stations[0];
                return tat_line;

            }
            else
                return null;
            
        }

        public int CompareTo(Bus_line other)
        {
            this.time = this.Time_between_2_station(this.first_station, this.last_station);
            other.time = other.Time_between_2_station(other.first_station, other.last_station);
            return this.time.CompareTo(other.time);
        }
            public int Station_in_system(List<Bus_station> a, int num)
        {
            for (int i = 0; i <= a.Count(); i++)
            {
                if (a[i].MyCode == num)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
       