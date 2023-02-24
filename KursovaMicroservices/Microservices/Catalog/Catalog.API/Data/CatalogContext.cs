using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; set; }

        public CatalogContext(IConfiguration configuration)
        {
            var conntectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            var databaseName = configuration.GetValue<string>("DatabaseSettings:DatabaseName");


            var client = new MongoClient(conntectionString);
            var database = client.GetDatabase(databaseName);

            var xd = (configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            Products = database.GetCollection<Product>(xd);

            //CatalogContextSeed.SeedData(Products);
        }
    }
}
