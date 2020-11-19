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

        public void Tatim_if_line(int num,int num2)
        {
            
            List<Bus_line> tatim = new List<Bus_line>();
            for (int i = 0; i < Bus_line_list.Count; i++)
            {
                Bus_line add = new Bus_line();
                add = bus_line_list[i].Tat_road(num, num2);
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
            //List<Bus_line> n = new List<Bus_line>();
            bool f = false;
            int counter = 0;
            Console.WriteLine("enter the stations the line go through:\n to stop enter 0\n ");//enter station
            Console.WriteLine("#");
            int station = int.Parse(Console.ReadLine());//enter the first station
            Console.WriteLine("\n");
            int index_of_the_station = 0;
            while(f==false||station!=0)

                {
                if (station != 0)
                {
                    do
                    {
                        if (Stations[0].The_bus_exsist_bool(Stations, station))//the station in the system
                        {   //enter the station//
                            Bus_line_station line_station = new Bus_line_station();//new staition of line 
                            line_station.My_station = Stations[index_of_the_station];//put the station in the line
                            Bus_line line = new Bus_line();//new line
                            line.MyStations.Add(line_station);
                            this.Bus_line_list.Add(line);//add the line
                            counter++;
                            Console.WriteLine("added");

                            if (counter >= 2) f = true;
                        }
                        else
                        {
                            Console.WriteLine("no exsist try another station\n");//enter station
                        }
                        Console.WriteLine("#");
                        station = int.Parse(Console.ReadLine());//enter the first station
                        Console.WriteLine("\n");

                    } while (station != 0);//have more station
                }

                if (counter < 2)
                {
                    Console.WriteLine("add more stations not enough station in the new line\n#");
                    station = int.Parse(Console.ReadLine());//enter the first station
                }

            }
        }
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
        public void Remove_bus_line(int num)
        {
            int index = Find_line(num);
            Console.WriteLine($"enter 1 - to remove line {num} forth\n 2 to remove line {num} back\n 3 to remove both line");
            bool f = false;
            while (f == false)
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
        public int Line_pass_in_spesific_station(int i, int station)
        {
            return bus_line_list[i].Find_station(station);
        }

      

        public List<Bus_line> Sort_line_by_time()
        {
             bus_line_list.Sort();
            return bus_line_list;
        }
        
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




   
