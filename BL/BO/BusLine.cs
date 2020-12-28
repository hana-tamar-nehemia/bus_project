using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
     public class BusLine
    {
        public int Bus_Id { get; set; }//רץ אוטומטי
        public int Line_Number { get; set; }
        public Areas Area { get; set; }
        public int First_Station { get; set; }
        public int Last_Station { get; set; }
    }
}
