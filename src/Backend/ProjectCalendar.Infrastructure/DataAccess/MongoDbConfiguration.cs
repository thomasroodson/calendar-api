using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using ProjectCalendar.Domain.Entities;
using ProjectCalendar.Domain.ValueObjects;

namespace ProjectCalendar.Infrastructure.DataAccess
{
    public static class MongoDbConfiguration
    {
        private static bool _isConfigured = false;

        public static void Configure()
        {
            if (_isConfigured)
                return;

            BsonClassMap.RegisterClassMap<Event>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<DateRange>(cm =>
            {
                cm.AutoMap();
                cm.MapProperty(x => x.StartDate);
                cm.MapProperty(x => x.EndDate);
                cm.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<EventColor>(cm =>
            {
                cm.AutoMap();
                cm.MapProperty(x => x.Value);
                cm.SetIgnoreExtraElements(true);
            });

            _isConfigured = true;
        }
    }
}
