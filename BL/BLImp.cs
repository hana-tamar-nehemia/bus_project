using System;
using System.Collections.Generic;
using System.Linq;
using DLAPI;
using BLAPI;
using System.Threading;
using BO;

namespace BL
{
    class BLImp : IBL //internal
    {
        IDL dl = DLFactory.GetDL();
        #region Station

        BO.Station StationDoBoAdapter(DO.Station StationDO)//איך קוראים לכל האוטובוסים שעוברים בתחנה הפיזית? בהמרה לתחנה פיזית של בוו
        {
            BO.Station StationBO = new BO.Station();
            StationDO.CopyPropertiesTo(StationBO);
            //IEnumerable<DO.LineStation> linestations = dl.GetAllLineStationsby(line => line.Code == StationDO.Code);
            //StationBO.Collection_Lines = from ls in linestations//(busline => busline.Line_Id == StationDO.Code)//אטובוסים שקשורים לתחנה הזאת 
            //                            let busline = dl.GetBusLineBy(ls.Line_Id)
            //                          select BusLineDoBoAdapter(busline).CopyPropertiesToNew(BusLine)

            return StationBO;
        }
        //get
        public BO.Station GetStation(int code)//מקבל תחנה לפי קוד תחנה 
        {
            try
            {
                return StationDoBoAdapter(dl.GetStation(code));
            }
            catch (DO.BadStaionCodeException ex)
            {
                throw new BO.BadStationCodeException("station code does not exist or not acting", ex);
            }
        }
        public IEnumerable<BO.Station> GetAllStation()//מחזיר את כל התחנות
        {
            return from StationDO in dl.GetAllStation()
                   select StationDoBoAdapter(StationDO);//מוסיף גם את רשימת הקווים שעוברים בתחנה הזאת
        }

        public IEnumerable<BO.Station> GetAllstationsBy(Predicate<DO.Station> predicate)//מחזיר רשימת תחנות לפי פקדיקט מסוים
        {
            return from Station in dl.GetAllstationsBy(predicate)
                   select StationDoBoAdapter(Station);
        }
        public BO.Station GetstationsBy(Predicate<DO.Station> predicate)//מחזיר תחנה לפי פקדיקט מסוים
        {
            try
            {
                DO.Station stationDO = dl.GetstationsBy(predicate);
                return StationDoBoAdapter(stationDO);
            }
            catch (DO.BadStaionCodeException ex)
            {
                throw new BO.BadStationCodeException("station code does not exist or not acting", ex);
            }
        }
        //add
        public void AddStation(int Code, string Name, string Address, double Latitude, double longitude)//הוספת תחנה פיזית
        {
            DO.Station stationDO = new DO.Station() { Code = Code, Name = Name, Address = Address, Latitude = Latitude, longitude = longitude, Act = true };
            dl.AddStation(stationDO);
        }


        public void DeleteStation(int code)
        {
            DO.Station stationDO;
            stationDO = dl.GetStation(code);
            if (stationDO != null)
            {
                if (dl.GetAllLineStationsby(p => p.Code == code) == null)
                    dl.DeleteStation(code);
                else
                    throw new BO.BadStationCodeException(code, "the station cant remove");
            }
        }
        #endregion Station

        #region line station

        BO.LineStation LineStationDoBoAdapter(DO.LineStation LineStationDO)
        {
            BO.LineStation LineStationBO = new BO.LineStation();
            LineStationDO.CopyPropertiesTo(LineStationBO);
            DO.Station stationDO = dl.GetStation(LineStationDO.Code);
            stationDO.CopyPropertiesTo(LineStationBO);
          
            if (LineStationDO.Line_Station_Index > 1)
            {
                DO.LineStation prevls = dl.GetPrevLineStation(LineStationDO);
                DO.AdjStation a = dl.GetAdjStation(prevls.Code, LineStationDO.Code);
                LineStationBO.distance = a.Distance;
                LineStationBO.time = a.Time_Between;
            }
            else
            {
                LineStationBO.distance = 0;
                LineStationBO.time = new TimeSpan(0, 0, 0);
            }
            return LineStationBO;
        }
        //get
        public BO.LineStation GetLineStation(int code, int id_line)//תחנה לפי מספר רץ של קן מסןיים וקוד תחנה
        {
            DO.LineStation ls = dl.GetLineStation(code, id_line);
            return LineStationDoBoAdapter(ls);
        }
        public BO.Station GetStationOfLineStation(int code, int id_line)
        {

            return StationDoBoAdapter(dl.GetStationOfLineStation(code));
        }
        public IEnumerable<BO.LineStation> GetAllLineStationsOfBusLine(int id_line)// מחזיר רשימת תחנות של קו מסויים
        {
            return from linestation in dl.GetAllLineStations(id_line)
                   select LineStationDoBoAdapter(linestation);

        }
        public BO.LineStation GetPrevLineStation(BO.LineStation lineStation)
        {
            DO.LineStation a = new DO.LineStation();
            lineStation.CopyPropertiesTo(a);
            DO.LineStation ls = dl.GetPrevLineStation(a);
            if (ls != null && ls.ActLineStation == true)
                return LineStationDoBoAdapter(ls);
            else
                throw new DO.BadLineStationCodeException(lineStation.Line_Station_Index--, $"no found: {lineStation.Line_Station_Index--}");
        }
        //public IEnumerable<BO.LineStation> GetAllLineStations()// מחזיר רשימת תחנות של קו מסויים
        //{
        //    return from linestation in dl.GetAllLineStations()
        //           select LineStationDoBoAdapter(linestation);
        //}

