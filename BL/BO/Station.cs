﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Station
    {
        public int ID_Line { get; set; }
        public int Num_Line { get; set; }
        public int Last_Station { get; set; }
        public IEnumerable<BusLine> Collection_Lines { get; set; }
        public DateTime Arrival_times { get; set; }
        


    }
}
