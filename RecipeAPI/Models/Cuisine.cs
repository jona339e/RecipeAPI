using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Models
{
    public class Cuisine
    {
        [Key]
        public int CuisineId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
