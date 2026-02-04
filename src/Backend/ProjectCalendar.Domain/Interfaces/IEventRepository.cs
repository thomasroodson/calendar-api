using ProjectCalendar.Domain.Entities;

namespace ProjectCalendar.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task<Event?> GetByIdAsync(string id);
        Task<IEnumerable<Event>> GetAllAsync();
        Task<IEnumerable<Event>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<Event> CreateAsync(Event @event);
        Task<Event> UpdateAsync(Event @event);
        Task<bool> DeleteAsync(string id);
    }

}
