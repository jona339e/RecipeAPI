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

        public void CreateIngredient(Ingredient ingredient)
        {
            _dbContext.Ingredients.Add(ingredient);
            _dbContext.SaveChanges();
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            _dbContext.Entry(ingredient).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteIngredient(int ingredientId)
        {
            Ingredient ingredient = _dbContext.Ingredients.Find(ingredientId);
            if (ingredient != null)
            {
                _dbContext.Ingredients.Remove(ingredient);
                _dbContext.SaveChanges();
            }
        }
    }
}
