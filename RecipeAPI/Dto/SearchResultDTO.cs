using RecipeAPI.Models;

namespace RecipeAPI.Dto
{
    public class SearchResultDTO
    {
        public List<Recipe> MatchingRecipes { get; set; }
    }
}
