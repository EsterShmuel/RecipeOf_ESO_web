
using ServiceAgent.Recipes;
using recipeOf_ESO_web;
using recipeOf_ESO_web.Models;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;

namespace TestSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IRecipes IS = new RecipesSpoonacular();

            //Recipe r = IS.SearchRecipes("chicken").GetAwaiter().GetResult();

            // Console.WriteLine(r);

            InstructionsComponents instructionsComponents = IS.getRecipeInstructions(4632).GetAwaiter().GetResult();
            //InstructionsComponents firstInstruction = instructionsComponents.FirstOrDefault();
            //InstructionsComponents firstInstruction = instructionsComponents.FirstOrDefault();
            //if (firstInstruction != null)
            //{
            //    List<Steps> steps = firstInstruction.steps;
            //    foreach (var step in steps)
            //    {
            //        Console.WriteLine($"Step {step.number}: {step.step}");
            //    }
            //}

            //Recipe recipe = IS.SearchRecipesByIngredients(new List<string>{"apples","flour","sugar"}).GetAwaiter().GetResult();

            IServer server = new ServerObject();

            recipeOf_ESO_web.Models.Result chosenResult = new recipeOf_ESO_web.Models.Result();
            chosenResult.Id = 4632;
            chosenResult.Title = "Banan";
            chosenResult.Image = "https://spoonacular.com/recipeImages/651773-312x231.jpg";
            chosenResult.ImageType = "jpg";
            //ChosenRecipe chosenRecipe= server.recipeByID(chosenResult);

            List<string> strings = new List<string>();
            string inputString = "apples,flour,sugar";
            // Split the input string by commas and add the resulting elements to the list
            strings.AddRange(inputString.Split(','));

            recipeOf_ESO_web.Models.RecipesSearch recipesSearch= new RecipesSearch();
            //recipesSearch = server.searchRecipesByIngredientsBL(strings);    
            recipesSearch = server.searchRecipesByKeywords("chicken");
        }
    }
}