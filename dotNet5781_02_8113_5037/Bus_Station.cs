﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{
    class Bus_station
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
                        MyCode = int.Parse(string_code);
                        if (MyCode > 100000 && MyCode < 0)
                            Console.WriteLine("worng station code - try again");
                        else
                        {
                            code = MyCode;
                            fcode = true;
                        }  
                          
                    }

                }
            }

            
            //**************************************************
            private string station_address;

            public string My_station_address
            {
                get { return station_address; }
                set
                {
                    Console.WriteLine("Enter a station address");
                    My_station_address = Console.ReadLine();
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

        }
    }
}












