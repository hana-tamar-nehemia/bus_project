﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineStation:Station
    {   //station
        //public int Code { get; set; }
        //public string Name { get; set; }
        //public string Address { get; set; }
        //public double Latitude { get; set; }//אווירי
        //public double longitude { get; set; }
        //public bool Act { get; set; }

        public int Line_Id { get; set; }
        public string Number_Line { get; set; }//קו שעובר בה
        public int Line_Station_Index { get; set; }
         public bool ActLineStation { get; set; }
        public double distance { get; set; }//אווירי
        public TimeSpan time  { get; set; }
        //public int Prev_Station { get; set; }
        //public int Next_Station { get; set; }
    }
}
