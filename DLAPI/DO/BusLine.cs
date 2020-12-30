using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class BusLine
    {
        public int Bus_Id { get; set; }//לוחית רישוי
        public int Line_Id { get; set; }//מספר מזהה קו שהוא גם נמצא בתחנות
        public int Line_Number { get; set; }
        public Areas Area { get; set; }
        public int First_Station { get; set; }
        public int Last_Station { get; set; }
        public bool Act { get; set; }

    }
}
