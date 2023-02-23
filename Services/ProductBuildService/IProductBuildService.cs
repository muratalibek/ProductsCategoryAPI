using ProductsCategoryAPI.Models;
using System.Collections.Generic;

namespace ProductsCategoryAPI.Services.ProductBuildService
{
    public interface IProductBuildService
    {
        List<ProductBuild> GetAllProducts();
        ProductBuild AddProduct(ProductBuild product);
        void DeleteProduct(string id);
    }
}
