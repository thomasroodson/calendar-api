using MongoDB.Driver;
using ProjectCalendar.Domain.Entities;
using ProjectCalendar.Domain.Interfaces;

namespace ProjectCalendar.Infrastructure.DataAccess
{
    public class EventRepository : IEventRepository
    {
        private readonly IMongoCollection<Event> _collection;

        public EventRepository(MongoDbContext context)
        {
            _collection = context.Events;
        }

        public async Task<Event> CreateAsync(Event @event)
        {
            await _collection.InsertOneAsync(@event);
            return @event;
        }

        public async Task<Event?> GetByIdAsync(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var filter = Builders<Event>.Filter.And(
                Builders<Event>.Filter.Gte(e => e.DateRange.StartDate, startDate),
                Builders<Event>.Filter.Lte(e => e.DateRange.EndDate, endDate)
            );

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<Event> UpdateAsync(Event @event)
        {
            await _collection.ReplaceOneAsync(e => e.Id == @event.Id, @event);
            return @event;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
