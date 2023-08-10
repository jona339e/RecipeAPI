using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Dto;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DataContext _dbContext;

        public RecipeRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Recipe GetRecipeById(int recipeId)
        {
            return _dbContext.Recipes.Find(recipeId);
        }


        public void CreateRecipe(Recipe recipe)
        {
            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _dbContext.Entry(recipe).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteRecipe(int recipeId)
        {
            Recipe recipe = _dbContext.Recipes.Find(recipeId);
            if (recipe != null)
            {
                _dbContext.Recipes.Remove(recipe);
                _dbContext.SaveChanges();
            }
        }

        public List<Recipe> GetRecipes()
        {
            return _dbContext.Recipes.ToList();
        }
    }
}
