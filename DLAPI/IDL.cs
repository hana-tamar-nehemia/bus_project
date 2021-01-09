using DO;
using System;
using System.Collections.Generic;

//using DO;

namespace DLAPI
{
    //CRUD Logic:
    // Create - add new instance
    // Request - ask for an instance or for a collection
    // Update - update properties of an instance
    // Delete - delete an instance
    public interface IDL
    {
        
        #region Bus Line
         DO.BusLine GetBusLine(int Bus_Id);

         IEnumerable<DO.BusLine> GetAllBusLine();

        IEnumerable<DO.BusLine> GetAllBusLineBy(Predicate<DO.BusLine> predicate);

        void AddBusLine(DO.BusLine BusLine);
        void UpdateBusLine(DO.BusLine BusLine);
        void UpdateBusLine(int Bus_Id, Action<DO.BusLine> update); //method that knows to updt specific fields 
        void DeleteBusLine(int Bus_Id);
        IEnumerable<object> GetBusListWithSelectedFields(Func<Bus, object> generate);
         
        #endregion

        #region BUS
        DO.Bus GetSBus(int License_num_Id);
        IEnumerable<DO.Bus> GetAllBuses();
        IEnumerable<object> GetBusListWithSelectedFields(Func<DO.Bus, object> generate);
        void AddBus(DO.Bus Bus);
        void UpdateFuelBus(DO.Bus Bus);
        //void UpdateFieldsBus(int License_num_Id, Action<DO.Bus> update); //method that knows to updt specific fields 
        void DeleteBus(int License_num_Id); // removes only Student, does not remove the appropriate Person...
        #endregion

        #region line station
        //get
        DO.LineStation GetLineStation(int code, DO.BusLine a);// מחזיר רשימת תחנות של קו מסויים
        IEnumerable<DO.LineStation> GetAllLineStations();//מחזיר רשימת כל התחנות קווים
        DO.Station GetStationOfLineStation(LineStation a);//מחזיר תחנה פיזית של תחנה לוגית
        IEnumerable<object> GetlinestationListWithSelectedFields(Func<DO.LineStation, object> generate);//מחזיר אובייקט חדש עם שדות נבחרים
        void AddLineStation(DO.LineStation linestation, DO.BusLine a);//להוסיף תחנת קו 
        void UpdateLineStation(DO.LineStation linestation);//עדכון תחנת קו שקיימת
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
        void AddAdjStation(int code, int code1);

        IEnumerable<DO.AdjStation> GetAdjStationListBy(Predicate<DO.AdjStation> predicate);
        //DO.AdjStation GetCode1(int Code);
        //DO.AdjStation GetCode2(int Code);
        //DO.AdjStation distace(int Code);
        //DO.AdjStation GetTimeBetween(int Code);
        void deledteAdjStation(int Code,int code1);
        void UpdateAdjStation(int Code ,int code1);

        #endregion

    }
}
