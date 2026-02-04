namespace ProjectCalendar.Domain.ValueObjects
{
    public class DateRange
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        private DateRange()
        {
            // Construtor privado para o MongoDB
        }

        public DateRange(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
                throw new ArgumentException("End date must be after start date");

            var duration = endDate - startDate;
            if (duration.TotalMinutes < 1)
                throw new ArgumentException("Event duration must be at least 1 minute");

            StartDate = startDate.ToUniversalTime();
            EndDate = endDate.ToUniversalTime();
        }

        public TimeSpan Duration => EndDate - StartDate;

        public bool OverlapsWith(DateRange other)
        {
            return StartDate < other.EndDate && EndDate > other.StartDate;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not DateRange other)
                return false;

            return StartDate == other.StartDate && EndDate == other.EndDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StartDate, EndDate);
        }
    }
}