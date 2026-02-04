using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProjectCalendar.Domain.Entities;

namespace ProjectCalendar.Infrastructure.DataAccess
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoClient mongoClient, IConfiguration configuration)
        {
            var databaseName = configuration["MongoDbSettings:DatabaseName"] ?? "calendar_db";
            _database = mongoClient.GetDatabase(databaseName);
        }

        public IMongoCollection<Event> Events => _database.GetCollection<Event>("events");
    }
}
