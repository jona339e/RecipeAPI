using RecipeAPI.Dto;
using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface IRecipeRepository
    {
        List<Recipe> GetRecipes();
        Recipe GetRecipeById(int recipeId);
        void CreateRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        void DeleteRecipe(int recipeId);

    }
}
