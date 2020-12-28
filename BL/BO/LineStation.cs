using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
   public class LineStation : Station
    {
        public int Line_Id { get; set; }
        public int Code { get; set; }
        public int Line_Station_Index { get; set; }
        //public int Prev_Station { get; set; }
        //public int Next_Station { get; set; }
    }
}
