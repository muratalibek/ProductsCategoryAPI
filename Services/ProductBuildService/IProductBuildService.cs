using ProductsCategoryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsCategoryAPI.Services.ProductBuildService
{
    public interface IProductBuildService
    {
        List<ProductBuild> GetAllProducts();
        ProductBuild AddProduct(ProductBuild product);
        void DeleteProduct(string id);
        Task<List<ProductBuild>> SearchByPropertyAsync(string productName, string value);
    }
}
