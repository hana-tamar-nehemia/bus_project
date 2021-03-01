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
        int GEt_Line_Id();
        DO.BusLine GetBusLine(int Bus_Id);
         DO.BusLine GetBusLineBy(int line_id);
         IEnumerable<DO.BusLine> GetAllBusLine();

        // IEnumerable<DO.BusLine> GetAllBusLineBy(Predicate<DO.BusLine> predicate);
        
         void AddBusLine(DO.BusLine BusLine);
        void UpdateBusLine(DO.BusLine BusLine);
        void UpdateBusLine(int Bus_Id, Action<DO.BusLine> update); //method that knows to updt specific fields 
        void DeleteBusLine(int Bus_Id);
        //IEnumerable<object> GetBusListWithSelectedFields(Func<Bus, object> generate);
         
        #endregion

        #region BUS
        DO.Bus GetBus(int License_num_Id);
        IEnumerable<DO.Bus> GetAllBuses();
        //IEnumerable<object> GetBusListWithSelectedFields(Func<DO.Bus, object> generate);
        IEnumerable<DO.Bus> GetAllBusBy(Predicate<DO.Bus> predicate);
        void AddBus(int num, DateTime st, double k, double f, Bus_status status, bool a);
        void UpdateBus(DO.Bus Bus);
        //void UpdateFieldsBus(int License_num_Id, Action<DO.Bus> update); //method that knows to updt specific fields 
        void DeleteBus(int License_num_Id); // removes only Student, does not remove the appropriate Person...
        #endregion

        #region line station
        //get
        DO.LineStation GetLineStation(int code, int line_id);
        DO.LineStation GetPrevLineStation(int id_line, int index);

        DO.LineStation GetLineStation(int code, DO.BusLine a);// מחזיר רשימת תחנות של קו מסויים
        IEnumerable<DO.LineStation> GetAllLineStations(int id_line);
        IEnumerable<DO.LineStation> GetAllLineStations();

        IEnumerable<DO.LineStation> GetAllLineStationsby(Predicate<DO.LineStation> predicate);//מחזיר רשימת תחנות של מסלול מסויים
        IEnumerable<DO.LineStation> GetAllLineStationsby(int id_line);//מחזיר רשימת תחנות של מסלול מסויים

        DO.Station GetStationOfLineStation(int a);//מחזיר תחנה פיזית של תחנה לוגית
        IEnumerable<object> GetlinestationListWithSelectedFields(Func<DO.LineStation, object> generate);//מחזיר אובייקט חדש עם שדות נבחרים
        void UpDateLineStationD_T(DO.LineStation lsDO);
                                                                         //   void AddLineStation(int code, int Line_Id, int index);//להוסיף תחנת קו 
        void AddLineStation(DO.LineStation a);//להוסיף תחנת קו 

       // void UpdateLineStation(DO.LineStation linestation);//עדכון תחנת קו שקיימת
        void DeleteLineStationInBus(int code, int line_id);//מחיקת תחנת קו אחת מקו וסידור התחנות הבאות אחריה
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
        IEnumerable<string> GetAllBusLimeByStation(int code);

        #endregion

        #region AdjStation
        void AddAdjStation(int code, int code1,int d, TimeSpan t, bool a);
      //  IEnumerable<DO.BusLine> GetAllAdjStation();
        IEnumerable<DO.AdjStation> GetAdjStationListBy(Predicate<DO.AdjStation> predicate);
        DO.AdjStation GetAdjStation(int code, int code1);
        void deledteAdjStation(int Code,int code1);
        void UpdateAdjStation(int code, int code1);

        void UpdateAdjStationT_D(DO.AdjStation adj);


        #endregion

        #region user
        DO.User GetUser(string name ,string pc);
        void AddUseru(string name, string pa);
        void AddUserm(string name, string pa);
        #endregion
         
         
    }
}
