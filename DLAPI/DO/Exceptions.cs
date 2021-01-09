using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class BadStaionCodeException : Exception
    {
        public int CODE;

        //public BadStaionCodeException(int id,string s) : base() => ID = id;
        public BadStaionCodeException(int code, string message) : 
            base(message) => CODE = code;
        public BadStaionCodeException(int code, string message, Exception innerException) : 
            base(message, innerException) => CODE = code;
      
        public override string ToString() => base.ToString() + $", bad station code: {CODE}";
    }

    public class BadLineStationCodeException : Exception
    {
        public int CODE;
        public BadLineStationCodeException(int code, int crsID) : base() { CODE = code;}  
        public BadLineStationCodeException(int code,  string message) :
            base(message) { CODE = code; }
        //public BadLineStationCodeException(int perID, int crsID, string message, Exception innerException) :
        //    base(message, innerException) { personID = perID; courseID = crsID; }

        public override string ToString() => base.ToString() + $", bad line station code: {CODE}";
    }
    public class BadBusLineCodeException : Exception
    {
        public int CODE;
        public BadBusLineCodeException(int code, int crsID) : base() { CODE = code; }
        public BadBusLineCodeException(int code, string message) :
            base(message)
        { CODE = code; }
        //public BadLineStationCodeException(int perID, int crsID, string message, Exception innerException) :
        //    base(message, innerException) { personID = perID; courseID = crsID; }

        public override string ToString() => base.ToString() + $", bad line station code: {CODE}";
    }
    public class BadBusAdjStationException : Exception
    {
        public int CODE;
        public BadBusAdjStationException(int code, int crsID) : base() { CODE = code; }
        public BadBusAdjStationException(int code, int code1, string message) :
            base(message)
        { CODE = code; }
        //public BadLineStationCodeException(int perID, int crsID, string message, Exception innerException) :
        //    base(message, innerException) { personID = perID; courseID = crsID; }

        public override string ToString() => base.ToString() + $", bad line station code: {CODE}";
    }
    public class BadBusException : Exception
    {
        public int CODE;
        public BadBusException(int code, int crsID) : base() { CODE = code; }
        public BadBusException(int code, string message) :
            base(message)
        { CODE = code; }
        //public BadLineStationCodeException(int perID, int crsID, string message, Exception innerException) :
        //    base(message, innerException) { personID = perID; courseID = crsID; }

        public override string ToString() => base.ToString() + $", bad line station code: {CODE}";
    }
 }
