namespace ProjectCalendar.Communication.Requests
{
    public class RequestGetEventByDateJson
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
