using RecipeAPI.Models;

namespace RecipeAPI.Dto
{
    public class BasketDTO
    {
        public int BasketId { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }


    }
}
