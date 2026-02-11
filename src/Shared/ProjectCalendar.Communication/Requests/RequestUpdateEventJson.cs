namespace ProjectCalendar.Communication.Requests
{
    public class RequestUpdateEventJson
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Color { get; set; } = "#3B82F6";

    }
}
