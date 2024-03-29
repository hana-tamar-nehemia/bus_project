﻿using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BLAPI
{
    public interface IBL
    {

        #region Bus Line
        BO.BusLine GetBusLine(int Bus_Id);
        int GEt_Line_Id();

        IEnumerable<BO.BusLine> GetAllBus();
        //IEnumerable<BO.BusLine> GetAllBusLineBy(Predicate<BO.BusLine> predicate);
        void AddBusLine(BO.BusLine busLine);
        void UpdateBusLine(BO.BusLine BusLine);
        BO.BusLine UpdateBusLinePhat(BO.BusLine BusLine);

        void DeleteBusLine(int Bus_Id);

       
        #endregion

        #region BUS
        BO.Bus GetSBus(int License_num_Id);
        IEnumerable<BO.Bus> GetAllBuses();
        BO.Bus GetFreeBus();//פונקציה שתחזיר מספר רישוי של אוטובוס פנוי

       // IEnumerable<BO.Bus> GetAllBusBy(Predicate<BO.Bus> predicate);
        void AddBus(int num, DateTime st, double k, double f, Bus_status status, bool a);
        void UpdateBus(BO.Bus Bus);
        void DeleteBus(int License_num_Id);

        #endregion

        #region line station
        //get

        BO.LineStation GetLineStation(int code, int id_line);
        BO.LineStation GetPrevLineStation(BO.LineStation lineStation);


         BO.Station GetStationOfLineStation(int code, int id_line);

         IEnumerable<BO.LineStation> GetAllLineStationsOfBusLine(int id_line);// מחזיר רשימת תחנות של קו מסויים
        IEnumerable<BO.LineStation> GetAllLineStations();// מחזיר רשימת תחנות

       // IEnumerable<object> GetlinestationListWithSelectedFields(Func<DO.LineStation, object> generate);

        //add
         void AddLineStation(int code, int Line_Id, int index);//להוסיף תחנת קו 

        void UpDateLineStationD_T(BO.LineStation selectedstation);

        //delete

        void DeleteLineStationInBus(int code, int line_id);

        #endregion

        #region STATION
        // get


        //get
         BO.Station GetStation(int code);//מקבל תחנה לפי קוד תחנה 

         IEnumerable<BO.Station> GetAllStation();//מחזיר את כל התחנות


         IEnumerable<BO.Station> GetAllstationsBy(Predicate<DO.Station> predicate);//מחזיר רשימת תחנות לפי פקדיקט מסוים

         BO.Station GetstationsBy(Predicate<DO.Station> predicate);//מחזיר תחנה לפי פקדיקט מסוים

        //add
         void AddStation(int Code, string Name, string Address, double Latitude, double longitude);//הוספת תחנה פיזית

        bool DeleteStation(int code);
        void UpdateStation(BO.Station station);
        IEnumerable<string> GetAllBusLimeByStation(int code);
        #endregion

        #region AdjStation

        void AddAdjStation(int code, int code1, int d, TimeSpan t,bool a);
        IEnumerable<BO.AdjStation> GetAdjStationListBy(Predicate<BO.AdjStation> predicate);
        BO.AdjStation GetAdjStation(int code1,int code2);
        void UpdateAdjStation(BO.AdjStation adj);

        void UpdateAdjStation(int code, int code1);
        void deledteAdjStation(int code, int code1);

        #endregion

        #region user
        void AddUserM(string name, string pa);
        void AddUserU(string name, string pa);
        bool UserExistsM(string name, string pa);
        bool UserExistsU(string name, string pa);
        #endregion

    }
}
