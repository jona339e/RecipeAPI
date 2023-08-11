using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dbContext;

        public CategoryRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _dbContext.Categories.Find(categoryId);
        }

        public bool CreateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            return Save();
        }

        public bool UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _dbContext.Categories.Remove(category);
            return Save();

        }

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public bool CategoryExists(int categoryId)
        {
            return _dbContext.Categories.Any(c => c.CategoryId == categoryId);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        // Implement other methods
    }

}
