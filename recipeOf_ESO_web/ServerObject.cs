using recipeOf_ESO_web.Models;
using ServiceAgent.Recipes;
using System.Reflection;

namespace recipeOf_ESO_web
{
    public class ServerObject : IServer
    {
        internal readonly IRecipes RecipeObject;
        #region Returning recipes by Keywords using ServiceAgent
        public RecipesSearch searchRecipesByKeywords(string keywords)
        {
            RecipesSearch recipesSearch = new RecipesSearch();
            try
            {
                ServiceAgent.Recipes.Recipe recipesList = RecipeObject.SearchRecipes(keywords).GetAwaiter().GetResult();
                recipesSearch = (Models.RecipesSearch)recipesList.CopyPropertiesToNew(typeof(Models.RecipesSearch));
                return recipesSearch;
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"Incorrect conversion: {e.Message}");
            }
        }
        #endregion

        #region Returning recipes by ingredients using ServiceAgent
        public RecipesSearch searchRecipesByIngredientsBL(List<string> ingredients)
        {
            RecipesSearch recipesSearch = new RecipesSearch();
            try
            {
                ServiceAgent.Recipes.Recipe recipesList = RecipeObject.SearchRecipesByIngredients(ingredients).GetAwaiter().GetResult();
                recipesSearch = (Models.RecipesSearch)recipesList.CopyPropertiesToNew(typeof(Models.RecipesSearch));
                return recipesSearch;
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"Incorrect conversion: {e.Message}");
            }
           
        }
        #endregion

        public ChosenRecipe recipeByID(Models.Result chosenResult)
        {
            Models.ChosenRecipe chosenRecipe = new ChosenRecipe();
            try
            {
                List<ServiceAgent.Recipes.InstructionsComponents> instructionsList = RecipeObject.getRecipeInstructions(chosenResult.Id).GetAwaiter().GetResult();
                ServiceAgent.Recipes.ListComponent componentList = RecipeObject.IngredientsAmount(chosenResult.Id).GetAwaiter().GetResult();

                chosenRecipe.id = chosenResult.Id;
                chosenRecipe.title = chosenResult.Title;
                chosenRecipe.image = chosenResult.Image;
                chosenRecipe.imageType = chosenResult.ImageType;

                foreach (var ingredient in componentList.ingredients)
                {
                    chosenRecipe.ingredients.Add(new Models.Ingredient
                    {
                        name = ingredient.Name,
                        amount = ingredient.Amount.Metric.Value,
                        unit = ingredient.Amount.Metric.Unit
                    });
                }

                foreach (var instruction in instructionsList)
                {
                    chosenRecipe.instructions.Add(new Models.Steps
                    {
                        nuber = 
                    });
                }



            }
            catch (Exception e)
            {
                throw new HttpRequestException($"Incorrect conversion: {e.Message}");
            }


        }
    }
}
