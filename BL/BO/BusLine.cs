using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    //[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class BusLine
    {
        public int Bus_Id { get; set; }//רץ אוטומטי
        public int Line_Number { get; set; }
        public Areas Area { get; set; }
        public int First_Station { get; set; }
        public int Last_Station { get; set; }
        public IEnumerable<Station> Stations { get; set; }

        //private string GetDebuggerDisplay()
        //{
        //    return ToString();
        //}
    }
}
