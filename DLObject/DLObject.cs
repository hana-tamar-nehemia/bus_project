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
    sealed class DLObject : IDL    ///internall
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
                if (per.Act == true)
                    return per.Clone();
                else
                    throw new DO.BadStaionCodeException(code, $" station code: {code} no act");

            else
                throw new DO.BadStaionCodeException(code, $"bad station code: {code}");
        }
        public IEnumerable<DO.Station> GetAllStation()
        {
            return from Station in DataSource.List_Station
                   where (Station.Act == true)
                   select Station.Clone();
        }
        public IEnumerable<DO.Station> GetAllstationsBy(Predicate<DO.Station> predicate)
        {
            return from Station in DataSource.List_Station
                   where predicate(Station) && (Station.Act == true)
                   select Station.Clone();
            throw new NotImplementedException();
        }
        public DO.Station GetstationsBy(Predicate<DO.Station> predicate)
        {
            DO.Station a = DataSource.List_Station.Find(predicate);
            if (a.Act == true)
                return a.Clone();
            else
                throw new NotImplementedException();
        }
        //add
        public void AddStation(DO.Station station)
        {
            DO.Station a = DataSource.List_Station.FirstOrDefault(p => p.Code == station.Code);
            if (a != null && a.Act == true)
                throw new DO.BadStaionCodeException(station.Code, "the station already exsist");
            if (a != null && a.Act == false)
            {
                DataSource.List_Station.Remove(a);
                a.Act = true;
                DataSource.List_Station.Add(a.Clone());
            }
            if (a == null)
                DataSource.List_Station.Add(station.Clone());
        }
        //update
        public void UpdateStation(DO.Station station)//מעדכן 
        {
            DO.Station per = DataSource.List_Station.Find(p => p.Code == station.Code);

            if (per != null && per.Act == true)
            {
                DataSource.List_Station.Remove(per);
                per.Act = false;
                DataSource.List_Station.Add(per.Clone());
            }
            else
                            if (per != null && per.Act == false)
            {
                DataSource.List_Station.Remove(per);
                per.Act = true;
                DataSource.List_Station.Add(per.Clone());
            }

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
        public IEnumerable<DO.LineStation> GetAllLineStationsby(Predicate<DO.LineStation> predicate)//מחזיר רשימת תחנות של מסלול מסויים
        {
            return from linestation in DataSource.List_Line_Station
                   where predicate(linestation)
                   select linestation.Clone();
        }
        public DO.Station GetStationOfLineStation(int code)//תחנה פיזית של תחנה לוגית
        {
            DO.Station ls = DataSource.List_Station.Find(s => s.Code == code);
            if (ls != null)
                return ls.Clone();
            else
                throw new DO.BadLineStationCodeException(code, $"no found: {code}");
        }

        public DO.LineStation GetLineStation(int code, int line_id)
        {
            DO.LineStation ls = DataSource.List_Line_Station.Find(s => s.Code == code && s.Line_Id == line_id);
            if (ls != null)
                return ls.Clone();
            else
                throw new DO.BadLineStationCodeException(code, $"no found: {code}");
        }

        public IEnumerable<object> GetlinestationListWithSelectedFields(Func<DO.LineStation, object> generate)
        {
            return from linestation in DataSource.List_Line_Station
                   select generate(linestation);
        }
        //add
        //public void AddLineStation(int code, int Line_Id, int index)//להוסיף תחנת קו 
        //{
        //    if (DataSource.List_Line_Station.Find(s => s.Code == code && s.Line_Id == Line_Id && s.Line_Station_Index == index) != null)
        //        throw new DO.BadLineStationCodeException(code, "line station is already exsist");
        //    DataSource.List_Line_Station.Add(new DO.LineStation() { Line_Id=Line_Id , Code=code, Line_Station_Index = index });
        // }
        public void AddLineStation(DO.LineStation a)//להוסיף תחנת קו 
        {
            if (DataSource.List_Line_Station.Find(s => s.Code == a.Code && s.Line_Id == a.Line_Id && s.Line_Station_Index == a.Line_Station_Index) != null)
                throw new DO.BadLineStationCodeException(a.Code, "line station is already exsist");
            DataSource.List_Line_Station.Add(a);
            DataSource.List_Line_Station.Where(p => a.Line_Id == p.Line_Id && p.Line_Station_Index >= a.Line_Station_Index).Select(p => p.Line_Station_Index++);//אם לתחנה יש אותו מספר רץ כמו זאת שנוספה והאינדקס שלה גדול ממנה מעלים אינדקס
        }
        //update
        //public void UpdateLineStation(DO.LineStation linestation)
        //{
        //    DO.LineStation stu = DataSource.List_Line_Station.Find(p => p.Code == linestation.Code);
        //    if (stu != null)
        //    {
        //        DataSource.List_Line_Station.Remove(stu);
        //        DataSource.List_Line_Station.Add(stu.Clone());
        //    }
        //    else
        //        throw new DO.BadLineStationCodeException(linestation.Code, $"bad line station code: {linestation.Code}");
        //}

        //delete
        public void DeleteLineStationInBus(int code, int id_line)//מחיקת תחנה אחת מקו אחד
        {
            DO.LineStation s = DataSource.List_Line_Station.Find(p => p.Code == code && id_line == p.Line_Id);//התחנה למחיקה

            if (s != null)
            {
                int index = s.Line_Station_Index;//אינדקס לעדכון ממנו והלאה
                DataSource.List_Line_Station.Remove(s);// מחיקת תחנת קו וסידור האינדקסים של התחנות הבאות אחריו
                DataSource.List_Line_Station.Where(p => id_line == p.Line_Id && p.Line_Station_Index > index).Select(p => p.Line_Station_Index--);//אם לתחנה יש אותו מספר רץ כמו זאת שנמחקה והאינדקס שלה גדול ממנה מורידים אינדקס
            }
            else
                throw new DO.BadLineStationCodeException(code, $"bad line station code: {code}");
        }

        #endregion

        #region BUS
        public DO.Bus GetBus(int License_num_Id)
        {
            DO.Bus b = DataSource.List_Bus.Find(p => p.License_num == License_num_Id);

            if (b != null && b.ActBus == true)
                return b.Clone();
            else
                throw new DO.BadBusException(License_num_Id, $" bad bus: {License_num_Id}");
        }
        public IEnumerable<DO.Bus> GetAllBuses()
        {
            return from Bus in DataSource.List_Bus
                   where Bus.ActBus == true
                   select Bus.Clone();
        }
        public IEnumerable<DO.Bus> GetAllBusBy(Predicate<DO.Bus> predicate)
        {
            //Returns deferred query + clone:
            return from b in DataSource.List_Bus
                   where predicate(b) && b.ActBus == true
                   select b.Clone();
        }
        public void AddBus(int num, DateTime st, double k, double f, Bus_status status, bool a)
        {
            if (DataSource.List_Bus.FirstOrDefault(p => p.License_num == num) != null)
                throw new DO.BadBusException(num, "Duplicate bus license number ");
            DO.Bus b = new DO.Bus() { ActBus = a, Bus_status = (int)status, License_num = num, Start_date = st, Km = k, Fuel_tank = f };
            DataSource.List_Bus.Add(b.Clone());


        }

        public void UpdateFuelBus(DO.Bus Bus)
        {
            DO.Bus b = DataSource.List_Bus.Find(p => Bus.License_num == Bus.License_num);
            if (b != null && b.ActBus == true)
            {
                DataSource.List_Bus.Remove(b);
                DataSource.List_Bus.Add(b.Clone());
            }
            else
            {
                throw new DO.BadBusException(Bus.License_num, $"bad Bus license num: {Bus.License_num}");
            }
        }

        public void DeleteBus(int License_num_Id)
        {
            DO.Bus b = DataSource.List_Bus.Find(bus => bus.License_num == License_num_Id);

            if (b != null)
            {
                b.ActBus = false;
                DataSource.List_Bus.Remove(b);
                DataSource.List_Bus.Add(b);
            }
            else
                throw new DO.BadBusException(License_num_Id, $"bad bus license number: {License_num_Id}");
        }
        #endregion


        #region Bus Line

        public DO.BusLine GetBusLine(int Bus_Id)
        {
            DO.BusLine bl = DataSource.List_Bus_Line.Find(b => b.Bus_Id == Bus_Id);

            if (bl != null && bl.Act == true)
                return bl.Clone();
            else
                throw new DO.BadBusLineException(Bus_Id, $"bad bus line id: {Bus_Id}");
        }
        public IEnumerable<DO.BusLine> GetAllBusLine()
        {
            return from BusLine in DataSource.List_Bus_Line
                   where BusLine.Act == true
                   select BusLine.Clone();
        }
        public IEnumerable<DO.BusLine> GetAllBusLineBy(Predicate<DO.BusLine> predicate)
        {
            return (IEnumerable<BusLine>)(from BusLine in DataSource.List_Bus_Line
                                          where predicate(BusLine) && BusLine.Act == true
                                          select Station.Clone(BusLine));
            throw new NotImplementedException();
        }

        public DO.BusLine GetBusLineBy(int line_id)
        {
            return DataSource.List_Bus_Line.Find(p => p.Line_Id == line_id);
        }

        public void AddBusLine(int Bus_Id, int Line_Number, Areas Area, int First_Station, int Last_Station, bool act)
        {
            if (DataSource.List_Bus_Line.FirstOrDefault(b => b.Bus_Id == Bus_Id) != null)
                throw new DO.BadBusLineException(Bus_Id, "Duplicate bus line Id");
            BusLine bus = new BusLine() { Bus_Id = Bus_Id, Line_Number = Line_Number, Area = Area, First_Station = First_Station, Last_Station = Last_Station, Act = act };
            DataSource.List_Bus_Line.Add(bus.Clone());
        }
        public void UpdateBusLine(DO.BusLine BusLine)
        {
            BusLine bl = DataSource.List_Bus_Line.Find(p => p.Bus_Id == BusLine.Bus_Id);
            if (bl != null && bl.Act == true)
            {
                DataSource.List_Bus_Line.Remove(bl);
                DataSource.List_Bus_Line.Add(bl.Clone());
            }
            throw new BadBusLineException(BusLine.Bus_Id, "Duplicate bus line Id");
        }

        public void UpdateBusLine(int Bus_Id, Action<DO.BusLine> update) //method that knows to updt specific fields 
        {
            throw new NotImplementedException();
        }


        public void DeleteBusLine(int Bus_Id)
        {

            DO.BusLine bl = DataSource.List_Bus_Line.Find(b => b.Bus_Id == Bus_Id);

            if (bl != null)
            {
                bl.Act = false;
                DataSource.List_Bus_Line.Remove(bl);
                DataSource.List_Bus_Line.Add(bl.Clone());
            }
            else
                throw new DO.BadBusLineException(Bus_Id, $"bad bus line id: {Bus_Id}");
        }
        #endregion

        #region AdjStation

    public void AddAdjStation(int code, int code1, int d, TimeSpan t)
    {
        AdjStation adj = DataSource.List_Adjstation.Find(p => p.Code_station1 == code && p.Code_station2 == code1);
        if (adj == null)
        {
            throw new DO.BadBusAdjStationException(code, code1, "Duplicate Code station 1 and Code station 2");
        }
            AdjStation a = new AdjStation() { Code_station1 = code, Code_station2 = code1, Distance = d, Time_Between = t };
                       DataSource.List_Adjstation.Add(a.Clone());
    }
    public IEnumerable<DO.AdjStation> GetAdjStationListBy(Predicate<DO.AdjStation> predicate)
    {
        return (IEnumerable<AdjStation>)(from AdjStation in DataSource.List_Adjstation
                                         where predicate(AdjStation)
                                         select Station.Clone(AdjStation));
        throw new NotImplementedException();
    }
    public IEnumerable<DO.Bus> GetAllAdjStation()
    {
            return from Bus in DataSource.List_Bus
                   select Bus.Clone();
        }
        public void UpdateAdjStation(int code, int code1)
        {
            AdjStation adj = DataSource.List_Adjstation.Find(a => a.Code_station1 == code && a.Code_station2 == code1);
            if (adj != null)
            {
                DataSource.List_Adjstation.Remove(adj);
                DataSource.List_Adjstation.Add(adj.Clone());

            }
             throw new DO.BadBusAdjStationException(code, code1, "Duplicate Code station 1 and Code station 2");

    }
    public void deledteAdjStation(int code, int code1)
    {
        AdjStation adj = DataSource.List_Adjstation.Find(a => a.Code_station1 == code && a.Code_station2 == code1);
        if (adj != null)
        {
            DataSource.List_Adjstation.Remove(adj);
        }
        throw new DO.BadBusAdjStationException(code, code1, "Duplicate Code station 1 and Code station 2");
    }
    public DO.AdjStation GetAdjStation(int code, int code1)
    {
            DO.AdjStation a = DataSource.List_Adjstation.Find(p => p.Code_station1 == code&& p.Code_station2==code1);

            if (a != null)
                return a.Clone();
            else
                throw new DO.BadBusAdjStationException(code, code1, "Duplicate Code station 1 and Code station 2");
    }

        #endregion


    }
}