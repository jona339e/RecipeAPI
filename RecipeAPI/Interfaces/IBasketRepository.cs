using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface IBasketRepository
    {
        Basket GetBasketById(int basketId);
        void CreateBasket(Basket basket);
        void UpdateBasket(Basket basket);
        void DeleteBasket(int basketId);
    }
}
