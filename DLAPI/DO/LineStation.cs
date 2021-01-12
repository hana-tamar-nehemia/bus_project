using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class LineStation
    {
        public int Code { get; set; }//מס תחנה
        public int Line_Id { get; set; }
        public int Line_Station_Index { get; set; }
        public bool ActLineStation { get; set; }

        //public int Prev_Station { get; set; }
        //public int Next_Station { get; set; }
    }
}
