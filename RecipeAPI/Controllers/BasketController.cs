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
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IMapper mapper, IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBaskets()
        {
            var baskets = _mapper.Map<List<BasketDTO>>(_basketRepository.GetBaskets());
            if(baskets == null || !ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(baskets);
        }

        [HttpGet("{basketId}")]
        public IActionResult GetBasket(int basketId)
        {
            var basket = _mapper.Map<BasketDTO>(_basketRepository.GetBasketById(basketId));
            
            if(basket == null || _basketRepository.BasketExists(basketId))
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(basket);

        }

        [HttpPost]
        public IActionResult CreateBasket([FromBody] BasketDTO createBasket)
        {
            if(createBasket == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var basket = _basketRepository.GetBaskets().Where(b => b.BasketId == createBasket.BasketId).FirstOrDefault();

            if(basket != null)
            {
                ModelState.AddModelError("", $"Basket with id: {createBasket.BasketId} already exists");
                return StatusCode(422, ModelState);
            }

            var basketMap = _mapper.Map<Basket>(createBasket);

            if (!_basketRepository.CreateBasket(basketMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the basket");
                return StatusCode(500, ModelState);
            }

            return Ok("Success");
        }

        [HttpPut("{basketId}")]
        public IActionResult UpdateBasket(int basketId, [FromBody] BasketDTO updateBasket)
        {
            if(updateBasket == null || basketId != updateBasket.BasketId || !ModelState.IsValid)
                return BadRequest(ModelState);

            var basket = _mapper.Map<Basket>(updateBasket);

            if (!_basketRepository.UpdateBasket(basket))
            {
                ModelState.AddModelError("", $"Something went wrong updating the basket");
                return StatusCode(500, ModelState);
            }

            return NoContent(); 
        }

        [HttpDelete("{basketId}")]
        public IActionResult DeleteBasket(int basketId)
        {
            if(!_basketRepository.BasketExists(basketId))
                return NotFound();

            var basket = _basketRepository.GetBasketById(basketId);

            if (!_basketRepository.DeleteBasket(basket))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the basket");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        })


    }
}
