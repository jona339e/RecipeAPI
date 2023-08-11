using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface ICuisineRepository
    {
        Cuisine GetCuisineById(int cuisineId);
        List<Cuisine> GetCuisines();
        bool CuisineExists(int cuisineId);
        bool Save();
        bool CreateCuisine(Cuisine cuisine);
        bool UpdateCuisine(Cuisine cuisine);
        bool DeleteCuisine(Cuisine cuisine);
    }
}
