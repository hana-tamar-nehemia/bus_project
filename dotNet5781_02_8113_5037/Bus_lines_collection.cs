using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{
    class Bus_lines_collection : IEnumerable
    {

        private List<Bus_line> Bus_line_list;

        public List<Bus_line> bus_line_list
        {
            get { return Bus_line_list; }
            set { Bus_line_list = value; }
        }
        //**************************************    
        public IEnumerator GetEnumerator()
        {
            return Bus_line_list.GetEnumerator();
        }

        //**************************************
        public bool If_the_line_not_exsist(int a)
        {
           
            for (int i = 0; i < bus_line_list.Count; i++)
            {
                if (bus_line_list[i].My_line_number == a)
                    return false;
            }
            return true;
        }

        public void Tatim_if_line(int num,int num2)
        {
            
            List<Bus_line> tatim = new List<Bus_line>();
            for (int i = 0; i < Bus_line_list.Count; i++)
            {
                Bus_line add = new Bus_line();
                add = bus_line_list[i].tat_road(num, num2);
               if (add!=null)
                { 
                    tatim.Add(add);
                }
            }
            if (tatim!=null)
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

        public void Add_bus_line(List<Bus_station> Stations)
        {

            Console.WriteLine("enter the stations the line go through:\n to stop enter 0\n ");//enter station
            Console.WriteLine("#");
            int station = int.Parse(Console.ReadLine());//enter the first station
            Console.WriteLine("\n");
            int index_of_the_station = 0;
            if (station != 0)
            {
                do
                {
                    bool f = false;
                    for (int i = 0; i < Stations.Count; i++)//find the station in the list
                    {
                        if (Stations[i].MyCode == station)
                        {
                            index_of_the_station = i;
                            i = Stations.Count;
                            f = true;
                        }
                    }
                    if (f)//the station found and adding to the new line
                    {
                        Bus_line_station line_station = new Bus_line_station();//new staition of line 
                        line_station.My_station = Stations[index_of_the_station];//put the station in the line
                        Bus_line line = new Bus_line();//new line
                        line.Stations.Add(line_station);
                        this.Bus_line_list.Add(line);//add the line
                    }
                    else
                    {
                        Console.WriteLine("try another station\n");//enter station
                    }
                    Console.WriteLine("#");
                    station = int.Parse(Console.ReadLine());//enter the first station
                    Console.WriteLine("\n");

                } while (station != 0);//have more station
            }
        }
        //***************************************
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
        //*****************************************
        public void Remove_bus_line(int num)
        {
            int index = Find_line(num);
            Console.WriteLine($"enter 1 to remove line {num} forth\n 2 to remove line {num} back\n 3 to remove both");
            bool f = false;
            while (f == false)
            {
                int n = int.Parse(Console.ReadLine());//enter the first station
                if (n == 1)
                { Bus_line_list[index].My_go1 = 0; Console.WriteLine("done"); return; 
                }//remove back line
                if (n == 2)
                { Bus_line_list[index].My_go2 = 0; Console.WriteLine("done"); return;
                }//remove back line
                if (n == 3)
                { Bus_line_list.Remove(Bus_line_list[index]); Console.WriteLine("done");
                    return; }//Remove line
                else
                    Console.WriteLine($" wrong gidit try again");
            }

        }
        public int line_pass_in_spesific_station(int i, int station)
        {
            return bus_line_list[i].Find_station(station);
        }

            //*****************************************
        //public List<Bus_line> List_lines_pass_station(int code)
        //{
        //    List<Bus_line> temp = new List<Bus_line>();
        //    foreach (Bus_line bus in Bus_line_list)
        //    {
        //        for (int i = 0; i < bus.Stations.Count; i++)
        //        {
        //            if (bus.Stations[i].MyCode == bus_code)
        //            {
        //                temp.Add(bus);
        //                i = bus.Stations.Count;
        //            }
        //        }
        //    }
        //    return temp;
        //}
        //***************************************
        public List<Bus_line> Sort_line_by_time ()
        {
            return bus_line_list.Sort();
        }
        //**************************************
        public Bus_line this[int line]
        {
            get
            {
                if (Find_line(line) != -1)
                    return Bus_line_list[Find_line(line)];
                else
                    throw new MyException($"line{line}doesnt exsist");
            }
            set
            {
                Bus_line_list[line] = value;
            }
        }
    }
}




   
