using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;



namespace DS
{
    public class DataSource
    {
        public static List<Bus> List_Bus;
        public static List<Station> List_Station;
        public static List<User> List_User;
        public static List<Adjstation> List_Adjstation;
        public static List<BusLine> List_Bus_Line;
        public static List<BusOnTrip> List_Bus_On_Trip;
        public static List<LineStation> List_Line_Station;
        public static List<LineTrip> List_Line_Trip;
        public static List<Trip> List_Trip;


        static DataSource()
        {
            InitAllLists();
        }
       static Random r = new Random();
       static int code = 11111;
        static int id = 1;
        static int line_number = 1;
        





        static void InitAllLists()
        {

            List_Bus = new List<Bus>
            {
              new Bus
              {
                  License_num = 1068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 2068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 3068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 4068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 5068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 6068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 7068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 8068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 1168393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 2268393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 3368393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 4468393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 5568393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 6668393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 7768393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 8868393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 9968393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 7568393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 4768393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 3968393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              }



            };
             
            List_Station = new List<Station>
            {
                
                new Station
                {
                    Code= code++,
                    Station_Location1=  r.NextDouble() * (33.3 - 31.0) + 31.0,// קו אורך,
                    Station_Location2 =r.NextDouble() * (35.5 - 34.3) + 34.3,// קו רוחב
                     //Station_Name
                }
            };

            List_Bus_Line = new List<BusLine>
            { 
            new BusLine
            {
               Bus_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,

            }
            };
        }
    }
}
