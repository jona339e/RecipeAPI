using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Dto;
using RecipeAPI.Interfaces;

namespace RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchRepository _searchRepository;

        public SearchController(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        [HttpGet]
        public IActionResult SearchRecipes([FromQuery] SearchDTO searchCriteria)
        {
            try
            {
                SearchResultDTO searchResult = _searchRepository.SearchRecipes(searchCriteria);

                if (searchResult.MatchingRecipes.Count == 0)
                {
                    return NotFound("No recipes match the search criteria.");
                }

                return Ok(searchResult);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }

}
