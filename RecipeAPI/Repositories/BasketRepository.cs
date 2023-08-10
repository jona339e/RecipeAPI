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

        public void CreateBasket(Basket basket)
        {
            _dbContext.Baskets.Add(basket);
            _dbContext.SaveChanges();
        }

        public void UpdateBasket(Basket basket)
        {
            _dbContext.Entry(basket).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteBasket(int basketId)
        {
            Basket basket = _dbContext.Baskets.Find(basketId);
            if (basket != null)
            {
                _dbContext.Baskets.Remove(basket);
                _dbContext.SaveChanges();
            }
        }

    }
}
