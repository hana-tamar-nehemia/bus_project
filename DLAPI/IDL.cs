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
        #region BusLine
        IEnumerable<DO.BusLine> GetAllBusLine();
        IEnumerable<DO.BusLine> GetAllBusLineBy(Predicate<DO.BusLine> predicate);
        DO.BusLine GetBusLine(int Bus_Id);
        void AddBusLine(DO.BusLine BusLine);
        void UpdateBusLine(DO.BusLine BusLine);
        void UpdateBusLine(int Bus_Id, Action<DO.BusLine> update); //method that knows to updt specific fields in Person
        void DeleteBusLine(int Bus_Id);
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

        #region LINESTATION
        IEnumerable<DO.LineStation> GetStudentsInCourseList(Predicate<DO.LineStation> predicate);        
        void AddLineStation(int code, int line ,int line_index=0);
        void UpdateLineStation(int code, int line, int line_index = 0);
        void DeleteLineStation(int code, int line);
        void DeleteLineStationFromAllBuses(int code);

        #endregion

        #region Course
        DO.Course GetCourse(int id);
        IEnumerable<DO.Course> GetAllCourses();

        #endregion

        #region Lecturer
        IEnumerable<DO.LecturerInCourse> GetLecturersInCourseList(Predicate<DO.LecturerInCourse> predicate);
        
        #endregion

    }
}
