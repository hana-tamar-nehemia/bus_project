﻿using System;
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
        //**************************************************
        private string station_address;
        public string My_station_address
        {
            get { return station_address; }
            set
            {
                station_address = value;
            }
        }
        //****************************************************

        //****************************************************
        private double[] station_location;
        public double[] My_station_location
        {
            get { return station_location; }
            set
            {
                Random r = new Random();
                double[] arr = new double[2];
                arr[0] = r.NextDouble() * (33.3 - 31.0) + 31.0;// קו אורך
                arr[1] = r.NextDouble() * (35.5 - 34.3) + 34.3;// קו רוחב 
            }
        }
        //*****************************************************

        public bool The_bus_exsist_bool(List<Bus_station> a,int n)
        {

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].MyCode == n)
                    return true;
            }
            return false;
        }
        public int The_bus_exsist(List<Bus_station> a, int n)
        {

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].MyCode == n)
                    return i;
            }
            return -1;
        }
        public override string ToString()
        {
            string dorest_to_string = $" Bus Station Code: {code}, {station_location[1]}°N  {station_location[0]}°E";
            return dorest_to_string;
        }
        
    }
}












