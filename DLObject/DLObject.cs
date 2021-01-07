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
    sealed class DLObject : IDL    //internal

    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion

        //Implement IDL methods, CRUD
        #region Station
        public DO.Station GetStation(int code)
        {
            DO.Station per = DataSource.List_Station.Find(p => p.Code == code);

            if (per != null)
                return per.Clone();
            else
                throw new DO.BadPersonIdException(code, $"bad station code: {code}");
        }
        public IEnumerable<DO.Station> GetAllStation()
        {
            return from Station in DataSource.List_Station
                   select Station.Clone();
        }
        public IEnumerable<DO.Station> GetAllstationsBy(Predicate<DO.Station> predicate)
        {
            return from Station in DataSource.List_Station
                   where predicate(Station)
                   select Station.Clone();
            throw new NotImplementedException();
        }

        public void AddStation(DO.Station station)
        {
            if (DataSource.List_Station.FirstOrDefault(p => p.Code == station.Code) != null)
                throw new DO.BadPersonIdException(station.Code, "Duplicate station code");
            DataSource.List_Station.Add(station.Clone());
        }

        //public void DeleteStation(int code)
        //{
        //    DO.Station per = DataSource.List_Station.Find(p => p.Code == code);
        //    if (per != null)
        //    {
        //        per.Act = false;
        //        DataSource.List_Station.(per);
        //    }
        //    else
        //        throw new DO.BadPersonIdException(code, $"bad station code: {code}");
        //}

        public void UpdateStation(DO.Station station)
        {
            DO.Station per = DataSource.List_Station.Find(p => p.Code == station.Code);

            if (per != null)
            {
                DataSource.List_Station.Remove(per);
                DataSource.List_Station.Add(per.Clone());
            }
            else
                throw new DO.BadPersonIdException(station.Code, $"bad station code: {station.Code}");
        }

        public void UpdateStation2(int code, Action<DO.Station> update)
        {
            throw new NotImplementedException();
        }
        #endregion Station

        #region line station
        public DO.LineStation GetLneStation(int code, DO.BusLine a)//תחנה של קו מסויים
        {
            DO.LineStation s = DataSource.List_Line_Station.Find(p => p.Code == code && a.Bus_Id == p.Line_Id);
            if (s != null)
                return s.Clone();
            else
                throw new DO.BadPersonIdException(code, $"no found: {code}");
        }
        public void AddLineStation(DO.LineStation linestation, DO.BusLine a)//להוסיף תחנה לקו מסויים
        {
            if (DataSource.List_Line_Station.FirstOrDefault(s => s.Code == linestation.Code && a.Line_Id == s.Line_Id) != null)
                throw new DO.BadPersonIdException(linestation.Code, "Duplicate line station code");
            if (DataSource.List_Line_Station.FirstOrDefault(p => p.Code == linestation.Code && a.Line_Id == p.Line_Id) == null)
                throw new DO.BadPersonIdException(linestation.Code, "Missing line station code");
            DataSource.List_Line_Station.Add(linestation.Clone());
        }
        public IEnumerable<DO.LineStation> GetAllLineStations()
        {
            return from linestation in DataSource.List_Line_Station
                   select linestation.Clone();
        }
        //public IEnumerable<object> GetLineStationFields(Func<int, object> generate)
        //{
        //    return from linestation in DataSource.List_Line_Station
        //           select generate(linestation.Code, GetStation(linestation.Code));
        //}

        public DO.Station GetStationOfLineStation(LineStation a)
        {
            return DataSource.List_Station.Find(s => s.Code == a.Code);
        }

        public IEnumerable<object> GetlinestationListWithSelectedFields(Func<DO.LineStation, object> generate)
        {
            return from linestation in DataSource.List_Line_Station
                   select generate(linestation);
        }
        public void UpdateLineStation(DO.LineStation linestation)
        {
            DO.LineStation stu = DataSource.List_Line_Station.Find(p => p.Code == linestation.Code);
            if (stu != null)
            {
                DataSource.List_Line_Station.Remove(stu);
                DataSource.List_Line_Station.Add(stu.Clone());
            }
            else
                throw new DO.BadPersonIdException(linestation.Code, $"bad line station code: {linestation.Code}");
        }

        public void UpdateLineStation(int code, Action<DO.LineStation> update)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineStation(int code, BusLine a)
        {
            DO.LineStation s = DataSource.List_Line_Station.Find(p => p.Code == code && a.Bus_Id == p.Line_Id);

            if (s != null)
            {
                int index = s.Line_Station_Index;
                DataSource.List_Line_Station.Remove(s);
                DataSource.List_Line_Station.Where(p => p.Code == code && a.Bus_Id == p.Line_Id && p.Line_Station_Index > index).Select(p => p.Line_Station_Index++);
            }
            else
                throw new DO.BadPersonIdException(code, $"bad line station code: {code}");
        }
        #endregion

        #region BUS
        public DO.Bus GetSBus(int License_num_Id)
        {
            DO.Bus b = DataSource.List_Bus.Find(p => p.License_num == License_num_Id);

            if (b != null)
                return b.Clone();
            else
                throw new DO.BadPersonIdException(License_num_Id, $" bad bus: {License_num_Id}");
        }
        public IEnumerable<DO.Bus> GetAllBuses()
        {
            return from Bus in DataSource.List_Bus
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
                   where predicate(b)
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
            if (b != null)
            {
                DataSource.List_Bus.Remove(b);
                DataSource.List_Bus.Add(b.Clone());
            }
            else
                throw new DO.BadPersonIdException(Bus.License_num, $"bad Bus license num: {Bus.License_num}");
        }
        public void UpdateFieldsBus(int License_num_Id, Action<DO.Bus> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteBus(int License_num_Id)
        {
            DO.Bus b = DataSource.List_Bus.Find(bus => bus.License_num  == License_num_Id);

            if (b != null)
            {
                DataSource.List_Bus.Remove(b);
            }
            else
                throw new DO.BadPersonIdException(License_num_Id, $"bad bus license number: {License_num_Id}");
        }
        #endregion

        #region Bus Line
        public DO.BusLine GetBusLine(int Bus_Id)
        {
            DO.BusLine bl = DataSource.List_Bus_Line.Find(b => b.Bus_Id == Bus_Id);

            if (bl != null)
                return bl.Clone();
            else
                throw new DO.BadPersonIdException(Bus_Id, $"bad bus line id: {Bus_Id}");
        }
        public IEnumerable<DO.BusLine> GetAllBusLine()
        {
            return from BusLine in DataSource.List_Bus_Line
                   select BusLine.Clone();
        }
        public IEnumerable<DO.BusLine> GetAllBusLineBy(Predicate<DO.BusLine> predicate)
        {
            throw new NotImplementedException();
        }
        public void AddBusLine(DO.BusLine BusLine)
        {
            if (DataSource.List_Bus_Line.FirstOrDefault(b => b.Bus_Id == BusLine.Bus_Id) != null)
                throw new DO.BadPersonIdException(BusLine.Bus_Id, "Duplicate bus line Id");
            DataSource.List_Bus_Line.Add(BusLine.Clone());
        }
       //void UpdateBusLine(DO.BusLine BusLine);
       public void UpdateBusLine(int line_id, Action<DO.BusLine> update) //method that knows to updt specific fields 
       {
            throw new NotImplementedException();
       }
        //void UpdateBusBusLine(int Bus_Id);

        public void DeleteBusLine( int Line_Id)
        {

            DO.BusLine bl = DataSource.List_Bus_Line.Find(b=> b.Line_Id == Line_Id );

            if (bl != null)
            {
                //UpdateBusLine(Line_Id, DO.BusLine.Act);
                //var a = from Line_Station in DataSource.List_Line_Station;
                //Where(Line_Station.Line_Id == Line_Id)
                //Select DataSource.List_Line_Station.Remove(Line_Station)
            }
            else
                throw new DO.BadPersonIdException(Line_Id, $"bad bus line id: {Line_Id}");
        }

        public void UpdateBusLine(BusLine BusLine)
        {
            throw new NotImplementedException();
        }

        public void UpdateBusBusLine(int Bus_Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetBusListWithSelectedFields(Func<Bus, object> generate)
        {
            throw new NotImplementedException();
        }

       
        
        #endregion

        #region AdjStation
        //void AddAdjStation(int code, int code1);
        //public void AddAdjStation(int code, int code1)
        //{
        //    if (DataSource.List_Adjstation.FirstOrDefault(a => a.Code_station1 == code&& b=> b.Code_station2 == code1) != null)
        //        throw new DO.BadPersonIdException(person.ID, "Duplicate person ID");
        //    DataSource.List_Adjstation.Add(ad.Clone());
        //}
        //IEnumerable<DO.AdjStation> GetLecturersInCourseList(Predicate<DO.AdjStation> predicate);
        ////DO.AdjStation GetCode1(int Code);
        ////DO.AdjStation GetCode2(int Code);
        ////DO.AdjStation distace(int Code);
        ////DO.AdjStation GetTimeBetween(int Code);
        //DO.AdjStation deledteAdjStation(int Code)
        //{

        //}
        public void AddAdjStation(int code, int code1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdjStation> GetLecturersInCourseList(Predicate<AdjStation> predicate)
        {
            throw new NotImplementedException();
        }

        public AdjStation GetCode1(int Code)
        {
            throw new NotImplementedException();
        }

        public AdjStation GetCode2(int Code)
        {
            throw new NotImplementedException();
        }

        public AdjStation distace(int Code)
        {
            throw new NotImplementedException();
        }

        public AdjStation GetTimeBetween(int Code)
        {
            throw new NotImplementedException();
        }

        public AdjStation deledteAdjStation(int Code)
        {
            throw new NotImplementedException();
        }
        #endregion




    }
}