using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DLAPI;
using DO;
 using DS;
namespace DL
{
    sealed class DLObject : IDL    //internall

    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion

        //Implement IDL methods, CRUD
        #region Station
        //get
        public DO.Station GetStation(int code)
        {
            DO.Station per = DataSource.List_Station.Find(p => p.Code == code);

            if (per != null)
                if(per.Act==true)
                return per.Clone();
            else
                    throw new DO.BadStaionCodeException(code, $" station code: {code} no act");

            else
                throw new DO.BadStaionCodeException(code, $"bad station code: {code}");
        }
        public IEnumerable<DO.Station> GetAllStation()
        {
            return from Station in DataSource.List_Station
                   where (Station.Act==true)
                   select Station.Clone();
        }
        public IEnumerable<DO.Station> GetAllstationsBy(Predicate<DO.Station> predicate)
        {
            return from Station in DataSource.List_Station
                   where predicate(Station) && (Station.Act==true)
                   select Station.Clone();
            throw new NotImplementedException();
        }
        //add
        public void AddStation(DO.Station station)
        {
            DO.Station a = DataSource.List_Station.FirstOrDefault(p => p.Code == station.Code);
            if(a != null && a.Act==true)
                throw new DO.BadStaionCodeException(station.Code, "the station already exsist");
            if (a != null && a.Act == false)
            {
                DataSource.List_Station.Remove(a);
                a.Act = true;
                DataSource.List_Station.Add(a.Clone());
            }
            if(a==null)
            DataSource.List_Station.Add(station.Clone());
        }
        //update
        public void UpdateStation(DO.Station station)
        {
            DO.Station per = DataSource.List_Station.Find(p => p.Code == station.Code);

            if (per != null && per.Act==true)
            {
                DataSource.List_Station.Remove(per);
                DataSource.List_Station.Add(per.Clone());
            }
            else
                throw new DO.BadStaionCodeException(station.Code, $"bad station code: {station.Code}");
        }

        public void DeleteStation(int code)
        {
            DO.Station per = DataSource.List_Station.Find(p => p.Code == code);
            if (per != null)
            {
                DataSource.List_Station.Remove(per);
                per.Act = false;
                DataSource.List_Station.Add(per.Clone());
            }
            else
                throw new DO.BadStaionCodeException(code, $"bad station code: {code}");
        }
        #endregion Station

        #region line station
        //get
        public DO.LineStation GetLineStation(int code, DO.BusLine a)//תחנה של קו מסויים
        {
            DO.LineStation s = DataSource.List_Line_Station.Find(p => p.Code == code && a.Bus_Id == p.Line_Id);
            if (s != null)
                return s.Clone();
            else
                throw new DO.BadLineStationCodeException(code, $"no found: {code}");
        }
        public IEnumerable<DO.LineStation> GetAllLineStations()
        {
            return from linestation in DataSource.List_Line_Station
                   select linestation.Clone();
        }
        public DO.Station GetStationOfLineStation(LineStation a)
        {
            return DataSource.List_Station.Find(s => s.Code == a.Code);
        }

        public IEnumerable<object> GetlinestationListWithSelectedFields(Func<DO.LineStation, object> generate)
        {
            return from linestation in DataSource.List_Line_Station
                   select generate(linestation);
        }
        //add
        public void AddLineStation(DO.LineStation linestation, DO.BusLine a)//להוסיף תחנת קו 
        {
            if (DataSource.List_Line_Station.FirstOrDefault(s => s.Code == linestation.Code && a.Line_Id == s.Line_Id) != null)
                throw new DO.BadLineStationCodeException(linestation.Code, "line station is already exsist");
            DataSource.List_Line_Station.Add(linestation.Clone());
        }
      //update
        public void UpdateLineStation(DO.LineStation linestation)
        {
            DO.LineStation stu = DataSource.List_Line_Station.Find(p => p.Code == linestation.Code);
            if (stu != null)
            {
                DataSource.List_Line_Station.Remove(stu);
                DataSource.List_Line_Station.Add(stu.Clone());
            }
            else
                throw new DO.BadLineStationCodeException(linestation.Code, $"bad line station code: {linestation.Code}");
        }

