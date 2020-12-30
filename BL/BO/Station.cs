using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Station
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }//אווירי
        public double longitude { get; set; }
        public IEnumerable<BusLine> Collection_Lines { get; set; }//קווים שעוברים בה
       // public IEnumerable<DateTime>  Arrival_times { get; set; }
       
    }
}
