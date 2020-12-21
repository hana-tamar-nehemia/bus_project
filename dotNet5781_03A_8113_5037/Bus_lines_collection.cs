using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{
    public class Bus_lines_collection : IEnumerable
    {

        private List<Bus_line> Bus_line_list = new List<Bus_line>();

        public List<Bus_line> bus_line_list
        {
            get { return Bus_line_list; }
            set { Bus_line_list = value; }
        }

        public IEnumerator GetEnumerator()
        {
            return Bus_line_list.GetEnumerator();
        }

        public bool If_the_line_not_exsist(int a)
        {

            for (int i = 0; i < bus_line_list.Count; i++)
            {
                if (bus_line_list[i].My_line_number == a)
                    return false;
            }
            return true;
        }

        public void Tatim_if_line(int num, int num2)
        {

            List<Bus_line> tatim = new List<Bus_line>();
            for (int i = 0; i < Bus_line_list.Count; i++)
            {
                Bus_line add = new Bus_line();
                add = bus_line_list[i].Tat_road(num, num2);
                if (add != null)
                {
                    tatim.Add(add);
                }
            }
            if (tatim != null)
            {
                tatim.Sort();
                Console.WriteLine("the line/s you have from the short time to longer:\n");
                for (int i = 0; i < tatim.Count; i++)
                {
                    Console.WriteLine($"{tatim[i].My_line_number}\n");
                }
            }
            else
            {
                throw new MyException("there isnt no buses for you");
            }


        }
      
        /// <summary>
        /// add new line 
        /// it means to sdd new num of line and 2 station
        /// </summary>
        /// <param name="Stations">this all station in system
        /// <param name="n">num of line</param>
        public void Add_bus_line(List<Bus_station> Stations, int n)
        {
            int index_of_the_station = 0;
            Bus_line line = new Bus_line();//new line
            line.My_line_number = n;

            //add the first station//
            Console.WriteLine("enter the exsit stations");//enter station
            Console.WriteLine("#");
            int station = int.Parse(Console.ReadLine());//enter the first station
            while ( !Stations[0].The_bus_exsist_bool(Stations, station))
            {
                Console.WriteLine("try another station");
                Console.WriteLine("#");
                station = int.Parse(Console.ReadLine());//enter the first station
            }
            Bus_line_station line_station = new Bus_line_station();//new staition of line 
            index_of_the_station = Stations[0].The_bus_exsist(Stations, station);
            line_station.My_station = Stations[index_of_the_station];
            line.MyStations.Add(line_station);
            Console.WriteLine("added");
            int i = station;
            //last station
            Console.WriteLine("enter the last stations");//enter station
            Console.WriteLine("#");
            station = int.Parse(Console.ReadLine());//enter the first station
            while ( !Stations[0].The_bus_exsist_bool(Stations, station) || station == i)
            {
                Console.WriteLine("try another station");
                Console.WriteLine("#");
                station = int.Parse(Console.ReadLine());//enter the first station
            }
            Bus_line_station line_station2 = new Bus_line_station();//new staition of line 
            index_of_the_station = Stations[0].The_bus_exsist(Stations, station);
            line_station2.My_station = Stations[index_of_the_station];
            //add the last station///
            line.MyStations.Add(line_station2);
            Console.WriteLine("added");

            line.set_last_and_first();
            this.Bus_line_list.Add(line);//add the line
            Console.WriteLine("done");
        }

        /// <summary>
        /// the func search spesific line in the collection of all the line in the system
        /// and return the index or 0 if it doesnt exsist
        /// </summary>
        /// <param name="num"> the number of line we need to search</param>
        /// <returns>the index</returns>0 if it doesnt exsist
        public int Find_line(int num)
        {
            for (int i = 0; i < bus_line_list.Count; i++)
            {
                if(bus_line_list[i].My_line_number==num)
                {
                    return i;
                }
            }
            return 0;
        }
        /// <summary>
        /// the func search spesific line in the collection of all the line in the system
        /// and return true or false if it doesnt exsist
        /// </summary>
        /// <param name="num">the number of line we need to search</param>
        /// <returns>true if he is found</returns>false if it doesnt exsist
        public bool Find_line_bool(int num)
        {
            for (int i = 0; i < bus_line_list.Count; i++)
            {
                if (bus_line_list[i].My_line_number == num)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// the func remove line fron the system the user can remove one side of the line or the both side
        /// </summary>
        /// <param name="num">number of line</param>
        public void Remove_bus_line(int num)
        {
            int index = Find_line(num);
            Console.WriteLine($"enter 1 - to remove line {num} forth\n 2 to remove line {num} back\n 3 to remove both line");
            while (1==1)
            {
                int n = int.Parse(Console.ReadLine());//enter the first station
                if (n == 1 && Bus_line_list[index].My_go2 == 1)
                { Bus_line_list[index].My_go1 = 0; Console.WriteLine("done"); return; 
                }//remove back line
                if (n == 2 && Bus_line_list[index].My_go1 == 1)
                { Bus_line_list[index].My_go2 = 0; Console.WriteLine("done"); return;
                }//remove back line
                if (n == 3|| (n == 2 && Bus_line_list[index].My_go1 == 0)|| n == 1 && (Bus_line_list[index].My_go2 == 0))
                { Bus_line_list.Remove(Bus_line_list[index]); Console.WriteLine("done");//Remove line
                    return; 
                }
                else
                    Console.WriteLine($" wrong gidit try again");
            }

        }
        
        public override string ToString()
        {
            for(int u=0;u<bus_line_list.Count;u++)
            {
                Console.WriteLine(bus_line_list[u]);
            }
            return "end";
        }


        /// <summary>
        /// sort by the func comper to that i made in bus line class.
        /// sort the line from the shorter to longer time of drive
        ///
        /// </summary>
        /// <returns>the new sort list of line</returns>
        public List<Bus_line> Sort_line_by_time()
        {
             bus_line_list.Sort();
            return bus_line_list;
        }
        
        /// <summary>
        /// indexer return the index of the line and if the line doesnt exsist exception throw
        /// </summary>
        /// <param name="line">num of line to search in the system</param>
        /// <returns></returns>
        public Bus_line this[int line]
        {
            get
            {
                if (Find_line_bool(line))
                    return Bus_line_list[Find_line(line)];
                else
                    throw new MyException($"line {line} doesnt exsist");
            }
            set
            {
                Bus_line_list[line] = value;
            }
        }
    }
}




   
