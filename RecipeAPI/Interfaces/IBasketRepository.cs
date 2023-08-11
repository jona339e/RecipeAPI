using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface IBasketRepository
    {
        ICollection<Basket> GetBaskets();
        Basket GetBasketById(int basketId);
        bool BasketExists(int basketId);
        bool CreateBasket(Basket basket);
        bool UpdateBasket(Basket basket);
        bool DeleteBasket(Basket basket);
        bool Save();
    }
}
