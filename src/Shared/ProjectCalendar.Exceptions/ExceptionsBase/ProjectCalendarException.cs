using System;
using System.Runtime.Serialization;

namespace ProjectCalendar.Exceptions.ExceptionsBase
{
    public class ProjectCalendarException : Exception
    {
        public ProjectCalendarException(string message) : base(message) { }
    }
}
