using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrderAPIAdminsManager.Model;
using OrderManagementAPI.Entities;

namespace OrderManagementAPI.Repositories
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<MongoDbSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            _database = client.GetDatabase(databaseSettings.Value.DatabaseName);
        }

        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
        public IMongoCollection<User> ApiUsers => _database.GetCollection<User>("ApiUsers");

    }

    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
