using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Dto;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientController(IIngredientRepository ingredientRepository, IMapper mapper)
        {

            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetIngredients()
        {
            var ingredients = _mapper.Map<List<IngredientDTO>>(_ingredientRepository.GetIngredients());

            if (ingredients == null)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ingredients);
        }

        [HttpGet("{ingredientId}")]
        public IActionResult GetIngredient(int ingredientId)
        {
            var ingredient = _mapper.Map<IngredientDTO>(_ingredientRepository.GetIngredientById(ingredientId));

            if (ingredient == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ingredient);
        }


        [HttpPost]
        public IActionResult CreateIngredient([FromBody] IngredientDTO ingredientCreate)
        {
            if(ingredientCreate == null)
                return BadRequest(ModelState);
            
            var ingredient = _ingredientRepository.GetIngredients()
                .Where(i => i.Name.TrimEnd().ToUpper() == ingredientCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (ingredient != null)
            {
                ModelState.AddModelError("", $"Ingredient {ingredientCreate.Name} already exists.");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredientMap = _mapper.Map<Ingredient>(ingredientCreate);

            if(!_ingredientRepository.CreateIngredient(ingredientMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving {ingredientCreate.Name}.");
                return StatusCode(500, ModelState);
            }

            return Ok("Success");

        }



        [HttpPut("{ingredientId}")]
        public IActionResult UpdateIngredient(int ingredientId, [FromBody] IngredientDTO updateIngredient)
        {

            if(updateIngredient == null || ingredientId != updateIngredient.IngredientId || !ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredient = _mapper.Map<Ingredient>(updateIngredient);

            if(!_ingredientRepository.UpdateIngredient(ingredient))
            {
                ModelState.AddModelError("", $"Something went wrong updating {updateIngredient.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{ingredientId}")]
        public IActionResult DeleteIngredient(int ingredientId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredient = _ingredientRepository.GetIngredientById(ingredientId);

            if (!_ingredientRepository.DeleteIngredient(ingredient))
            {
                ModelState.AddModelError("", $"Something went wrong deleting {ingredient.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }



    }
}
