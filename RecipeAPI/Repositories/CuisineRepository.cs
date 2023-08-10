using Microsoft.EntityFrameworkCore;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;
using RecipeAPI.Data;

namespace RecipeAPI.Repositories
{
    public class CuisineRepository : ICuisineRepository
    {
        private readonly DataContext _dbContext;

        public CuisineRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Cuisine GetCuisineById(int cuisineId)
        {
            return _dbContext.Cuisines.Find(cuisineId);
        }

        public void CreateCuisine(Cuisine cuisine)
        {
            _dbContext.Cuisines.Add(cuisine);
            _dbContext.SaveChanges();
        }

        public void UpdateCuisine(Cuisine cuisine)
        {
            _dbContext.Entry(cuisine).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void DeleteCuisine(int cuisineId)
        {
            Cuisine cuisine = _dbContext.Cuisines.Find(cuisineId);
            if (cuisine != null)
            {
                _dbContext.Cuisines.Remove(cuisine);
                _dbContext.SaveChanges();
            }
        }
    }






}
