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
        
        public int Line_Number { get; set; }//מספר קו
        public Areas Area { get; set; }
        public int Line_Id { get; set; }
        public int First_Station { get; set; }
        public int Last_Station { get; set; }
        public bool Act { get; set; }
        public IEnumerable<LineStation> ListLineStations { get; set; }

        //public IEnumerable<AdjStation> AdjStations { get; set; }


    }
}
