namespace ProjectCalendar.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : ProjectCalendarException
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
