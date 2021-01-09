using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Station
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }//אווירי
        public double longitude { get; set; }
        public bool Act { get; set; }

        public static object Clone(AdjStation adjStation)
        {
            throw new NotImplementedException();
        }

        public static object Clone(BusLine busLine)
        {
            throw new NotImplementedException();
        }
    }
}