        //add
        public void AddLineStation(int code, int Line_Id, int index, bool A)//להוסיף תחנת קו 
        {
            try
            {
                dl.AddLineStation(new DO.LineStation { Code = code, Line_Id = Line_Id, Line_Station_Index = index, ActLineStation = A});
            }
            catch (DO.BadStaionCodeException ex)
            {
                throw new BO.BadStationCodeException("line station is already exsist", ex);
            }
        }

        //delete
        public void DeleteLineStationInBus(int code, int line_id)
        {
            try
            {
                dl.DeleteLineStationInBus(code, line_id);
            }
            catch (DO.BadStaionCodeException ex)
            {
                throw new BO.BadStationCodeException("line station not exsist", ex);
            }
        }

        #endregion

        #region BUS
        public BO.Bus GetSBus(int License_num_Id)
        {
            DO.Bus BusDO;

            try
            {
                BusDO = dl.GetBus(License_num_Id);
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

        //public IEnumerable<BO.Bus> GetAllBusBy(Predicate<BO.Bus> predicate)
        //{
        //    return from Bus in dl.GetAllBusBy(predicate)
        //                              select BusDoBoAdapter(Bus);
        //}
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
                BusDO = dl.GetBus(id);
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
            catch (DO.BadBusLineException ex)
            {
                throw new BO.BadBusLineException("Bus line id does not exist or he is not acting", ex);
            }

        }
        public IEnumerable<BO.BusLine> GetAllBusLine()
        {
            return from item in dl.GetAllBusLine()
                   select BusLineDoBoAdapter(item);
        }

        //public IEnumerable<BO.BusLine> GetAllBusLineBy(Predicate<BO.BusLine> predicate)
        //{
        //    return from BusLine in dl.GetAllBusLineBy(predicate)
        //                                  select BusLineDoBoAdapter(BusLine));

        //}
        //****************************************************************
        //public void AddBusLine(int bus_id, int Line_Number, Areas Area, int First_Station, int Last_Station, IEnumerable<LineStation> ListLineStations, bool act, int Line_Id)
        //{
        //    try
        //    {
        //       dl.AddBusLine(bus_id, Line_Number, Area, First_Station, Last_Station, act, Line_Number);
        //      // DO.BusLine BusLinelDO = dl.GetBusLine(bus_id);
        //        //from li in ListLineStations
        //        //select dl.AddLineStation(s, BusLinelDO)
        //    }
        //    catch (DO.BadBusLineException ex)
        //    {
        //        throw new BO.BadBusLineException("Student ID and Course ID is Not exist", ex);
        //    }
        //}
        public void UpdateBusLine(BO.BusLine BusLine)
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
            try
            {
                BusDO = dl.GetBus(BusLineDO.Bus_Id);
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

        public void AddAdjStation(int code, int code1, int d, TimeSpan t, bool a)
        {
            try
            {
                dl.AddAdjStation(code, code1, d, t,a);

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
            return AdjStationBO;
        }
        #endregion

        #region user
        public void AddUserM(string name, string pa)
        {
            try
            {
                dl.AddUserm(name,pa);

            }
            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException(" uesr Not exist", ex);
            }
        }
        public void AddUserU(string name, string pa)
        {
            try
            {
                dl.AddUseru(name, pa);

            }
            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException(" uesr Not exist", ex);
            }
        }

        public bool UserExistsM(string name, string pa)
        {
            DO.User UserDO;

            try
            {
                UserDO = dl.GetUser( name,pa);
                if (UserDO.Admin==true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException("user  id does not exist ", ex);
            }
        }
        public bool UserExistsU(string name, string pa)
        {
            DO.User UserDO;

            try
            {
                UserDO = dl.GetUser(name, pa);
                if (UserDO.Admin == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
            }
            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException("user  id does not exist ", ex);
            }
        }
        BO.User UserDoBoAdapter(DO.User UserDO)
        {
            BO.User UserBO = new BO.User();

            string name = UserDO.User_name;
            string pa = UserDO.password;

            try
            {
                UserDO = dl.GetUser(name,pa);
            }
            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException("Bus ID is illegal", ex);
            }
            UserDO.CopyPropertiesTo(UserBO);
            return UserBO;
        }
        #endregion
    }
}
