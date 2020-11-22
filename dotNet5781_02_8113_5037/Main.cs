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

        public MyException() : base() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception inner) : base(message, inner) { }

    }

    class Program
    {

        static void Main(string[] args)
        {
         

            try
            {
                Console.WriteLine("enter 0\n to add a new line");
                Console.WriteLine("enter 1\n to add a station to line");
                Console.WriteLine("enter 2\n to remove line");
                Console.WriteLine("enter 3\n to remove station from line");
                Console.WriteLine("enter 4\n to search line that pass in a spesific station");
                Console.WriteLine("enter 5\n to saerch the all option to drive from the shorter to longer time");
                Console.WriteLine("enter 6\n to print all the line");
                Console.WriteLine("enter 7\n to print all the station and line");
                Console.WriteLine("enter 8\n to finish");

                //creat 40 stations
                List<Bus_station> Stations = new List<Bus_station>();
            for (int h = 1; h <= 40; h++)//40 station
            {
                Bus_station add_station = new Bus_station();
                add_station.MyCode = h;
                Stations.Add(add_station);
            }
          
            //creat 10 lines
                Bus_lines_collection lines = new Bus_lines_collection();
                int k = 0;
                int station_num = -1;
                for (int j = 1; j < 11; j++)
                {
                    Bus_line line = new Bus_line();//bus
                    while (k != 4)
                    {
                        station_num++;
                        Bus_line_station station = new Bus_line_station();//bus stasion 
                        station.My_station = Stations[station_num];//station fizi
                        line.MyStations.Add(station);
                        k++;
                    }
                    //the line will be 10, 20 ,30.....100
                    line.My_line_number = j * 10;
                    line.set_last_and_first();
                    lines.bus_line_list.Add(line);
                    k = 0;
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
                                //enter line
                                //check the line exsist
                                //go to add the line with 2 station 
                                //else there is excepsion
                            Console.WriteLine("enter the num of the new line:\n");//num of line
                            int num_line = int.Parse(Console.ReadLine());
                            if (lines.If_the_line_not_exsist(num_line))//chack if the num line ok
                                lines.Add_bus_line(Stations, num_line);
                            else
                                throw new MyException("the line already in the system");
                            break;
                        }
                        //enter line to add station
                        //check the line exsist
                        //go to add the station 
                        //else there is excepsion
                        case 1:
                        {
                            Console.WriteLine("to what line you would like to add a station?:\n");
                            int num_line = int.Parse(Console.ReadLine());
                            int index = lines.Find_line(num_line);
                            if (index != 0)//line exsist
                            {
                                    lines[num_line].Add_station(Stations);
                            }
                            else
                                   throw new MyException("the line doesnt exsist");
                            break;
                        }
                        //enter line to remove
                        //check the line exsist
                        //go to remove
                        //else there is excepsion
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
                        //enter line to remove a station
                        //check the line exsist
                        //else there is excepsion
                        //enter station to remove 
                        //check the station exsist
                        //else there is excepsion
                        //go to remove the station 
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
                            else
                                    throw new MyException("the line doesnt exsist");
                                break;
                        }
                        //enter the station you are right now
                        //check the station exsist
                        //else there is excepsion
                        //print in "for" the line that go through this station
                        case 4:

                            {
                            Console.WriteLine("which station you are right now?\n");
                            int num = int.Parse(Console.ReadLine());
                            bool f = false;
                            for (int h = 0; h < lines.bus_line_list.Count; h++)
                            {
                                if (lines.bus_line_list[h].Bool_find(num))
                                {
                                    Console.WriteLine($"line num {lines.bus_line_list[h].My_line_number} ");
                                    f = true;
                                }
                            }
                            if (f == false)
                            {
                                Console.WriteLine("no line pass in this station");
                            }
                            break;
                            }
                        //enter the station you are right now
                        //check the station exsist
                        //else there is excepsion
                        //enter the station you are right now
                        //check the station exsist
                        //else there is excepsion
                        //go to print the lines that do this phat from the shorter to longer
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
                                    lines.Tatim_if_line(moza, sof);
                                }
                                else
                                {
                                    throw new MyException("no such a station in system");
                                }
                            }
                            else
                                throw new MyException("no such a station in system");
                            break;
                        }
                            //print all line with their phat
                        case 6:
                        {
                                Console.WriteLine(lines);
                            break;
                        }
                        //print station and the lines that go through
                        case 7:
                        {
                            bool f;
                            for (int print = 0; print < Stations.Count; print++)
                            {
                                f = false;
                                Console.WriteLine($"station: {Stations[print].MyCode} ");
                                for (int line = 0; line < lines.bus_line_list.Count; line++)
                                {

                                    if (lines.bus_line_list[line].Bool_find(Stations[print].MyCode))
                                    {
                                        Console.WriteLine($"{ lines.bus_line_list[line].My_line_number} / ");
                                        f = true;
                                    }
                                }
                                if (f == false)
                                    Console.WriteLine("None\n");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("wrong number please try again");
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
            Console.ReadKey(); 
        }
    }

}
