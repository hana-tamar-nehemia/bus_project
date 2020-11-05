using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{
    class Program
    {
        public class BusStation
        {

            private int code;

            public int MyCode
            {

                get
                {
                    return code;
                }
                set
                {
                    bool fcode = false;
                    while (!fcode)
                    {
                        Console.WriteLine("Enter a station code");
                        string string_code = Console.ReadLine();
                        int num_code = int.Parse(string_code);
                        if (num_code > 100000)
                            Console.WriteLine("worng station code - try again");
                        else
                            fcode = true;
                    }

                }
            }

        }
        private struct station_location
        {
            public double longitude;
            public double latitude;
        }

        public struct My_station_location
        {
            get {return station_location; }
          
        set 
        { 
          public station_location()
         {
             public static Random r = new Random();
             double _longitude = r.NextDouble() * (33.3 - 31.0) + 31.0;
             double _latitude = r.NextDouble() * (35.5 - 34.3) + 34.3;
         }
    
        }   
     }
}
      
