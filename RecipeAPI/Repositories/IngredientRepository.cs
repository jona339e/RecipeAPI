using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DataContext _dbContext;

        public IngredientRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Ingredient GetIngredientById(int ingredientId)
        {
            return _dbContext.Ingredients.Find(ingredientId);
        }

        public bool CreateIngredient(Ingredient ingredient)
        {
            _dbContext.Ingredients.Add(ingredient);
            return Save();
        }

        public bool UpdateIngredient(Ingredient ingredient)
        {
            _dbContext.Ingredients.Update(ingredient);
            return Save();
        }

        public bool DeleteIngredient(Ingredient ingredient)
        {
            _dbContext.Remove(ingredient);
            return Save();
        }

        public List<Ingredient> GetIngredients()
        {
            return _dbContext.Ingredients.ToList();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
    }
}
