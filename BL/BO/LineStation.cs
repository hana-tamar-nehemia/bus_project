using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineStation:Station
    {
        public int ID_Line { get; set; }//קו שעובר בה
        public int Number_Line { get; set; }//קוד תחנה
        public int Line_Station_Index { get; set; }

        public AdjStation adjStation;//זמני הגעה אליה
        public int Prev_Station { get; set; }
        public int Next_Station { get; set; }
    }
}
