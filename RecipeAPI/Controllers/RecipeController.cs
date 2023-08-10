using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Dto;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _recipeRepository = recipeRepository;
        }


        [HttpGet]
        public IActionResult GetAllRecipes()
        {
            try
            {
                List<RecipeDTO> recipes = _recipeRepository.GetRecipes()
                    .Select(recipe => _mapper.Map<RecipeDTO>(recipe))
                    .ToList();

                if (recipes == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(recipes);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetRecipe(int id)
        {
            var recipe = _mapper.Map<RecipeDTO>(_recipeRepository.GetRecipeById(id));

            if (recipe == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(recipe);

        }

        [HttpPost]
        public IActionResult CreateRecipe([FromBody] Recipe recipe)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _recipeRepository.CreateRecipe(recipe);

                return CreatedAtAction(nameof(GetRecipe), new { id = recipe.RecipeId }, recipe);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecipe(int id, [FromBody] Recipe recipe)
        {
            try
            {
                if (id != recipe.RecipeId)
                {
                    return BadRequest("Id mismatch between URL and recipe data.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _recipeRepository.UpdateRecipe(recipe);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            try
            {
                _recipeRepository.DeleteRecipe(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }

}
