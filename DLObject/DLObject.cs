using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DLAPI;
using DO;
//using DO;
using DS;

namespace DL
{
    sealed class DLObject : IDL    //internal

    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion

        //Implement IDL methods, CRUD
        #region Station
        public DO.Station GetStation(int code)
        {
            DO.Station per = DataSource.List_Station.Find(p => p.Code == code);

            if (per != null)
                return per.Clone();
            else
                throw new DO.BadPersonIdException(code, $"bad station code: {code}");
        }
        public IEnumerable<DO.Station> GetAllStation()
        {
            return from Station in DataSource.List_Station
                   select Station.Clone();
        }
        public IEnumerable<DO.Station> GetAllstationsBy(Predicate<DO.Station> predicate)
        {
            return from Station in DataSource.List_Station
                   where predicate(Station)
                   select Station.Clone();
            throw new NotImplementedException();
        }

        public void AddStation(DO.Station station)
        {
            if (DataSource.List_Station.FirstOrDefault(p => p.Code == station.Code) != null)
                throw new DO.BadPersonIdException(station.Code, "Duplicate station code");
            DataSource.List_Station.Add(station.Clone());
        }

        //public void DeleteStation(int code)
        //{
        //    DO.Station per = DataSource.List_Station.Find(p => p.Code == code);
        //    if (per != null)
        //    {
        //        per.Act = false;
        //        DataSource.List_Station.(per);
        //    }
        //    else
        //        throw new DO.BadPersonIdException(code, $"bad station code: {code}");
        //}

        public void UpdateStation(DO.Station station)
        {
            DO.Station per = DataSource.List_Station.Find(p => p.Code == station.Code);

            if (per != null)
            {
                DataSource.List_Station.Remove(per);
                DataSource.List_Station.Add(per.Clone());
            }
            else
                throw new DO.BadPersonIdException(station.Code, $"bad station code: {station.Code}");
        }

        public void UpdateStation2(int code, Action<DO.Station> update)
        {
            throw new NotImplementedException();
        }
        #endregion Person

        #region line station
        public DO.LineStation GetLneStation(int code ,DO.BusLine a)//תחנה של קו מסויים
        {
            DO.LineStation s = DataSource.List_Line_Station.Find(p => p.Code == code && a.Bus_Id == p.Line_Id);
            if (s != null)
                return s.Clone();
            else
                throw new DO.BadPersonIdException(code, $"no found: {code}");
        }
        public void AddLineStation(DO.LineStation linestation, DO.BusLine a)//להוסיף תחנה לקו מסויים
        {
            if (DataSource.List_Line_Station.FirstOrDefault(s => s.Code == linestation.Code && a.Line_Id==s.Line_Id) != null)
                throw new DO.BadPersonIdException(linestation.Code, "Duplicate line station code");
            if (DataSource.List_Line_Station.FirstOrDefault(p => p.Code == linestation.Code && a.Line_Id == p.Line_Id) == null)
                throw new DO.BadPersonIdException(linestation.Code, "Missing line station code");
            DataSource.List_Line_Station.Add(linestation.Clone());
        }
        public IEnumerable<DO.LineStation> GetAllLineStations()
        {
            return from linestation in DataSource.List_Line_Station
                   select linestation.Clone();
        }
        //public IEnumerable<object> GetLineStationFields(Func<int, object> generate)
        //{
        //    return from linestation in DataSource.List_Line_Station
        //           select generate(linestation.Code, GetStation(linestation.Code));
        //}

        public DO.Station GetStationOfLineStation(LineStation a)
        {
            return DataSource.List_Station.Find(s => s.Code == a.Code);
        }

        public IEnumerable<object> GetlinestationListWithSelectedFields(Func<DO.LineStation, object> generate)
        {
            return from linestation in DataSource.List_Line_Station
                   select generate(linestation);
        }
        public void UpdateLineStation(DO.LineStation linestation)
        {
            DO.LineStation stu = DataSource.List_Line_Station.Find(p => p.Code == linestation.Code);
            if (stu != null)
            {
                DataSource.List_Line_Station.Remove(stu);
                DataSource.List_Line_Station.Add(stu.Clone());
            }
            else
                throw new DO.BadPersonIdException(linestation.Code, $"bad line station code: {linestation.Code}");
        }

        public void UpdateLineStation(int code, Action<DO.LineStation> update)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineStation(int code, BusLine a)
        {
            DO.LineStation s = DataSource.List_Line_Station.Find(p => p.Code== code && a.Bus_Id==p.Line_Id);
 
            if (s != null)
            {
                int index = s.Line_Station_Index;
                DataSource.List_Line_Station.Remove(s);
                DataSource.List_Line_Station.Where(p => p.Code == code && a.Bus_Id == p.Line_Id && p.Line_Station_Index > index).Select(p => p.Line_Station_Index++);
            }
            else
                throw new DO.BadPersonIdException(code, $"bad line station code: {code}");
        }
        #endregion Student

