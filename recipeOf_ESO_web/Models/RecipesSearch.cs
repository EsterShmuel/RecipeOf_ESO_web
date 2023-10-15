namespace recipeOf_ESO_web.Models
{
    public class RecipesSearch
    {
        public List<Result>? Results { get; set; }
        public int TotalResults { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? ImageType { get; set; }
    }
}
