using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Models
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }

        // Add more properties as needed

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }

}
