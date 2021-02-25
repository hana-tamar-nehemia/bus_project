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
         
    public BadStationCodeException(string message, Exception innerException) :
             base(message, innerException) => CODE = ((DO.BadStaionCodeException)innerException).CODE;
    public BadStationCodeException(string message, DO.BadStaionCodeException innerException) :
            base(message, innerException) => CODE = ((DO.BadStaionCodeException)innerException).CODE;
        // public BadStationCodeException(int code, string massage) : base(message, )
        public BadStationCodeException(int message, DO.BadStaionCodeException innerException) { }
        public BadStationCodeException(int message, string massage) { }

        // base(message, innerException) => CODE = ((DO.BadStaionCodeException) innerException).CODE;
        //public BadStationCodeException(int message, DO.BadStaionCodeException innerException):
        // base(message, innerException) => CODE = ((DO.BadStaionCodeException) innerException).CODE;

        public override string ToString() => base.ToString() + $", bad station code: {CODE}";

    }

    [Serializable]
    public class BadBusLineException : Exception
    {
        public int CODE;
        public BadBusLineException(string message, Exception innerException) : 
            base(message, innerException) => CODE = ((DO.BadBusLineException)innerException).CODE;
        public override string ToString() => base.ToString() + $", bad student id: {CODE}";
    }

    [Serializable]
    public class BadAdjStationException : Exception
    {
        public int personID;
        public int courseID;
        public BadAdjStationException(string message, Exception innerException) :
            base(message, innerException)
        {
         
        }
        public override string ToString() => base.ToString() + $", bad student id: {personID} and course ID: {courseID}";
    }
    public class BadBusException : Exception
    {
        public BadBusException(string message, Exception innerException) { }
 }

}
