using recipeOf_ESO_web.Models;
using ServiceAgent.Recipes;
using System.Reflection;

namespace recipeOf_ESO_web
{
    public class ServerObject : IServer
    {
        internal readonly IRecipes RecipeObject = new RecipesSpoonacular();
        #region Returning recipes by Keywords using ServiceAgent
        public RecipesSearch searchRecipesByKeywords(string keywords)
        {
            RecipesSearch recipesSearch = new RecipesSearch();
            try
            {
                ServiceAgent.Recipes.Recipe recipesList = RecipeObject.SearchRecipes(keywords).GetAwaiter().GetResult();
                recipesSearch.Results = new List<Models.Result>();
                //recipesSearch = (Models.RecipesSearch)recipesList.CopyPropertiesToNew(typeof(Models.RecipesSearch));
                foreach (var result in recipesList.Results)
                {
                    recipesSearch.Results.Add(new Models.Result()
                    {

                        Id = result.Id,
                        Title = result.Title,
                        Image = result.Image,
                        ImageType = result.ImageType
                    });
                }
                return recipesSearch;
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"Incorrect conversion: {e.Message}");
            }
        }
        #endregion

        #region Returning recipes by ingredients using ServiceAgent
        public Models.RecipesSearch searchRecipesByIngredientsBL(List<string> ingredients)
        {
            Models.RecipesSearch recipesSearch = new Models.RecipesSearch();

            try
            {
                ServiceAgent.Recipes.Recipe recipesList = RecipeObject.SearchRecipesByIngredients(ingredients).GetAwaiter().GetResult();
                recipesSearch = (Models.RecipesSearch)recipesList.CopyPropertiesToNew(typeof(Models.RecipesSearch));
                //recipesList.Results.CopyPropertiesToIEnumerable(recipesSearch.Results);
                recipesSearch.Results = new List<Models.Result> ();
                foreach ( var result in recipesList.Results)
                {
                    recipesSearch.Results.Add(new Models.Result() {

                    Id= result.Id,
                    Title = result.Title,
                    Image = result.Image,
                    ImageType = result.ImageType
                    });
                }
                return recipesSearch;
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"Incorrect conversion: {e.Message}");
            }
           
        }
        #endregion

        #region Returning a full recipe - list of ingredients with quantity, and with a list of instructions and steps
        public ChosenRecipe recipeByID(Models.Result chosenResult)
        {
            Models.ChosenRecipe chosenRecipe = new ChosenRecipe();
            chosenRecipe.ingredients = new List<Models.Ingredient>();
            chosenRecipe.instructions= new List<Models.Steps> ();

            try
            {
                ServiceAgent.Recipes.InstructionsComponents instructionsComponents = RecipeObject.getRecipeInstructions(chosenResult.Id).GetAwaiter().GetResult();
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

                foreach (var instruction in instructionsComponents.steps)
                {
                    chosenRecipe.instructions.Add(new Models.Steps
                    {
                        nuber = instruction.number,
                        step = instruction.step
                    });
                }

                return chosenRecipe;

            }
            catch (Exception e)
            {
                throw new HttpRequestException($"Incorrect conversion: {e.Message}");
            }


        }
        #endregion
    }
}
