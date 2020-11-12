using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{
    class Bus_lines_collection<Bus_line> : IEnumerable<Bus_line> 
    {
       public List<Bus_line> Bus_line_list { get; set; }
       public Bus_lines_collection ()
        {
            Bus_line_list = new List<Bus_line>();
        }
     //**************************************    
        public IEnumerator GetEnumerator()
        {
            return List.GetEnumerator();
        }
     //**************************************
        public void Add_bus_line(Bus_line add_bus )
        {
            if (add_bus != null )
               Bus_line_list.Add(add_bus);
            else// לזרוק שגיאה 
        }
     //***************************************
        public void Remove_bus_line(Bus_line remove_bus)
        {

            Bus_line_list.Remove(remove_bus);
             
        }
     //***************************************




    }
}
