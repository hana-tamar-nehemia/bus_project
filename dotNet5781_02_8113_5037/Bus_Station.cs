using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace dotNet5781_02_8113_5037
{
    //  class program
    // {
    public class Bus_station
    {
        private int code;
        public int MyCode
        {
            get { return code; }
            set
            { code = value; }
        }
        private string station_address="";
        public string My_station_address
        {
            get { return station_address; }
            set
            {
                station_address = value;
            }
        }

        private double[] station_location;
        public double[] My_station_location
        {
            get { return station_location; }
            set { }
        }
         


       public Bus_station()
        {
            Random r = new Random();
            station_location = new double[2];
            station_location[0] = r.NextDouble() * (33.3 - 31.0) + 31.0;// קו אורך
            station_location[1] = r.NextDouble() * (35.5 - 34.3) + 34.3;// קו רוחב 
        }
        
        public bool The_bus_exsist_bool(List<Bus_station> a,int n)
        {

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].MyCode == n)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// the func check if the station exsist in the system 
        /// </summary>
        /// <param name="a">all the stations that exsist in the system</param>
        /// <param name="num">the station we search</param>
        /// <returns>return the index of the station and -1 if the statin doesnt exsist</returns>
        public int The_bus_exsist(List<Bus_station> a, int n)
        {

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].MyCode == n)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// print the code of station and the location
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string dorest_to_string = $" Bus Station Code: {code}, {My_station_location[1]}°N  {My_station_location[0]}°E";
            return dorest_to_string;
        }
        
    }
}












