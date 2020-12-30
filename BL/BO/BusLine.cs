using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    //[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class BusLine:Bus
    {
        public int Bus_Id { get; set; }//רץ אוטומטי
        public int Line_Number { get; set; }//מספר קו
        public Areas Area { get; set; }
        public int First_Station { get; set; }
        public int Last_Station { get; set; }
        public IEnumerable<LineStation> Stations { get; set; }

    }
}
