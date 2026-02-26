using ConnectToMongoAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ConnectToMongoAPI.Contexts
{
    public class MongoDbContext
    {
        public readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Product>  Products => _database.GetCollection<Product>("Products");

    }
}
