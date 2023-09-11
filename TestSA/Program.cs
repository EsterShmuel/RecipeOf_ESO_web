using ServiceAgent.Spoonacular;

namespace TestSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Spoonacular_Interface IS = new SpoonacularApiClient();

            Recipe r = IS.SearchRecipes("chicken").GetAwaiter().GetResult();

            Console.WriteLine(r);
        }
    }
}