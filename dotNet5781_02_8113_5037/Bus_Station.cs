using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{
  //  class program
   // {
        public class Bus_station
        {
            private static int code=0;
            public int MyCode
            {
                get { return code; }
                set
                {
                     
                    
                   
                   code = MyCode;
                            
                }
            }
            //**************************************************
            private string station_address;
            public string My_station_address
            {
                get { return station_address; }
                set
                {
                    My_station_address = "";
                    station_address = My_station_address;
                }
            }
            //****************************************************
            public static Random r = new Random();
            //****************************************************
            private double[] station_location;
            public double[] My_station_location
            {
                get { return station_location; }
                set
                {
                    double[] arr = new double[2];
                    arr[0] = r.NextDouble() * (33.3 - 31.0) + 31.0;// קו אורך
                    arr[1] = r.NextDouble() * (35.5 - 34.3) + 34.3;// קו רוחב 
                }
            }
            //*****************************************************
            public override string ToString()
            {
                string dorest_to_string = $" Bus Station Code: {code}, {station_location[1]}°N  {station_location[0]}°E";
                return dorest_to_string;
            }

     //   }
   }
}












