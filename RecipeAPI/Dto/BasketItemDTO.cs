namespace RecipeAPI.Dto
{
    public class BasketItemDTO
    {
        public int BasketItemId { get; set; }
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public string Measurement { get; set; }
    }
}
