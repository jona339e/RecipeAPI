using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Dto
{
    public class RecipeDTO
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
    }
}
