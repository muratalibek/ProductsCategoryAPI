using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductsCategoryAPI.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ProductsCategoryAPI.Data
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Categories> _categories;
        private readonly IMongoCollection<ProductBuild> _productsBuild;

        public DbClient(IOptions<DataContext> dataContext)
        {
            var client = new MongoClient(dataContext.Value.Connection_String);

            var database = client.GetDatabase(dataContext.Value.Database_Name);
            _categories = database.GetCollection<Categories>(dataContext.Value.Categories_Collection_Name);
            _productsBuild = database.GetCollection<ProductBuild>(dataContext.Value.Product_Collection_Name);

        }
        public IMongoCollection<Categories> GetCategoriesCollection() => _categories;
        public IMongoCollection<ProductBuild> GetProductCollection() => _productsBuild;
    }
}
