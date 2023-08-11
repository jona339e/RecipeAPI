using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Models
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }

}
