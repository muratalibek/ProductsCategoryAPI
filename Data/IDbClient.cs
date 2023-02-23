using MongoDB.Driver;
using ProductsCategoryAPI.Models;

namespace ProductsCategoryAPI.Data
{
    public interface IDbClient
    {
        IMongoCollection<Categories> GetCategoriesCollection();
        IMongoCollection<ProductBuild> GetProductCollection();
    }
}
