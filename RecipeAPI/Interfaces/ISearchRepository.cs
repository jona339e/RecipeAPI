using RecipeAPI.Dto;

namespace RecipeAPI.Interfaces
{
    public interface ISearchRepository
    {
        SearchResultDTO SearchRecipes(SearchDTO searchCriteria);
    }
}