        //delete
        public void DeleteLineStation(int code, BusLine a)
        {
            DO.LineStation s = DataSource.List_Line_Station.Find(p => p.Code == code && a.Bus_Id == p.Line_Id);

            if (s != null)
            {
                int index = s.Line_Station_Index;
                DataSource.List_Line_Station.Remove(s);// מחיקת תחנת קו וסידור האינדקסים של התחנות הבאות אחריו
                DataSource.List_Line_Station.Where(p => p.Code == code && a.Bus_Id == p.Line_Id && p.Line_Station_Index > index).Select(p => p.Line_Station_Index++);
            }
            else
                throw new DO.BadLineStationCodeException(code, $"bad line station code: {code}");
        }
        //public IEnumerable<object> GetLineStationFields(Func<int, object> generate)
        //{
        //    return from linestation in DataSource.List_Line_Station
        //           select generate(linestation.Code, GetStation(linestation.Code));
        //}
        #endregion

        #region BUS
        public DO.Bus GetSBus(int License_num_Id)
        {
            DO.Bus b = DataSource.List_Bus.Find(p => p.License_num == License_num_Id);

            if (b != null && b.Act==true)
                return b.Clone();
            else
                throw new DO.BadPersonIdException(License_num_Id, $" bad bus: {License_num_Id}");
        }
        public IEnumerable<DO.Bus> GetAllBuses()
        {
            return from Bus in DataSource.List_Bus
                   where Bus.Act==true
                   select Bus.Clone();
        }
        //public IEnumerable<object> GetBusListWithSelectedFields(Func<DO.Bus, object> generate)
        //{
        //    return from Bus in DataSource.List_Bus
        //           select generate(Bus., GetPerson(student.ID).Name);
        //}
        public IEnumerable<object> GetBusListWithSelectedFields(Predicate<DO.Bus> predicate)
        {
            //Returns deferred query + clone:
            return from b in DataSource.List_Bus
                   where predicate(b) && b.Act == true
                   select b.Clone();
        }
        public void AddBus(DO.Bus Bus)
        {
            if (DataSource.List_Bus.FirstOrDefault(p => Bus.License_num == Bus.License_num) != null)
                throw new DO.BadPersonIdException(Bus.License_num, "Duplicate bus license number ");
            DataSource.List_Bus .Add(Bus.Clone());
        }
        public void UpdateFuelBus(DO.Bus Bus)
        {
            DO.Bus b = DataSource.List_Bus.Find(p => Bus.License_num == Bus.License_num);
            if (b != null&& b.Act==true)
            {
                DataSource.List_Bus.Remove(b);
                DataSource.List_Bus.Add(b.Clone());
            }
            else
                throw new DO.BadPersonIdException(Bus.License_num, $"bad Bus license num: {Bus.License_num}");
        }
       
        public void DeleteBus(int License_num_Id)
        {
            DO.Bus b = DataSource.List_Bus.Find(bus => bus.License_num  == License_num_Id);

            if (b != null)
            {
                b.Act = false;
                DataSource.List_Bus.Remove(b);
                DataSource.List_Bus.Add(b);
            }
            else
                throw new DO.BadPersonIdException(License_num_Id, $"bad bus license number: {License_num_Id}");
        }
        #endregion

