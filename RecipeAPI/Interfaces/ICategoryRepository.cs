using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int categoryId);
        List<Category> GetCategories();
        bool CategoryExists(int categoryId);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }
}
