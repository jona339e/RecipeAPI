using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface IIngredientRepository
    {
        Ingredient GetIngredientById(int ingredientId);
        bool CreateIngredient(Ingredient ingredient);
        bool UpdateIngredient(Ingredient ingredient);
        bool DeleteIngredient(Ingredient ingredient);
        List<Ingredient> GetIngredients();
        bool Save();
    }
}
