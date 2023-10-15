
using ServiceAgent.Recipes;

namespace recipeOf_ESO_web.Models
{

    public class ChosenRecipe
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public List<Ingredient> ingredients { get; set; } //רשימת המרכיבים כולל כמות
        public List<Steps> instructions { get; set; }//רשימת ההוראות 

    }


    public class Ingredient
    {
        public string name  { get; set; }

        public double amount { get; set; }

        public string unit { get; set; }
    }

    public class Steps
    {
        public int nuber { get; set; }

        public string step { get; set; }
    }
}
