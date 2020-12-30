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
        void UpdateBusLine(int line_id, Action<DO.BusLine> update); //method that knows to updt specific fields 

        void UpdateBusBusLine(int Bus_Id);

        void DeleteBusLine(int Line_Number, int Line_Id);
        #endregion

        #region BUS
        DO.Bus GetSBus(int License_num_Id);
        IEnumerable<DO.Bus> GetAllBuses();
        IEnumerable<object> GetBusListWithSelectedFields(Func<DO.Bus, object> generate);
        void AddBus(DO.Bus Bus);
        void UpdateFuelBus(DO.Bus Bus);
        void UpdateFuelBus(int License_num_Id, Action<DO.Bus> update); //method that knows to updt specific fields 
        void DeleteBus(int License_num_Id); // removes only Student, does not remove the appropriate Person...
        #endregion

        #region LINE STATION
        IEnumerable<DO.LineStation> GetStudentsInCourseList(Predicate<DO.LineStation> predicate);        
        void AddLineStation(int code, int line ,int line_index=0);
        void UpdateLineStation(int code, int line, int line_index = 0);
        void DeleteLineStation(int code, int line);
        void DeleteLineStationFromAllBuses(int code);

        #endregion

        #region STATION
        DO.Station GetStation(int Code);
        DO.Station GetName(int Code);
        DO.Station GetAddress(int Code);
        DO.Station GetLocation(int Code);//חישוב אווירי
        void UpdateNameStation(int code);
        void DeleteStation(int code);
        IEnumerable<DO.Station> GetAllStation();

        #endregion

        #region AdjStation
        void AddAdjStation(int code, int code1);

        IEnumerable<DO.AdjStation> GetLecturersInCourseList(Predicate<DO.AdjStation> predicate);
        DO.AdjStation GetCode1(int Code);
        DO.AdjStation GetCode2(int Code);
        DO.AdjStation distace(int Code);
        DO.AdjStation GetTimeBetween(int Code);
        DO.AdjStation deledteAdjStation(int Code);


        #endregion

    }
}
