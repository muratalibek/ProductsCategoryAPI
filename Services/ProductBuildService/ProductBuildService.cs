using MongoDB.Driver;
using ProductsCategoryAPI.Data;
using ProductsCategoryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProductsCategoryAPI.Services.ProductBuildService
{
    public class ProductBuildService : IProductBuildService
    {
        private readonly IMongoCollection<ProductBuild> _productCollection;
        public ProductBuildService(IDbClient dbClient)
        {
            _productCollection = dbClient.GetProductCollection();
        }
        public async Task<List<ProductBuild>> SearchByPropertyAsync(string productName, string value)
        {
            var filter = Builders<ProductBuild>.Filter.Eq(productName, value);
            return await _productCollection.Find(filter).ToListAsync();
        }
        public List<ProductBuild> GetAllProducts()
        {
            return _productCollection.Find(FilterDefinition<ProductBuild>.Empty).ToList();
        }
        public ProductBuild AddProduct(ProductBuild product)
        {
            //if (String.IsNullOrEmpty(image.base64String))
            //    image.Photo = Convert.FromBase64String(image.base64String);
            var productDb = _productCollection.Find(x => x.Id == product.Id).FirstOrDefault();
            if (productDb == null)
            {
                _productCollection.InsertOne(product);
            }
            else
            {
                _productCollection.ReplaceOne(x => x.Id == product.Id, product);
            }
            return product;
        }

        public void DeleteProduct(string id)
        {
            _productCollection.DeleteOne(product => product.Id == id);
        }
    }
}
