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
         DO.BusLine GetBusLineBy(int line_id);
         IEnumerable<DO.BusLine> GetAllBusLine();

        IEnumerable<DO.BusLine> GetAllBusLineBy(Predicate<DO.BusLine> predicate);

        void AddBusLine(int Bus_Id, int Line_Number, Areas area, Areas Area, int First_Station, int Last_Station,   bool act);
        void UpdateBusLine(DO.BusLine BusLine);
        void UpdateBusLine(int Bus_Id, Action<DO.BusLine> update); //method that knows to updt specific fields 
        void DeleteBusLine(int Bus_Id);
        IEnumerable<object> GetBusListWithSelectedFields(Func<Bus, object> generate);
         
        #endregion

        #region BUS
        DO.Bus GetBus(int License_num_Id);
        IEnumerable<DO.Bus> GetAllBuses();
        //IEnumerable<object> GetBusListWithSelectedFields(Func<DO.Bus, object> generate);
        IEnumerable<DO.Bus> GetAllBusBy(Predicate<DO.Bus> predicate);
        void AddBus(int num, DateTime st, double k, double f, Bus_status status, bool a);
        void UpdateFuelBus(DO.Bus Bus);
        //void UpdateFieldsBus(int License_num_Id, Action<DO.Bus> update); //method that knows to updt specific fields 
        void DeleteBus(int License_num_Id); // removes only Student, does not remove the appropriate Person...
        #endregion

        #region line station
        //get
        DO.LineStation GetLineStation(int code, int line_id);
        DO.LineStation GetLineStation(int code, DO.BusLine a);// מחזיר רשימת תחנות של קו מסויים
        IEnumerable<DO.LineStation> GetAllLineStations();//מחזיר רשימת כל התחנות קווים
        IEnumerable<DO.LineStation> GetAllLineStationsby(Predicate<DO.LineStation> predicate);//מחזיר רשימת תחנות של מסלול מסויים

        DO.Station GetStationOfLineStation(int a);//מחזיר תחנה פיזית של תחנה לוגית
        IEnumerable<object> GetlinestationListWithSelectedFields(Func<DO.LineStation, object> generate);//מחזיר אובייקט חדש עם שדות נבחרים
                                                                                                        //   void AddLineStation(int code, int Line_Id, int index);//להוסיף תחנת קו 
        void AddLineStation(DO.LineStation a);//להוסיף תחנת קו 

       // void UpdateLineStation(DO.LineStation linestation);//עדכון תחנת קו שקיימת
        void DeleteLineStationInBus(int code, int line_id);//מחיקת תחנת קו אחת מקו וסידור התחנות הבאות אחריה
        void DeleteLineStation(int code);//מחיקת תחנת קו מהרשימה וקיצור מסלולים שבה הייתה קיימת
        #endregion

        #region STATION
        // get
        DO.Station GetStation(int code);//מחזיר תחנת אוטובוס פיזית
        IEnumerable<DO.Station> GetAllStation();//מחזיר רשימת תחנות אוטובוס 
        IEnumerable<DO.Station> GetAllstationsBy(Predicate<DO.Station> predicate);//מחזיר רשימת תחנות אטטובוס לפי פרדיקט
        DO.Station GetstationsBy(Predicate<DO.Station> predicate);

        //add
        void AddStation(DO.Station station);//מוסיף תחנה פיזית
        //update
        void UpdateStation(DO.Station station);//מעדכן תחנה קיימת
        void DeleteStation(int a);//תחנה לא תהיה פעילה


        #endregion

        #region AdjStation
        void AddAdjStation(int code, int code1,int d, TimeSpan t);
        IEnumerable<DO.BusLine> GetAllAdjStation();
        IEnumerable<DO.AdjStation> GetAdjStationListBy(Predicate<DO.AdjStation> predicate);
        DO.AdjStation GetAdjStation(int code, int code1);
        void deledteAdjStation(int Code,int code1);
        void UpdateAdjStation(int Code ,int code1);
         
        
        #endregion

    }
}
