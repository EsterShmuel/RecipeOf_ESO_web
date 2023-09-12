
using ServiceAgent.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Recipes
{
    public interface IRecipes
    {
        Task<Recipe> SearchRecipes(string ingredients);
        Task<Recipe> SearchRecipesByIngredients(List<string> ingredients);

        Task<List<InstructionsComponents>> getRecipeInstructions(int idRecipe);

        Task<ListComponent> IngredientsAmount(int idRecipe);
    }
}
