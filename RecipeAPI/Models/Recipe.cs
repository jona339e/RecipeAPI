using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Instructions { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Cuisine> Cuisines { get; set; }
    }
}
