using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class Station
    {
        public int ID_Line { get; set; }
        public int Num_Line { get; set; }
        public int Last_Station { get; set; }
        public IEnumerable<BusLine> Collection_Lines { get; set; }
        public DateTime Arrival_times { get; set; }
        public override string ToString()
        {
            Console.WriteLine($"ID Line ")
        }


    }
}
