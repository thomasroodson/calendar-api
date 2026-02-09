using System.Net;

namespace ProjectCalendar.Exceptions.ExceptionsBase
{
    public class ErrorNotFoundEventException : ProjectCalendarException
    {
        public ErrorNotFoundEventException() : base(ResourceMessagesException.NOT_FOUND_EVENT) { }

    }
}
