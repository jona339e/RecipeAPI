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
    public class CuisineController : ControllerBase
    {
        private readonly ICuisineRepository _cuisineRepository;
        private readonly IMapper _mapper;

        public CuisineController(ICuisineRepository cuisineRepository, IMapper mapper)
        {
            _cuisineRepository = cuisineRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCuisines()
        {
            var cuisines = _mapper.Map<List<CuisineDTO>>(_cuisineRepository.GetCuisines());
            if(cuisines == null || !ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(cuisines);
        }

        [HttpGet("{cuisineId}")]
        public IActionResult GetCuisine(int cuisineId)
        {
            var cuisine = _mapper.Map<CuisineDTO>(_cuisineRepository.GetCuisineById(cuisineId));
            
            if(cuisine == null || _cuisineRepository.CuisineExists(cuisineId))
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cuisine);

        }

        [HttpPost]
        public IActionResult CreateCuisine([FromBody] CuisineDTO createCuisine)
        {
            if(createCuisine == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var cuisine = _cuisineRepository.GetCuisines().Where(c => c.Name == createCuisine.Name).FirstOrDefault();

            if(cuisine != null)
            {
                ModelState.AddModelError("", $"Cuisine with id: {createCuisine.CuisineId} already exists");
                return StatusCode(422, ModelState);
            }

            cuisine = _mapper.Map<Cuisine>(createCuisine);

            if(!_cuisineRepository.CreateCuisine(cuisine))
            {
                ModelState.AddModelError("", $"Something went wrong saving {cuisine.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Success");

        }

        [HttpPut("{cuisineId}")]
        public IActionResult UpdateCuisine(int cuisineId, [FromBody] CuisineDTO updateCuisine)
        {
            if(updateCuisine == null || cuisineId != updateCuisine.CuisineId || !ModelState.IsValid)
                return BadRequest(ModelState);

            var cuisine = _mapper.Map<Cuisine>(updateCuisine);

            if(!_cuisineRepository.UpdateCuisine(cuisine))
            {
                ModelState.AddModelError("", $"Something went wrong updating {cuisine.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpDelete("{cuisineId}")]
        public IActionResult DeleteCuisine(int cuisineId)
        {
            if(!_cuisineRepository.CuisineExists(cuisineId))
                return NotFound();

            var cuisine = _cuisineRepository.GetCuisineById(cuisineId);

            if(!_cuisineRepository.DeleteCuisine(cuisine))
            {
                ModelState.AddModelError("", $"Something went wrong deleting {cuisine.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

    }
}
