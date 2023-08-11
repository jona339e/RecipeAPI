using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Models
{
    public class BasketItem
    {
        [Key]
        public int BasketItemId { get; set; }
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public string Measurement { get; set; }
        public virtual Basket Basket { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
