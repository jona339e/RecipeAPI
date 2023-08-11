using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly DataContext _dbContext;

        public BasketRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Basket GetBasketById(int basketId)
        {
            return _dbContext.Baskets.Find(basketId);
        }

        public bool CreateBasket(Basket basket)
        {
            _dbContext.Baskets.Add(basket);
            return Save();
        }

        public bool UpdateBasket(Basket basket)
        {
            _dbContext.Baskets.Update(basket);
            return Save();
        }

        public bool DeleteBasket(Basket basket)
        {
            _dbContext.Baskets.Remove(basket);
            return Save();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public bool BasketExists(int basketId)
        {
            return _dbContext.Baskets.Any(b => b.BasketId == basketId);
        }

        public ICollection<Basket> GetBaskets()
        {
            return _dbContext.Baskets.ToList();
        }
    }
}
