using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DO;

namespace BO
{
    [Serializable]
    public class BadStationCodeException : Exception
    {
        public int CODE;
        public BadStationCodeException(string message, DO.BadStaionCodeException innerException) : 
            base(message, innerException) => CODE = ((DO.BadStaionCodeException)innerException).CODE;
        public BadStationCodeException(int code, string massage) : base(message, )

        public BadStationCodeException(int message, DO.BadStaionCodeException innerException):
         base(message, innerException) => CODE = ((DO.BadStaionCodeException) innerException).CODE;

        public override string ToString() => base.ToString() + $", bad station code: {CODE}";

    }

    [Serializable]
    public class BadLecturerIdException : Exception
    {
        public int ID;
        public BadLecturerIdException(string message, Exception innerException) : 
            base(message, innerException) => ID = ((DO.BadPersonIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BadStudentIdCourseIDException : Exception
    {
        public int personID;
        public int courseID;
        public BadStudentIdCourseIDException(string message, Exception innerException) :
            base(message, innerException)
        {
            personID = ((DO.BadPersonIdCourseIDException)innerException).personID;
            courseID = ((DO.BadPersonIdCourseIDException)innerException).courseID;
        }
        public override string ToString() => base.ToString() + $", bad student id: {personID} and course ID: {courseID}";
    }

}
