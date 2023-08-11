using RecipeAPI.Models;

namespace RecipeAPI.Dto
{
    public class BasketDTO
    {
        public int BasketId { get; set; }
        public List<BasketItemDTO> BasketItems { get; set; }


    }
}
