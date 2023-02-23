using ProductsCategoryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsCategoryAPI.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Categories> GetAllCategories();
        Categories AddCategory(Categories category);
        void DeleteCategory(string id);
    }
}
