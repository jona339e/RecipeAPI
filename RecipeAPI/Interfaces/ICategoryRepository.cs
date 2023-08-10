﻿using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int categoryId);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
    }
}
