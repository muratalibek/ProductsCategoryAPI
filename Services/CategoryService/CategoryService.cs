using MongoDB.Driver;
using ProductsCategoryAPI.Data;
using ProductsCategoryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsCategoryAPI.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Categories> _categories;
        public CategoryService(IDbClient dbClient)
        {
            _categories = dbClient.GetCategoriesCollection();
        }

        public List<Categories> GetAllCategories()
        {
            return _categories.Find(x => true).ToList();
        }
        public Categories AddCategory(Categories category)
        {
            _categories.InsertOne(category);
            return category;
        }

        public void DeleteCategory(string id)
        {
            _categories.DeleteOne(category => category.Id == id);
        }
    }
}
