using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8113_5037
{ 
    class Bus_lines_collection :   Bus_line, IEnumerable<Bus_line> 
    {
       public List<Bus_line> Bus_line_list { get; set; }
       public Bus_lines_collection ()
        {
            Bus_line_list = new List<Bus_line>();
        }
     //**************************************    
        public IEnumerator GetEnumerator()
        {
            return Bus_line_list.GetEnumerator();
        }
        IEnumerator<Bus_line> IEnumerable<Bus_line>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
     //**************************************
        public void Add_bus_line(Bus_line add_bus )
        {
            if (add_bus != null )
               Bus_line_list.Add(add_bus);
            else// לזרוק שגיאה 
                
        }
     //*****************************************
        public void Remove_bus_line(Bus_line remove_bus)
        {
          Bus_line_list.Remove(remove_bus);
        }
     //*****************************************
     public List<Bus_line> List_lines_pass_station(int bus_code)
     {
        List<Bus_line> temp = new List<Bus_line>();
        foreach (Bus_line bus in Bus_line_list)
        {
           for (int i = 0; i < bus.Stations.Count; i++)
           {
              if (bus.Stations[i].MyCode == bus_code)
              {
                temp.Add(bus);
                i=bus.Stations.Count;
              }
           }
        }
            return temp;
     }
     //***************************************
     public List<Bus_line> Sort_bus_line()
     {
            return Bus_line_list.Sort();
     }
     //**************************************
     public Bus_line this[int code_bus]
     {
            get
            {
                return Bus_line_list[code_bus];
            }
            set
            {
                Bus_line_list[code_bus] = value;
            }

     }
    }
}
