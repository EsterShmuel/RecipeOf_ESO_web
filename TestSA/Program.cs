
using ServiceAgent.Recipes;

namespace TestSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRecipes IS = new RecipesSpoonacular();

            //Recipe r = IS.SearchRecipes("chicken").GetAwaiter().GetResult();

            // Console.WriteLine(r);

            //List<InstructionsComponents> instructionsComponents = IS.getRecipeInstructions(4632).GetAwaiter().GetResult();

            //InstructionsComponents firstInstruction = instructionsComponents.FirstOrDefault();
            //if (firstInstruction != null)
            //{
            //    List<Steps> steps = firstInstruction.steps;
            //    foreach (var step in steps)
            //    {
            //        Console.WriteLine($"Step {step.number}: {step.step}");
            //    }
            //}
  
            Recipe recipe = IS.SearchRecipesByIngredients(new List<string>{"apples","flour","sugar"}).GetAwaiter().GetResult();

        }
    }
}