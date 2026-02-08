using System;
using System.Runtime.Serialization;

namespace ProjectCalendar.Exceptions.ExceptionsBase
{
    public class ProjectCalendarException : Exception
    {
        public ProjectCalendarException() { }

        public ProjectCalendarException(string message) : base(message) { }

        public ProjectCalendarException(string message, Exception innerException) : base(message, innerException) { }

        protected ProjectCalendarException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
