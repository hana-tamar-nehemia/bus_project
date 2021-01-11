using System;
using System.Collections.Generic;
using System.Linq;
using DLAPI;
using BLAPI;
using System.Threading;
using BO;
//using BO;

namespace BL
{
    class BLImp : IBL //internal
    {
        IDL dl = DLFactory.GetDL();
        #region Station
        BO.Station StationDoBoAdapter(DO.Station StationDO)
        {
            BO.Station StationBO = new BO.Station();
            StationDO.CopyPropertiesTo(StationBO);

            StationBO.Collection_Lines = from line in dl.GetAllBusLineBy(line => line.Bus_Id == StationDO.Code)
                                             //let station = dl.GetStation(line.Bus_Id)
                                         select (BO.Station)Station.CopyPropertiesToNew(typeof(BO.Station));
            return StationBO;
        }


        //get
        public BO.Station GetStation(int code)
        {
            DO.Station stationDO;
            BO.Station StationBO = new BO.Station();
            try
            {
                stationDO = dl.GetStation(code);
                return StationDoBoAdapter(stationDO);
            }
            catch (DO.BadStaionCodeException ex)
            {
                throw new BO.BadStationCodeException("station code does not exist or not acting", ex);
            }
        }
        public IEnumerable<BO.Station> GetAllStation()
        {
            return from StationDO in dl.GetAllStation()
                   select StationDoBoAdapter(StationDO);//מוסיף גם את רשימת הקווים שעוברים בתחנה הזאת
        }

        public IEnumerable<BO.Station> GetAllstationsBy(Predicate<DO.Station> predicate)
        {
            return from Station in GetAllstationsBy(predicate) select StationDoBoAdapter(Station);
        }
        //add
        public void AddStation(int Code, string Name, string Address, double Latitude, double longitude)
        {
            DO.Station stationDO = new DO.Station() { Code = Code, Name = Name, Address = Address, Latitude = Latitude, longitude = longitude, Act = true };
            dl.AddStation(stationDO);
        }
        //update
        public void UpdateStation()
        {
            //DO.Station per = DataSource.List_Station.Find(p => p.Code == station.Code);

            //if (per != null && per.Act == true)
            //{
            //    DataSource.List_Station.Remove(per);
            //    DataSource.List_Station.Add(per.Clone());
            //}
            //else
            //    throw new DO.BadStaionCodeException(station.Code, $"bad station code: {station.Code}");
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
        public BO.Bus GetSBus(int License_num_Id)
        {
            DO.Bus BusDO;

            try
            {
                BusDO = dl.GetSBus(License_num_Id);
                return BusDoBoAdapter(BusDO);
            }
            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException("Bus  id does not exist or he is not a acting ", ex);
            }

        }
        public IEnumerable<BO.Bus> GetAllBuses()
        {
            return from item in dl.GetAllBuses()
                   select BusDoBoAdapter(item);
        }

