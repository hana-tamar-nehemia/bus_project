using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{
    [Serializable]
    public class MyException : Exception
    {
        public int Capacity { get; private set; }

        public MyException() : base() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception inner) : base(message, inner) { }

        override public string ToString()
        { return "MyException:" + Capacity + "\n" + Message; }
    }
    class Program
    {


        static void Main(string[] args)
        {



            Console.WriteLine("enter 0\n to add a new line");
            Console.WriteLine("enter 1\n to add a station to line");
            Console.WriteLine("enter 2\n to remove line");
            Console.WriteLine("enter 3\n to remove station from line");
            Console.WriteLine("enter 4\n to search line that pass in a spesific station");
            Console.WriteLine("enter 5\n to saerch the all option to drive from the shorter to longer time");
            Console.WriteLine("enter 6\n to print all the line");
            Console.WriteLine("enter 6\n to print all the station and line");
            Console.WriteLine("enter 8\n to finish");
            try
            {
                List<Bus_station> Stations = new List<Bus_station>();
                for (int h = 0; h < 40; h++)//40 station
                {
                    Bus_station add_station = new Bus_station();
                    add_station.MyCode = h;
                    Stations.Add(add_station);
                }
                Bus_lines_collection lines = new Bus_lines_collection();
                int k = 0;
                int i = 0;
                for (int j = 0; j < 10; j++)
                {
                    for (i = k; i < i + 4; i++)
                    {
                        Bus_line build_line = new Bus_line();
                        Bus_line_station build_station = new Bus_line_station();
                        build_station.My_station = Stations[i];
                        build_line.Stations.Add(build_station);
                        if (i + 1 == i + 4)//כשזה יהיה לפני היציאה תכניס את הקו
                        {
                            lines[j] = build_line;
                        }
                    }
                    k = +4;
                }
                for (int j = 0; j < 4; j++)
                {
                    Bus_line_station add = new Bus_line_station();
                    add.My_station = Stations[i];
                    i++;
                }
                string num1;
                    int choice;
                    do
                    {
                        Console.WriteLine("Enter your choice:");
                        num1 = Console.ReadLine();
                        choice = int.Parse(num1);
                        switch (choice)
                        {
                            case 0:
                            {
                                Console.WriteLine("enter the num of the new line:\n");//num of line
                                int num_line = int.Parse(Console.ReadLine());
                                if (lines.If_the_line_not_exsist(num_line))//chack if the num line ok
                                    lines.Add_bus_line(Stations);
                                break;
                            }
                            case 1:
                            {
                                Console.WriteLine("to what line you would like to add a station?:\n");
                                int num_line = int.Parse(Console.ReadLine());
                                int index = lines.Find_line(num_line);
                                if (index != 0)//line exsist
                                {
                                    Console.WriteLine("after which station you want to add the statin?:\n");//after who
                                    int num = int.Parse(Console.ReadLine());
                                    if (lines[index].Find_station(num) != -1)
                                    {
                                        Console.WriteLine("enter the station you want to add:\n");//station to add
                                        int add = lines.Find_line(num_line);
                                        int y_n = Stations[0].The_bus_exsist(Stations, add);//yes or not
                                        if (y_n != -1)//the station in system
                                        {
                                            Bus_line_station new_station = new Bus_line_station();
                                            new_station.My_station = Stations[y_n];
                                            lines[index].Stations.Add(new_station);
                                        }
                                        else
                                            throw new MyException("the station you want to add doesnt exsist in the system");

                                    }
                                    else
                                    {
                                        throw new MyException("the station doesnt exsist in this line");
                                    }
                                }
                                break;
                            }
                        case 2:
                                {
                                Console.WriteLine("which line you want to remove?");
                                int num = int.Parse(Console.ReadLine());
                                if (lines.Find_line_bool(num) == true)
                                    lines.Remove_bus_line(num);
                                else
                                    throw new MyException("the line already doesnt exsist");
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("from which line you would like to remove a station?:\n");
                                int num_line = int.Parse(Console.ReadLine());
                                if (lines.Find_line_bool(num_line))
                                {

                                    Console.WriteLine("enter the station you want to remove:\n");//station to remove
                                    int num = int.Parse(Console.ReadLine());
                                    lines[num_line].Remove_station(num);//index of line to remove station in it
                                }
                                break;
                            }
                            case 4:// to search line that pass in a spesific station

                            {
                                Console.WriteLine("which station you are right now?\n");
                                int num = int.Parse(Console.ReadLine());
                                bool f = false;
                                for (int h = 0; h < lines.bus_line_list.Count; h++)
                                {
                                    if (lines.line_pass_in_spesific_station(h, num) != -1)
                                    {
                                        Console.WriteLine($"line num{lines[h].My_line_number}");
                                        f = true;
                                    }
                                }
                                if (f == false)
                                {
                                    Console.WriteLine("no line pass in this station");
                                }
                                break;
                            }
                                                           
                        case 5:
                            {
                                Console.WriteLine("which station you are right now?\n");
                                int moza = int.Parse(Console.ReadLine());
                                int x = Stations[0].The_bus_exsist(Stations, moza);//exsist or not
                                if (x != -1)//the station in system
                                {
                                    Console.WriteLine("to where station you want to drive?\n");
                                    int sof = int.Parse(Console.ReadLine());
                                    int y = Stations[0].The_bus_exsist(Stations, sof);//exsist or not
                                    if (y != -1)//the second station in system
                                    {

                                    }
                                }
                                else
                                    throw new MyException("no such a station in system");
                                break;
                            } 
                            case 6:
                                {
                                break;
                            }
                            case 7:
                                {
                                break;
                            }
                            default:
                                {
                                    Console.WriteLine("try again");
                                }
                                break;

                        }


                    } while (choice != 8);
                }


            catch (MyException excep)
            {
                Console.WriteLine(excep);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exc: ");
                Console.WriteLine(ex);
            }


        }
    }
    
}
