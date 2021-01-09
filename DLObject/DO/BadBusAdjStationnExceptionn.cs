using System;
using System.Runtime.Serialization;

namespace DO
{
    [Serializable]
    internal class BadBusAdjStationnExceptionn : Exception
    {
        private int code_station1;
        private int code_station2;
        private string v;

        public BadBusAdjStationnExceptionn()
        {
        }

        public BadBusAdjStationnExceptionn(string message) : base(message)
        {
        }

        public BadBusAdjStationnExceptionn(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BadBusAdjStationnExceptionn(int code_station1, int code_station2, string v)
        {
            this.code_station1 = code_station1;
            this.code_station2 = code_station2;
            this.v = v;
        }

        protected BadBusAdjStationnExceptionn(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}