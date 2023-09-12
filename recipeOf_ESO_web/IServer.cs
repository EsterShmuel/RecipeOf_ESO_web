using recipeOf_ESO_web.Models;
using ServiceAgent.Recipes;

namespace recipeOf_ESO_web
{
    public interface IServer
    {
        RecipesSearch searchRecipesByKeywords(string keywords);
        RecipesSearch searchRecipesByIngredientsBL(List<string> ingredients);
        ChosenRecipe recipeByID(Models.Result chosenResult);

    }
}
