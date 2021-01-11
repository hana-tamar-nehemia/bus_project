using System;
using System.Collections.Generic;
using System.Linq;
using DLAPI;
using BLAPI;
using System.Threading;
using BO;
//using BO;

namespace BL
{
    class BLImp : IBL //internal
    {
        IDL dl = DLFactory.GetDL();
        #region Station

        BO.Station StationDoBoAdapter(DO.Station StationDO)
            {
              BO.Station StationBO = new BO.Station();
            StationDO.CopyPropertiesTo(StationBO);

            StationBO.Collection_Lines = from line in dl.GetAllBusLineBy(line => line.Bus_Id == Stat`ionDO.Code)
                                             let station = dl.GetStation(line.Line_Id)
                                         select (BO.Station)Station.CopyPropertiesToNew(typeof(BO.Station));


            courseBO.Lecturers = from lic in dl.GetLecturersInCourseList(lic => lic.CourseId == id)
                                 let course = dl.GetCourse(lic.CourseId)
                                 select (BO.CourseLecturer)course.CopyPropertiesToNew(typeof(BO.CourseLecturer));
            return StationBO;
         }

     
        //get
        public BO.Station GetStation(int code)
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
        public IEnumerable<BO.Station> GetAllStation()
        {
            return from StationDO in dl.GetAllStation()
                   select StationDoBoAdapter(StationDO);//מוסיף גם את רשימת הקווים שעוברים בתחנה הזאת
        }

        public IEnumerable<BO.Station> GetAllstationsBy(Predicate<DO.Station> predicate)
        {
            return from Station in dl.GetAllstationsBy(predicate)
                   select StationDoBoAdapter(Station);
        }
        //add
        public void AddStation(int Code, string Name, string Address, double Latitude, double longitude)
        {
            DO.Station stationDO = new DO.Station() { Code = Code, Name = Name, Address = Address, Latitude = Latitude, longitude = longitude, Act = true };
            dl.AddStation(stationDO);
        }
        //update
        public void UpdateListLineBusOfStation(BO.BusLine busLine)
        {
            
        }

        public void DeleteStation(int code)
        {
            DO.Station stationDO;
            stationDO = dl.GetStation(code);
            if(stationDO!=null)
            {
                dl.DeleteStation(code);
                stationDO.Act = false;
                dl.AddStation(stationDO);
                //להמשיך מחיקת תחנה פיזית 
                DeleteLineStation(code);
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
            LineStationBO.Collection_Lines = from busline in dl.GetAllBusLine()
                                             where (busline.Line_Id == LineStationDO.Line_Id)
                                             select BusLineDoBoAdapter(busline);
            return LineStationBO;
        }
        //get
        public BO.LineStation GetLineStation(int code, int id_line)//תחנה לפי מספר רץ של קן מסןיים וקוד תחנה
        { 
            DO.LineStation ls = dl.GetLineStation(code,id_line);
            return LineStationDoBoAdapter(ls);
        }
        public BO.Station GetStationOfLineStation(int code, int id_line)
        {

            return StationDoBoAdapter(dl.GetStationOfLineStation(code));
        }
        public IEnumerable<BO.LineStation> GetAllLineStationsOfBusLine(int id_line)// מחזיר רשימת תחנות של קו מסויים
        {
            return from linestation in dl.GetAllLineStationsby(p=>p.Line_Id==id_line)
                   select LineStationDoBoAdapter(linestation);
        }


        //public IEnumerable<object> GetlinestationListWithSelectedFields(Func<DO.LineStation, object> generate)
        //{
        //    return from linestation in DataSource.List_Line_Station
        //           select generate(linestation);
        //}
        //add
        public void AddLineStation(int code, int Line_Id, int index)//להוסיף תחנת קו 
        {
            try
            {
                dl.AddLineStation(new DO.LineStation { Code = code, Line_Id = Line_Id, Line_Station_Index = index });
            }
            catch (DO.BadStaionCodeException ex)
            {
                throw new BO.BadStationCodeException("line station is already exsist", ex);
            }
        }
        //update
        //public void UpdateLineStation(DO.LineStation linestation)
        //{
        //    DO.LineStation stu = DataSource.List_Line_Station.Find(p => p.Code == linestation.Code);
        //    if (stu != null)
        //    {
        //        DataSource.List_Line_Station.Remove(stu);
        //        DataSource.List_Line_Station.Add(stu.Clone());
        //    }
        //    else
        //        throw new DO.BadLineStationCodeException(linestation.Code, $"bad line station code: {linestation.Code}");
        //}

        //delete
        public void DeleteLineStation(int code)
        {
            try
            {
                dl.DeleteLineStation(code);
            }
            catch (DO.BadStaionCodeException ex)
            {
                throw new BO.BadStationCodeException("line station not exsist", ex);
            }
        }
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
        //public IEnumerable<object> GetLineStationFields(Func<int, object> generate)
        //{
        //    return from linestation in DataSource.List_Line_Station
        //           select generate(linestation.Code, GetStation(linestation.Code));
        //}
        #endregion

        #region BUS
        public BO.Bus GetSBus(int License_num_Id)
        {
            DO.Bus BusDO;

            try
            {
                BusDO = dl.GetSBus(License_num_Id);
            }
            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException("Bus  id does not exist or he is not a Bus ", ex);
            }
            return BusDoBoAdapter(BusDO);
        }
        public IEnumerable<DO.Bus> GetAllBuses()
        {
             return (IEnumerable<DO.Bus>)(from item in dl.GetAllBuses()
                  select BusDoBoAdapter(item));
        }
    
        public IEnumerable<object> GetAllBusBy(Predicate<DO.Bus> predicate)
        {
            return (IEnumerable<DO.Bus>)(IEnumerable<Bus>)(from Bus in dl.GetAllBusBy(predicate)
                                              select BusDoBoAdapter(Bus));
            throw new NotImplementedException();
        }
        public void AddBus(int num ,DateTime st,double k,double f,Bus_status status, bool a)
        {
            try
            {
                dl.AddBus( num,  st, k,  f, (DO.Bus_status)status,a);
                
             }
            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException(" Bus Not exist", ex);
            }
        }
        public void UpdateFuelBus(DO.Bus Bus)
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
                BusDO = dl.GetSBus(id);
            }
            catch (DO.BadBusException ex)
            {
                throw new BO.BadBusException("Bus ID is illegal", ex);
            }
            BusDO.CopyPropertiesTo(BusBO);
            BusBO.License_num = BusDO.License_num;
            BusBO.Bus_status = (Bus_status)BusDO.Bus_status;
            BusBO.License_num = BusDO.License_num;
            BusBO.Fuel_tank = BusDO.Fuel_tank;
            BusBO.Km = BusDO.Km;
            BusBO.Start_date = BusDO.Start_date;



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
            }
            catch (DO.BadBusLineCodeException ex)
            {
                throw new BO.BadBusLineCodeException("Bus line id does not exist or he is not a Bus line", ex);
            }
            return BusLineDoBoAdapter(BusLinelDO);
        }
        public IEnumerable<BO.BusLine> GetAllBusLine()
        {
            return from item in dl.GetAllBusLine()
                  select BusLineDoBoAdapter(item);
        }
        
        public IEnumerable<DO.BusLine> GetAllBusLineBy(Predicate<DO.BusLine> predicate)
        {
            return (IEnumerable<DO.BusLine>)(IEnumerable<BusLine>)(from BusLine in dl.GetAllBusLineBy(predicate)
                                        select BusLineDoBoAdapter(BusLine)); 
            throw new NotImplementedException();
        }
        public void AddBusLine( int bus_id ,int Line_Number, Areas Area, int First_Station ,  int Last_Station , IEnumerable<LineStation> LineStations, bool act, int Line_Id)  
        {
            try
            {
                dl.AddBusLine(bus_id, Line_Number, Area, First_Station, Last_Station,act,Line_Number);
                from s in LineStations
                select dl.AddLineStation(s, Line_Number)
            }
            catch (DO.BadBusLineException ex)
            {
                throw new BO.BadBusLineException("Student ID and Course ID is Not exist", ex);
            }
        }
       void UpdateBusLine(BO.BusLine BusLine)
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
        public void DeleteBusLine(int Bus_Id , int Line_Number)
        {
            try
            {
                dl.DeleteBusLine(Bus_Id);
                
            }
            
            catch (DO.BadBusLineException ex)
            {
                throw new BO.BadBusLineException("Person id does not exist or he is not a student", ex);
            }
        }
         
        BO.BusLine BusLineDoBoAdapter(DO.BusLine BusLineDO)
        {
            BO.BusLine BusLineBO = new BO.BusLine();
            DO.Bus BusDO;
            int id = BusLineDO.Bus_Id;
            try
            {
                BusDO = dl.GetSBus(id);
            }
            catch (DO.BadBusLineException ex)
            {
                throw new BO.BadBusLineException("Student ID is illegal", ex);
            }
            BusDO.CopyPropertiesTo(BusLineBO);
            BusLineBO.Bus_status = (Bus_status)BusDO.Bus_status;
            BusLineBO.License_num = BusDO.License_num;
            BusLineBO.Fuel_tank= BusDO.Fuel_tank;
            BusLineBO.Km= BusDO.Km;
            BusLineBO.Start_date = BusDO.Start_date;
             

            BusLineDO.CopyPropertiesTo(BusLineBO);
            BusLineBO.Act = BusLineDO.Act;
            BusLineBO.First_Station = BusLineDO.First_Station;
            BusLineBO.Last_Station = BusLineDO.Last_Station;
            BusLineBO.Line_Id = BusLineDO.Line_Id;
            BusLineBO.Line_Number = BusLineDO.Line_Number;
            BusLineBO.Area = (Areas)BusLineDO.Area;
            //BusLineBO.ListLineStations = from s in dl.GetAllLineStations()
            //                          let LineStations = dl.GetLineStation(s.Line_Id)
            //                          select LineStations.CopyToStudentCours
             return BusLineBO;
        }





        #endregion

        #region AdjStation

        public void AddAdjStation(int code, int code1,int d,DateTime t)
        {
            try
            {
                dl.AddAdjStation(code,code1,d,t);

            }
            catch (DO.BadAdjStationException ex)
            {
                throw new BO.BadAdjStationException(" AdjStation Not exist", ex);
            }

        }
        public IEnumerable<DO.AdjStation> GetAdjStationListBy(Predicate<DO.AdjStation> predicate)
        {
            
        }
        public void UpdateAdjStation(int code, int code1)
        {
            AdjStation adj = DataSource.List_Adjstation.Find(a => a.Code_station1 == code && a.Code_station2 == code1);
            if (adj != null)
            {
                DataSource.List_Adjstation.Remove(adj);
                DataSource.List_Adjstation.Add(adj.Clone());

            }
            throw new DO.BadBusAdjStationnException(AdjStation.Code_station1, AdjStation.Code_station2, "Duplicate Code station 1 and Code station 2");

        }
        public void deledteAdjStation(int code, int code1)
        {
            AdjStation adj = DataSource.List_Adjstation.Find(a => a.Code_station1 == code && a.Code_station2 == code1);
            if (adj != null)
            {
                DataSource.List_Adjstation.Remove(adj);
            }
            throw new DO.BadBusAdjStationnException(AdjStation.Code_station1, AdjStation.Code_station2, "Duplicate Code station 1 and Code station 2");
        }

        void IDL.UpdateBusLine(BusLine BusLine)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Student
         

             

            return BusBO;
        }

        public BO.Student GetStudent(int id)
        {
            DO.Student studentDO;
            try
            {
                studentDO = dl.GetStudent(id);
            }
            catch (DO.BadPersonIdException ex)
            {
                throw new BO.BadStudentIdException("Person id does not exist or he is not a student", ex);
            }
            return studentDoBoAdapter(studentDO);
        }

        public IEnumerable<BO.Student> GetAllStudents()
        {
            //return from item in dl.GetStudentListWithSelectedFields( (stud) => { return GetStudent(stud.ID); } )
            //       let student = item as BO.Student
            //       orderby student.ID
            //       select student;
            return from item in dl.GetAllStudents()
                   select studentDoBoAdapter(item);
        }
        public IEnumerable<BO.Student> GetStudentsBy(Predicate<BO.Student> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.ListedPerson> GetStudentIDNameList()
        {
            return from item in dl.GetStudentListWithSelectedFields((Func<DO.Student, object>)((stud) =>
                    {
                        try { Thread.Sleep(1500); } catch (ThreadInterruptedException e) { }
                        return new BO.ListedPerson() { ID = stud.ID, Name = dl.GetPerson(stud.ID).Name };
                    }))
                   let student = item as BO.ListedPerson
                   //orderby student.ID
                   select student;
        }

        public void UpdateStudentPersonalDetails(BO.Student student)
        {
            //Update DO.Person            
            DO.Person personDO = new DO.Person();
            student.CopyPropertiesTo(personDO);
            try
            {
                dl.UpdatePerson(personDO);
            }
            catch (DO.BadPersonIdException ex)
            {
                throw new BO.BadStudentIdException("Student ID is illegal", ex);
            }

            //Update DO.Student            
            DO.Student studentDO = new DO.Student();
            student.CopyPropertiesTo(studentDO);
            try
            {
                dl.UpdateStudent(studentDO);
            }
            catch (DO.BadPersonIdException ex)
            {
                throw new BO.BadStudentIdException("Student ID is illegal", ex);
            }

        }

        public void DeleteStudent(int id)
        {
            try
            {
                dl.DeletePerson(id);
                dl.DeleteStudent(id);
                dl.DeleteStudentFromAllCourses(id);
            }
            catch (DO.BadPersonIdCourseIDException ex)
            {
                throw new BO.BadStudentIdCourseIDException("Student ID and Course ID is Not exist", ex);
            }
            catch (DO.BadPersonIdException ex)
            {
                throw new BO.BadStudentIdException("Person id does not exist or he is not a student", ex);
            }
        }

        #endregion

        #region StudentIn Course
        public void AddStudentInCourse(int perID, int courseID, float grade = 0)
        {
            try
            {
                dl.AddStudentInCourse(perID, courseID, grade);
            }
            catch (DO.BadPersonIdCourseIDException ex)
            {
                throw new BO.BadStudentIdCourseIDException("Student ID and Course ID is Not exist", ex);
            }
        }

        public void UpdateStudentGradeInCourse(int perID, int courseID, float grade)
        {
            try
            {
                dl.UpdateStudentGradeInCourse(perID, courseID, grade);
            }
            catch (DO.BadPersonIdCourseIDException ex)
            {
                throw new BO.BadStudentIdCourseIDException("Student ID and Course ID is Not exist", ex);
            }
        }

        public void DeleteStudentInCourse(int perID, int courseID)
        {
            try
            {
                dl.DeleteStudentInCourse(perID, courseID);
            }
            catch (DO.BadPersonIdCourseIDException ex)
            {
                throw new BO.BadStudentIdCourseIDException("Student ID and Course ID is Not exist", ex);
            }
        }
        #endregion

        #region Course

        BO.Course courseDoBoAdapter(DO.Course courseDO)
        {
            BO.Course courseBO = new BO.Course();
            int id = courseDO.ID;
            courseDO.CopyPropertiesTo(courseBO);

            courseBO.Lecturers = from lic in dl.GetLecturersInCourseList(lic => lic.CourseId == id)
                                 let course = dl.GetCourse(lic.CourseId)
                                 select (BO.CourseLecturer)course.CopyPropertiesToNew(typeof(BO.CourseLecturer));
            return courseBO;
        }
        public IEnumerable<BO.Course> GetAllCourses()
        {
            return from crsDO in dl.GetAllCourses()
                   select courseDoBoAdapter(crsDO);
        }

        #endregion


    }
}