        #region StudentInCourse
        public IEnumerable<DO.StudentInCourse> GetStudentsInCourseList(Predicate<DO.StudentInCourse> predicate)
        {
            //option A - not good!!! 
            //produces final list instead of deferred query and does not allow proper cloning:
            // return DataSource.listStudInCourses.FindAll(predicate);

            // option B - ok!!
            //Returns deferred query + clone:
            //return DataSource.listStudInCourses.Where(sic => predicate(sic)).Select(sic => sic.Clone());

            // option c - ok!!
            //Returns deferred query + clone:
            return from sic in DataSource.ListStudInCourses
                   where predicate(sic)
                   select sic.Clone();
        }
        public void AddStudentInCourse(int perID, int courseID, float grade = 0)
        {
            if (DataSource.ListStudInCourses.FirstOrDefault(cis => (cis.PersonId == perID && cis.CourseId == courseID)) != null)
                throw new DO.BadPersonIdCourseIDException(perID, courseID, "person ID is already registered to course ID");
            DO.StudentInCourse sic = new DO.StudentInCourse() { PersonId = perID, CourseId = courseID, Grade = grade };
            DataSource.ListStudInCourses.Add(sic);
        }

        public void UpdateStudentGradeInCourse(int perID, int courseID, float grade)
        {
            DO.StudentInCourse sic = DataSource.ListStudInCourses.Find(cis => (cis.PersonId == perID && cis.CourseId == courseID));

            if (sic != null)
            {
                sic.Grade = grade;
            }
            else
                throw new DO.BadPersonIdCourseIDException(perID, courseID, "person ID is NOT registered to course ID");
        }

        public void DeleteStudentInCourse(int perID, int courseID)
        {
            DO.StudentInCourse sic = DataSource.ListStudInCourses.Find(cis => (cis.PersonId == perID && cis.CourseId == courseID));

            if (sic != null)
            {
                DataSource.ListStudInCourses.Remove(sic);
            }
            else
                throw new DO.BadPersonIdCourseIDException(perID, courseID, "person ID is NOT registered to course ID");
        }
        public void DeleteStudentFromAllCourses(int perID)
        {
            DataSource.ListStudInCourses.RemoveAll(p => p.PersonId == perID);
        }

        #endregion StudentInCourse

        #region Course
        public DO.Course GetCourse(int id)
        {
            return DataSource.ListCourses.Find(c => c.ID == id).Clone();
        }

        public IEnumerable<DO.Course> GetAllCourses()
        {
            return from course in DataSource.ListCourses
                   select course.Clone();
        }

        #endregion Course

        #region Lecturer
        public IEnumerable<DO.LecturerInCourse> GetLecturersInCourseList(Predicate<DO.LecturerInCourse> predicate)
        {
            //Returns deferred query + clone:
            return from sic in DataSource.ListLectInCourses
                   where predicate(sic)
                   select sic.Clone();
        }

        public IEnumerable<BusLine> GetAllBusLine()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusLine> GetAllBusLineBy(Predicate<BusLine> predicate)
        {
            throw new NotImplementedException();
        }

        public BusLine GetBusLine(int Bus_Id)
        {
            throw new NotImplementedException();
        }

        public void AddBusLine(BusLine BusLine)
        {
            throw new NotImplementedException();
        }

        public void UpdateBusLine(BusLine BusLine)
        {
            throw new NotImplementedException();
        }

        public void UpdateBusLine(int line_id, Action<BusLine> update)
        {
            throw new NotImplementedException();
        }

        public void UpdateBusBusLine(int Bus_Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteBusLine(int Line_Number, int Line_Id)
        {
            throw new NotImplementedException();
        }

        public Bus GetSBus(int License_num_Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bus> GetAllBuses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetBusListWithSelectedFields(Func<Bus, object> generate)
        {
            throw new NotImplementedException();
        }

        public void AddBus(Bus Bus)
        {
            throw new NotImplementedException();
        }

        public void UpdateFuelBus(Bus Bus)
        {
            throw new NotImplementedException();
        }

        public void UpdateFuelBus(int License_num_Id, Action<Bus> update)
        {
            throw new NotImplementedException();
        }

        public void DeleteBus(int License_num_Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetStudentsInCourseList(Predicate<LineStation> predicate)
        {
            throw new NotImplementedException();
        }

        public void AddLineStation(int code, int line, int line_index = 0)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStation(int code, int line, int line_index = 0)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineStation(int code, int line)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineStationFromAllBuses(int code)
        {
            throw new NotImplementedException();
        }

        public Station GetStation(int Code)
        {
            throw new NotImplementedException();
        }

        public Station GetName(int Code)
        {
            throw new NotImplementedException();
        }

        public Station GetAddress(int Code)
        {
            throw new NotImplementedException();
        }

        public Station GetLocation(int Code)
        {
            throw new NotImplementedException();
        }

        public void UpdateNameStation(int code)
        {
            throw new NotImplementedException();
        }

        public void DeleteStation(int code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAllStation()
        {
            throw new NotImplementedException();
        }

        public void AddAdjStation(int code, int code1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdjStation> GetLecturersInCourseList(Predicate<AdjStation> predicate)
        {
            throw new NotImplementedException();
        }

        public AdjStation GetCode1(int Code)
        {
            throw new NotImplementedException();
        }

        public AdjStation GetCode2(int Code)
        {
            throw new NotImplementedException();
        }

        public AdjStation distace(int Code)
        {
            throw new NotImplementedException();
        }

        public AdjStation GetTimeBetween(int Code)
        {
            throw new NotImplementedException();
        }

        public AdjStation deledteAdjStation(int Code)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}