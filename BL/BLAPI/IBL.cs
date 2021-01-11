using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BO;


namespace BLAPI
{
    public interface IBL
    {


        #region Bus Line
        BO.BusLine GetBusLine(int Bus_Id);

        IEnumerable<BO.BusLine> GetAllBusLine();
        IEnumerable<BO.BusLine> GetAllBusLineBy(Predicate<BO.BusLine> predicate);
        void AddBusLine(int bus_id, int Line_Number, BO.Areas Area, int First_Station, int Last_Station, IEnumerable<BO.LineStation> ListLineStations, bool act, int Line_Id);
        void UpdateBusLine(BO.BusLine BusLine);
        void DeleteBusLine(int Bus_Id);
        BO.BusLine BusLineDoBoAdapter(DO.BusLine BusLineDO);


        #endregion

        #region BUS
        BO.Bus GetSBus(int License_num_Id);
        IEnumerable<BO.Bus> GetAllBuses();
        IEnumerable<BO.Bus> GetAllBusBy(Predicate<BO.Bus> predicate);
        void AddBus(int num, DateTime st, double k, double f, Bus_status status, bool a);
        void UpdateFuelBus(BO.Bus Bus);
        void DeleteBus(int License_num_Id);

        BO.Bus BusDoBoAdapter(DO.Bus BusDO);
        #endregion

        #region line station
        //get
        DO.LineStation GetLineStation(int code, DO.BusLine a);// מחזיר רשימת תחנות של קו מסויים
        IEnumerable<DO.LineStation> GetAllLineStations();//מחזיר רשימת כל התחנות קווים
        DO.Station GetStationOfLineStation(LineStation a);//מחזיר תחנה פיזית של תחנה לוגית
        IEnumerable<object> GetlinestationListWithSelectedFields(Func<DO.LineStation, object> generate);//מחזיר אובייקט חדש עם שדות נבחרים
        void AddLineStation(DO.LineStation linestation, DO.BusLine a);//להוסיף תחנת קו 
        //void UpdateLineStation(DO.LineStation linestation);//עדכון תחנת קו שקיימת
        void DeleteLineStation(int code, BusLine a);//מחיקת תחנת קו וסידור התחנות הבאות אחריה

        #endregion

        #region STATION
        // get
        DO.Station GetStation(int code);//מחזיר תחנת אוטובוס פיזית
        IEnumerable<DO.Station> GetAllStation();//מחזיר רשימת תחנות אוטובוס 
        IEnumerable<DO.Station> GetAllstationsBy(Predicate<DO.Station> predicate);//מחזיר רשימת תחנות אטטובוס לפי פרדיקט
        //add
        void AddStation(DO.Station station);//מוסיף תחנה פיזית
        //update
        void UpdateStation(DO.Station station);//מעדכן תחנה קיימת

        #endregion

        #region AdjStation

        void AddAdjStation(int code, int code1, int d, DateTime t);
        IEnumerable<BO.AdjStation> GetAdjStationListBy(Predicate<BO.AdjStation> predicate);
        void UpdateAdjStation(int code, int code1);
        void deledteAdjStation(int code, int code1);
        BO.AdjStation AdjStationDoBoAdapter(DO.AdjStation AdjStationDO);

        #endregion





    }
}
