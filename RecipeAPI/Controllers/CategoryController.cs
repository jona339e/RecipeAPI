using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Dto;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;
using RecipeAPI.Repositories;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories();
            if (categories == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetCategory(int categoryId)
        {
            var category = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetCategoryById(categoryId));

            if (category == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDTO createCategory)
        {
            if(createCategory == null)
            {
                return BadRequest(ModelState);
            }

            var category = _categoryRepository.GetCategories()
                .Where(c => c.Name.Trim().ToLower() == createCategory.Name.Trim().ToLower())
                .FirstOrDefault();

            if (category == null)
            {
                ModelState.AddModelError("", $"Category {createCategory.Name} already exists");
                return StatusCode(422, ModelState);
            }

            var categoryMap = _mapper.Map<Category>(createCategory);

            if(!_categoryRepository.CreateCategory(categoryMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving {categoryMap.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Success");
        }

        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryDTO updateCategory)
        {
            if(updateCategory == null || categoryId != updateCategory.CategoryId || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!_categoryRepository.CategoryExists(categoryId))
            {
                return NotFound();
            }

            var categoryMap = _mapper.Map<Category>(updateCategory);
            
            if(!_categoryRepository.UpdateCategory(categoryMap))
            {
                ModelState.AddModelError("", $"Something went wrong updating {categoryMap.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            if(!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = _categoryRepository.GetCategoryById(categoryId);

            if(!_categoryRepository.DeleteCategory(category))
            {
                ModelState.AddModelError("", $"Something went wrong deleting {category.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
