namespace RecipeAPI.Dto
{
    public class SearchDTO
    {
        public string SearchText { get; set; }
        public string Name { get; set; }
        public string Ingredient { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Cuisines { get; set; }
    }
}
