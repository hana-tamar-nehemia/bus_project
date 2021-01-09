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
        IEnumerable<DO.BusLine> GetAllBusLine();
        IEnumerable<DO.BusLine> GetAllBusLineBy(Predicate<DO.BusLine> predicate);
        DO.BusLine GetBusLine(int Bus_Id);
        void AddBusLine(DO.BusLine BusLine);
        void UpdateBusLine(DO.BusLine BusLine);
        void UpdateBusLine(int Bus_Id, Action<DO.BusLine> update); //method that knows to updt specific fields 

       // void UpdateBusBusLine(int Bus_Id);

        void DeleteBusLine(  int Bus_Id);
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
        IEnumerable<DO.LineStation> GetStudentsInCourseList(Predicate<DO.LineStation> predicate);
         DO.LineStation GetLneStation(int code, BusLine a);
         IEnumerable<DO.LineStation> GetAllLineStations();
         DO.Station GetStationOfLineStation(LineStation a);
         IEnumerable<object> GetlinestationListWithSelectedFields(Func<DO.LineStation, object> generate);
        void UpdateLineStation(DO.LineStation linestation);

        void AddLineStation(DO.LineStation linestation);
        void UpdateLineStation(int code, Action<DO.LineStation> update);
        void DeleteLineStation(int code, BusLine a);

        #endregion

        #region STATION
        DO.Station GetStation(int Code);
        //DO.Station GetName(int Code);
        //DO.Station GetAddress(int Code);
        //DO.Station GetLocation(int Code);//חישוב אווירי
        DO.Station AddStation(DO.Station station);

        void UpdateStation(DO.Station station);
        void DeleteStation(int code);
        IEnumerable<DO.Station> GetAllStation();
        void UpdateStation2(int code, Action<DO.Station> update);
        IEnumerable<DO.Station> GetAllstationsBy(Predicate<DO.Station> predicate);

        #endregion

        #region AdjStation
        void AddAdjStation(int code, int code1);

        IEnumerable<DO.AdjStation> GetAdjStationListBy(Predicate<DO.AdjStation> predicate);
        //DO.AdjStation GetCode1(int Code);
        //DO.AdjStation GetCode2(int Code);
        //DO.AdjStation distace(int Code);
        //DO.AdjStation GetTimeBetween(int Code);
        DO.AdjStation deledteAdjStation(int Code,int code1);
        DO.AdjStation UpdateAdjStation(int Code ,int code1);

        #endregion

    }
}
