using System.Net;

namespace ProjectCalendar.Exceptions.ExceptionsBase
{
    public class ErrorNotFoundEventException : ProjectCalendarException
    {
        public ErrorNotFoundEventException(string message) : base(message) { }

        public int StatusCode => (int)HttpStatusCode.NotFound;

        public List<string> GetErrorMessages() 
        {
            return new List<string> { Message };
        }

    }
}
