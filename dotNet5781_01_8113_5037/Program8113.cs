using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_8113_5037
{
     class Program
    {
        public class Bus
        {

            public int all_km = 0;
            public int km_between_treatment = 0;
            public string Licens_plate;
            public DateTime date;
            public float km = 0;
            public DateTime date_treatment;


            public Bus(DateTime _date, string _Licens_plat)
            {
                Licens_plate = _Licens_plat;
                date = _date;
                date_treatment = _date;
            }
            public static bool check_the_year_fit_the_digit_number(int Licens, DateTime date)
            {
                if (date.Year < 2018 && Licens <= 9999999 || date.Year > 2018 && Licens > 9999999)
                    return true;
                else
                    return false;
            }
            public static void look_if_the_bus_exsist_or_fine(int k_m, string Licens, List<Bus> a)//
            {
                foreach (Bus i in a)
                {
                    if (i.Licens_plate == Licens)//look the right Licens_plate
                    {
                        DateTime date1 = DateTime.Now;
                        TimeSpan N = date1 - i.date_treatment;
                        if (N.Days < 356)
                        {
                            if (i.km + k_m < 1200 && i.km_between_treatment + k_m < 20000)//if the bus didnt do more then 1200 km
                            {
                                i.km = i.km + k_m;
                                i.km_between_treatment += k_m;
                                Console.WriteLine("done, the bus is ready to drive");
                                return;
                            }
                            else
                                Console.WriteLine("the bus have not enough fuel");// the bus did more then 1200 km
                            return;
                        }
                        else
                            Console.WriteLine("the bus was taken off the road");// the bus did more then 1200 km
                        return;
                    }
                }
                Console.WriteLine("the bus dosnt exsist");//the bus doesnt exsist
            }
        }

        public static Random r = new Random();
        public static void print_km7(Bus bus)
        {

            Console.WriteLine(bus.Licens_plate.Substring(0, 2) + "-" + bus.Licens_plate.Substring(2, 3) + "-" + bus.Licens_plate.Substring(5, 2) + " done " + bus.km_between_treatment + " since the last treatment");
        }
        public static void print_km8(Bus bus)
        {

            Console.WriteLine(bus.Licens_plate.Substring(0, 3) + "-" + bus.Licens_plate.Substring(3, 2) + "-" + bus.Licens_plate.Substring(5, 3) + " done " + bus.km_between_treatment + " since the last treatment");
        }
        static void Main(string[] args)
        {

            List<Bus> all_bus = new List<Bus>();

            Console.WriteLine("Enter your choice:");
            Console.WriteLine("enter 0 to add a new bus");
            Console.WriteLine("enter 1 to choose a bus");
            Console.WriteLine("enter 2 to fuel or treatmet");
            Console.WriteLine("enter 3 to check the km of the all buses");
            Console.WriteLine("enter 4 to finish");

            string num1 = Console.ReadLine();
            int choice = int.Parse(num1);
            do
            {
                switch (choice)
                {
                    case 0:
                        {
                            Console.WriteLine("enter a Licens_plate");
                            string Licens = Console.ReadLine();//enter licens
                            int num_Licens = int.Parse(Licens);//change to number
                            Console.WriteLine("enter the date of commencement of activity");
                            string D = Console.ReadLine();//enter licens
                            DateTime d;
                            bool f = DateTime.TryParse(D, out d);
                            if (Bus.check_the_year_fit_the_digit_number(num_Licens, d))
                            {
                                Bus n = new Bus(d, Licens);//create a new bus
                                all_bus.Add(n);//add the bus
                            }
                            else
                            {
                                Console.WriteLine("ERROR,the year doesnt fit the Licens plate");
                            }
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("enter a Licens plate of the bus:");
                            string Licens = Console.ReadLine();//enter licens
                            int k_m = r.Next(1200);
                            Bus.look_if_the_bus_exsist_or_fine(k_m, Licens, all_bus);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("enter a Licens plate of the bus:");
                            string Licens = Console.ReadLine();
                            Console.WriteLine("if you need to fuel press 1");
                            Console.WriteLine("for treatment press 2");
                            string n = Console.ReadLine();
                            int f = int.Parse(n);

                            if (f == 1)//to fuel
                            {
                                foreach (Bus i in all_bus)
                                {
                                    if (i.Licens_plate == Licens)//look the right Licens_plate
                                    {
                                        i.km = 0;
                                    }
                                }
                            }
                            if (f == 2)//to treatment
                            {
                                foreach (Bus i in all_bus)
                                {
                                    if (i.Licens_plate == Licens)//look the right Licens_plate
                                    {
                                        i.all_km = 0;
                                        i.date_treatment = DateTime.Now;
                                        i.km_between_treatment = 0;
                                        Console.WriteLine("the treatment is done");
                                    }
                                }
                            }
                            break;

                        }
                    case 3:
                        {

                            foreach (Bus i in all_bus)
                            {

                                if (int.Parse(i.Licens_plate) <= 9999999)
                                {
                                    print_km7(i);
                                }
                                if (int.Parse(i.Licens_plate) > 9999999)
                                {
                                    print_km8(i);
                                }
                            }
                            break;

                        }
                    case 4:
                        {

                            break;
                        }
                    default:
                        break;

                }
                Console.WriteLine("Enter your choice:");
                num1 = Console.ReadLine();
                choice = int.Parse(num1);
            } while (choice != 4);
        }
    }
}