        #region Bus Line
        public DO.BusLine GetBusLine(int Bus_Id)
        {
            DO.BusLine bl = DataSource.List_Bus_Line.Find(b => b.Bus_Id == Bus_Id);

            if (bl != null && bl.Act == true)
                return bl.Clone();
            else
                throw new DO.BadPersonIdException(Bus_Id, $"bad bus line id: {Bus_Id}");
        }
        public IEnumerable<DO.BusLine> GetAllBusLine()
        {
            return from BusLine in DataSource.List_Bus_Line
                   where BusLine.Act== true
                   select BusLine.Clone();
        }
        public IEnumerable<DO.BusLine> GetAllBusLineBy(Predicate<DO.BusLine> predicate)
        {
            return (IEnumerable<BusLine>)(from BusLine in DataSource.List_Bus_Line
                                             where predicate(BusLine) && BusLine.Act==true
                                          select Station.Clone(BusLine));
            throw new NotImplementedException();
        }
        public void AddBusLine(DO.BusLine BusLine)
        {
            if (DataSource.List_Bus_Line.FirstOrDefault(b => b.Bus_Id == BusLine.Bus_Id) != null)
                throw new DO.BadPersonIdException(BusLine.Bus_Id, "Duplicate bus line Id");
            DataSource.List_Bus_Line.Add(BusLine.Clone());
        }
       void UpdateBusLine(DO.BusLine BusLine)
        {
            BusLine bl= DataSource.List_Bus_Line.Find(p => p.Bus_Id == BusLine.Bus_Id);
            if (bl != null && bl.Act==true)
            {
                DataSource.List_Bus_Line.Remove(bl);
                DataSource.List_Bus_Line.Add(bl.Clone());
            }
            throw new BadPersonIdException(BusLine.Bus_Id, "Duplicate bus line Id");
        }

       public void UpdateBusLine(int Bus_Id, Action<DO.BusLine> update) //method that knows to updt specific fields 
       {
            throw new NotImplementedException();
       }
         

        public void DeleteBusLine( int Bus_Id)
        {

            DO.BusLine bl = DataSource.List_Bus_Line.Find(b=> b.Bus_Id == Bus_Id);

            if (bl != null)
            {
                bl.Act = false;
                DataSource.List_Bus_Line.Remove(bl);
                DataSource.List_Bus_Line.Add(bl.Clone());
            }
            else
                throw new DO.BadPersonIdException(Bus_Id, $"bad bus line id: {Bus_Id}");
        }

         
        public IEnumerable<object> GetBusListWithSelectedFields(Func<Bus, object> generate)
        {
            throw new NotImplementedException();
        }

       
        
        #endregion

        #region AdjStation
         
        public void AddAdjStation(int code, int code1)
        {
            AdjStation adj = DataSource.List_Adjstation.Find(a => a.Code_station1 == code && a.Code_station2 == code1);
            if (adj == null)
            {
                throw new DO.BadPersonIdException(AdjStation.Code_station1, AdjStation.Code_station2, "Duplicate Code station 1 and Code station 2");
            }
            DataSource.List_Adjstation.Add(adj.Clone());
        }
        public IEnumerable<DO.AdjStation> GetAdjStationListBy(Predicate<DO.AdjStation> predicate)
        {
            return (IEnumerable<AdjStation>)(from AdjStation in DataSource.List_Adjstation
                   where predicate(AdjStation)
                   select Station.Clone(AdjStation));
            throw new NotImplementedException();
        }
        public DO.AdjStation UpdateAdjStation(int code , int code1)
        {
            AdjStation adj = DataSource.List_Adjstation.Find(a => a.Code_station1 == code && a.Code_station2 == code1);
            if (adj != null)
            {
                DataSource.List_Adjstation.Remove(adj);
                DataSource.List_Adjstation.Add(adj.Clone());
                 
            }
            throw new DO.BadPersonIdException(AdjStation.Code_station1, AdjStation.Code_station2, "Duplicate Code station 1 and Code station 2");

        }
        DO.AdjStation deledteAdjStation(int code, int code1)
        {
            AdjStation adj = DataSource.List_Adjstation.Find(a => a.Code_station1 == code && a.Code_station2 == code1);
            if (adj != null)
            {
                DataSource.List_Adjstation.Remove(adj);
             }
            throw new DO.BadPersonIdException(AdjStation.Code_station1, AdjStation.Code_station2, "Duplicate Code station 1 and Code station 2");
        }

        #endregion



    }
}