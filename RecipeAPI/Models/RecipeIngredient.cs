using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Models
{
    public class RecipeIngredient
    {
        [Key]
        public int RecipeIngredientId { get; set; }

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        // Add more properties as needed
    }

}