        public IEnumerable<BO.Bus> GetAllBusBy(Predicate<BO.Bus> predicate)
        {
            return (IEnumerable<Bus>)(from Bus in dl.GetAllBusBy((Predicate<DO.Bus>)predicate)
                                      select BusDoBoAdapter(Bus));

        }
        public void AddBus(int num, DateTime st, double k, double f, Bus_status status, bool a)
        {
            try
            {
                dl.AddBus(num, st, k, f, (DO.Bus_status)status, a);

            }
            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException(" Bus Not exist", ex);
            }
        }
        public void UpdateFuelBus(BO.Bus Bus)
        {

            DO.Bus BusDO = new DO.Bus();
            Bus.CopyPropertiesTo(BusDO);
            try
            {
                dl.UpdateFuelBus(BusDO);
            }
            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException("Bus  is illegal", ex);
            }
        }

        public void DeleteBus(int License_num_Id)
        {
            try
            {
                dl.DeleteBus(License_num_Id);

            }

            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException("Bus id does not exist ", ex);
            }
        }
        BO.Bus BusDoBoAdapter(DO.Bus BusDO)
        {
            BO.Bus BusBO = new BO.Bus();

            int id = BusDO.License_num;
            try
            {
                BusDO = dl.GetSBus(id);
            }
            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException("Bus ID is illegal", ex);
            }
            BusDO.CopyPropertiesTo(BusBO);
            //BusBO.License_num = BusDO.License_num;
            //BusBO.Bus_status = (Bus_status)BusDO.Bus_status;
            //BusBO.License_num = BusDO.License_num;
            //BusBO.Fuel_tank = BusDO.Fuel_tank;
            //BusBO.Km = BusDO.Km;
            //BusBO.Start_date = BusDO.Start_date;



            return BusBO;
        }
        #endregion

        #region Bus Line
        public BO.BusLine GetBusLine(int Bus_Id)
        {
            DO.BusLine BusLinelDO;

            try
            {
                BusLinelDO = dl.GetBusLine(Bus_Id);
                return BusLineDoBoAdapter(BusLinelDO);
            }
            catch (DO.BadBusLineCodeException ex)
            {
                throw new BO.BadBusLineCodeException("Bus line id does not exist or he is not acting", ex);
            }

        }
        public IEnumerable<BO.BusLine> GetAllBusLine()
        {
            return from item in dl.GetAllBusLine()
                   select BusLineDoBoAdapter(item);
        }

        public IEnumerable<BO.BusLine> GetAllBusLineBy(Predicate<BO.BusLine> predicate)
        {
            return (IEnumerable<BusLine>)(from BusLine in dl.GetAllBusLineBy((Predicate<DO.BusLine>)predicate)
                                          select BusLineDoBoAdapter(BusLine));

        }
        //****************************************************************
        public void AddBusLine(int bus_id, int Line_Number, Areas Area, int First_Station, int Last_Station, IEnumerable<LineStation> ListLineStations, bool act, int Line_Id)
        {
            try
            {
                //dl.AddBusLine(bus_id, Line_Number, Area, First_Station, Last_Station, act, Line_Number);
                //DO.BusLine BusLinelDO = dl.GetBusLine(bus_id);
                //from li in ListLineStations
                //select dl.AddLineStation(s, BusLinelDO)
            }
            catch (DO.BadBusLineException ex)
            {
                throw new BO.BadBusLineException("Student ID and Course ID is Not exist", ex);
            }
        }
        void UpdateBusLine(BO.BusLine BusLine)
        {
            DO.BusLine BusLineDO = new DO.BusLine();
            BusLine.CopyPropertiesTo(BusLineDO);
            try
            {
                dl.UpdateBusLine(BusLineDO);
            }
            catch (DO.BadBusLineException ex)
            {
                throw new BO.BadBusLineException("Bus line  ID is illegal", ex);
            }
        }
        public void DeleteBusLine(int Bus_Id)
        {
            try
            {
                dl.DeleteBusLine(Bus_Id);

            }

            catch (DO.BadBusLineException ex)
            {
                throw new BO.BadBusLineException("Bus line  id does not exist or he is not acting", ex);
            }
        }
        //************************************************************ 
        BO.BusLine BusLineDoBoAdapter(DO.BusLine BusLineDO)
        {
            BO.BusLine BusLineBO = new BO.BusLine();
            DO.Bus BusDO;
            int id = BusLineDO.Bus_Id;
            try
            {
                BusDO = dl.GetSBus(id);
            }
            catch (DO.BadBusLineException ex)
            {
                throw new BO.BadBusLineException("Student ID is illegal", ex);
            }
            BusDO.CopyPropertiesTo(BusLineBO);
            //BusLineBO.Bus_status = (Bus_status)BusDO.Bus_status;
            //BusLineBO.License_num = BusDO.License_num;
            //BusLineBO.Fuel_tank= BusDO.Fuel_tank;
            //BusLineBO.Km= BusDO.Km;
            //BusLineBO.Start_date = BusDO.Start_date;


            BusLineDO.CopyPropertiesTo(BusLineBO);
            //BusLineBO.Act = BusLineDO.Act;
            //BusLineBO.First_Station = BusLineDO.First_Station;
            //BusLineBO.Last_Station = BusLineDO.Last_Station;
            //BusLineBO.Line_Id = BusLineDO.Line_Id;
            //BusLineBO.Line_Number = BusLineDO.Line_Number;
            //BusLineBO.Area = (Areas)BusLineDO.Area;

            //********************************************************
            //BusLineBO.ListLineStations = from s in dl.GetAllLineStations()
            //                          let LineStations = dl.GetLineStation(s.Line_Id)
            //                          select LineStations.CopyToStudentCours
            return BusLineBO;
        }

        #endregion

        #region AdjStation

        public void AddAdjStation(int code, int code1, int d, DateTime t)
        {
            try
            {
                dl.AddAdjStation(code, code1, d, t);

            }
            catch (DO.BadAdjStationException ex)
            {
                throw new BO.BadAdjStationException(" AdjStation Not exist", ex);
            }

        }
        public IEnumerable<BO.AdjStation> GetAdjStationListBy(Predicate<BO.AdjStation> predicate)
        {
            return (IEnumerable<AdjStation>)(IEnumerable<BusLine>)(from AdjStation in dl.GetAdjStationListBy((Predicate<DO.AdjStation>)predicate)
                                          select AdjStationDoBoAdapter(AdjStation));
        }
        public void UpdateAdjStation(int code, int code1)
        {
            try
            {
                dl.UpdateAdjStation(code, code1);
            }
            catch (DO.BadAdjStationException ex)
            {
                throw new BO.BadAdjStationException("AdjStation  ID is illegal", ex);
            }
        }
        public void deledteAdjStation(int code, int code1)
        {
            try
            {
                dl.deledteAdjStation(code, code1);
            }
            catch (DO.BadAdjStationException ex)
            {
                throw new BO.BadAdjStationException("AdjStation  ID is illegal", ex);
            }
        }
        BO.AdjStation AdjStationDoBoAdapter(DO.AdjStation AdjStationDO)
        {
            BO.AdjStation AdjStationBO = new BO.AdjStation();
            int code = AdjStationDO.Code_station1;
            int code1 = AdjStationDO.Code_station2;
            try
            {
                AdjStationDO = dl.GetAdjStation(code, code1);
            }
            catch (DO.BadAdjStationException ex)
            {
                throw new BO.BadAdjStationException("AdjStation ID is illegal", ex);
            }
            AdjStationDO.CopyPropertiesTo(AdjStationBO);
        }
            #endregion
    }
}
