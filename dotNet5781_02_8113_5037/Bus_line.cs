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

        private string area = "";

        public string My_area
        {
            get { return area; }
            set { area = value; }
        }

        private Bus_line_station first_station;

        public Bus_line_station First_station
        {
            get { return first_station; }
            set { first_station = value; }
        }

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
            set { time = Time_between_2_station(first_station, Last_station); }
        }

        public Bus_line()
        {
            
        }
        public void set_last_and_first()
        {
            if (stations.Count > 1)
            {
                first_station = stations[0];
                last_station = stations[(stations.Count) - 1];
                time = Time_between_2_station(first_station, Last_station);
            }
        }
        ////FUNCTION//////////////////
        /// <summary>
        ///  the func search spesific station in the list of the bus 
        /// and return the index or -1 if it doesnt exsist
        /// </summary>
        /// <param name="num">number of station we need to find</param>
        /// <returns>index of station and -1 if it doesnt exsist </returns> 
        public int Find_station(int num)
        {
            for (int i = 0; i < stations.Count(); i++)
            {
                if (stations[i].My_station.MyCode == num)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// the bool func search spesific station in the list of the bus 
        /// and return true or false if it doesnt exsist
        /// </summary>
        /// <param name="num">number of station we need to find</param>
        /// <returns>true or false if it doesnt exsist</returns>
        public bool Bool_find(int num)
        {
           
                for (int i = 0; i < stations.Count(); i++)
                {
                    if (stations[i].My_station.MyCode == num)
                    {
                        return true;
                    }
                }
            
            return false;
        }
        /// <summary>
        /// print the number of the bus and the route 
        /// if there are line that go to two side than we printthe too route
        /// </summary>
        /// <returns>string  "end"</returns>
        public override string ToString()
        {
            int i = stations.Count();
            Console.WriteLine($"Bus line: {this.line_number}\nActivity area: {this.area}");
            if (My_go1 == 1)
            {
                Console.WriteLine($"{My_line_number} route: ");
                for (int k = 0; k < i; k++)
                {
                    Console.WriteLine($"{ stations[k].My_station.MyCode} >>> ");
                }
            }
            if (My_go2 == 1)
            {
                Console.WriteLine("and return phat");
            }
            return "";
        }
        /// <summary>
        /// the func add to spesific line new station the user choose to add
        /// </summary>
        /// <param name="new_station">the new station the user want to enter to spesific line</param>
        public void Add_station(List<Bus_station> all_station)
        {
            Console.WriteLine("after which station do you want to add your station?");
            int after_this = int.Parse(Console.ReadLine());
            int index = this.Find_station(after_this);//find the station to put after the new station
            if (index != -1)
            {
                Console.WriteLine("enter the station you want to add:\n");//station to add
                int add = int.Parse(Console.ReadLine());
                int ind = Station_in_system(all_station, add);
                if (ind != -1)//the station in system and not in the list   
                {
                    if (!this.Bool_find(add))
                    {
                        Bus_line_station new_station = new Bus_line_station();
                        new_station.My_station = all_station[ind];
                        this.stations.Add(new_station);
                    }
                    else
                        throw new MyException("the station already exsist in this line");
                }
                else
                    throw new MyException("the station isnt exsist");

                this.set_last_and_first();
                time = this.Time_between_2_station(First_station, last_station);
            }
            else
            {
                throw new MyException("the station isnt exsist");
            }
        }
        /// <summary>
        /// the func remove from the route of spesific line the station the user choose to remove
        /// </summary>
        /// <param name="num">the num of station we need to remove</param>
        public void Remove_station(int num)
        {
            int i = stations.Count();
            int index = this.Find_station(num);//find the station to remove
            if (index != -1)
            {
                stations.Remove(stations[index]);
                this.set_last_and_first();
                Console.WriteLine("removed");
            }
            else
            {
                throw new MyException("the station isnt exsist");
            }
        }
        /// <summary>
        /// the func calculate the km between 2 station
        /// </summary>
        /// <param name="a">the first station</param>
        /// <param name="b">the last station</param>
        /// <returns>the km between 2 station</returns>
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

        /// <summary>
        /// the func calculate the time of driv between 2 station
        /// </summary>
        /// <param name="a">the first station</param>
        /// <param name="b">the last station</param>
        /// <returns>the time of drive between 2 station</returns>
        public TimeSpan Time_between_2_station(Bus_line_station a, Bus_line_station b)
        {
            int staion1 = a.My_station.MyCode;
            int staion2 = b.My_station.MyCode;
            int index2 = this.Find_station(staion2);
            int index1 = Find_station(staion1);
            if (index2 != -1 && index1 != -1)
            {
                int i = this.stations.Count();
                TimeSpan time= new TimeSpan();
                for (index1 = Find_station(staion1) + 1; index1 <= index2; index1++)
                {
                    time += stations[index1].Func_time_from_last_station; //sum time of the phat
                }
                return time;
            }
            else
            {
                throw new MyException("not the two of station exsist in this line");
            }
        }
        /// <summary>
        /// the func got 2 station that in an exsist line adn return only the phat betwen those stations
        /// </summary>
        /// <param name="num">the first station<param>
        /// <param name="num2">the last station</param>
        /// <returns>return the bus with the new change in the phat </returns>
        public Bus_line Tat_road(int num,int num2)
        {
            int i1 = this.Find_station(num);
             int i2 = this.Find_station(num2);
            if ( i1 != -1 &&  i2 != -1 )
            {
                Bus_line tat_line = new Bus_line();
                tat_line.line_number = this.line_number;
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
                tat_line.line_number = this.line_number;
                tat_line.area = this.area;
                tat_line.set_last_and_first();
                return tat_line;

            }
            else
                return null;
            
        }


        /// <summary>
        /// the func comper the time between 2 bus  
        /// </summary>
        /// <param name="other">the second bus</param>
        /// <returns>return 1 if the first shorter then the second
        /// or 0 if equal and -1 if the first bus longer</returns>
        public int CompareTo(Bus_line other)
        {
            this.time = this.Time_between_2_station(this.first_station, this.last_station);//first time 
            other.time = other.Time_between_2_station(other.first_station, other.last_station); //second time
            return this.time.CompareTo(other.time);//comper
        }


        /// <summary>
        /// the func check if the station exsist in the system 
        /// </summary>
        /// <param name="a">all the stations that exsist in the system</param>
        /// <param name="num">the station we search</param>
        /// <returns>return the index of the station and -1 if the statin doesnt exsist</returns>
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
       