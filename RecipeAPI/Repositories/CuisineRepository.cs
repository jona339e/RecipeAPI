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

        public bool CreateCuisine(Cuisine cuisine)
        {
            _dbContext.Cuisines.Add(cuisine);
            return Save();

        }

        public bool CuisineExists(int cuisineId)
        {
            return _dbContext.Cuisines.Any(c => c.CuisineId == cuisineId);
        }

        public bool DeleteCuisine(Cuisine cuisine)
        {
            _dbContext.Cuisines.Remove(cuisine);
            return Save();
        }

        public Cuisine GetCuisineById(int cuisineId)
        {
            return _dbContext.Cuisines.Find(cuisineId);
        }

        public List<Cuisine> GetCuisines()
        {
            return _dbContext.Cuisines.ToList();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateCuisine(Cuisine cuisine)
        {
            _dbContext.Cuisines.Update(cuisine);
            return Save();
        }


    }
}
