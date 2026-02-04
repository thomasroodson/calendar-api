using ProjectCalendar.Domain.ValueObjects;

namespace ProjectCalendar.Domain.Entities
{
    public class Event
    {
        public string? Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateRange DateRange { get; private set; }
        public EventColor Color { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Event()
        {
        }

        public Event(string title, DateTime startDate, DateTime endDate, string color, string? description = null)
        {
            Id = null;
            Title = title.Trim();
            Description = description?.Trim();
            DateRange = new DateRange(startDate, endDate);
            Color = new EventColor(color);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateTitle(string title)
        {
            Title = title.Trim();
            UpdateTimestamp();
        }

        public void UpdateDescription(string? description)
        {
            Description = description?.Trim();
            UpdateTimestamp();
        }

        public void UpdateDateRange(DateTime startDate, DateTime endDate)
        {
            DateRange = new DateRange(startDate, endDate);
            UpdateTimestamp();
        }

        public void UpdateColor(string color)
        {
            Color = new EventColor(color);
            UpdateTimestamp();
        }

        public void Move(DateTime newStartDate, DateTime newEndDate)
        {
            DateRange = new DateRange(newStartDate, newEndDate);
            UpdateTimestamp();
        }

        private void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }


    }

}
