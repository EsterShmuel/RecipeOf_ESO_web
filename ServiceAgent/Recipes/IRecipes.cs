
using ServiceAgent.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Spoonacular
{
    public interface IRecipes
    {
        Task<Recipe> SearchRecipes(string ingredients);

        Task<Recipe> SearchRecipesByIngredients(List<string> ingredients);

        Task<InstructionsComponents> getRecipeInstructions(int idRecipe);

        Task<ListComponent> IngredientsAmount(int idRecipe);
    }
}
