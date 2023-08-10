using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface ICuisineRepository
    {
        Cuisine GetCuisineById(int cuisineId);
        void CreateCuisine(Cuisine cuisine);
        void UpdateCuisine(Cuisine cuisine);
        void DeleteCuisine(int cuisineId);
    }
}
