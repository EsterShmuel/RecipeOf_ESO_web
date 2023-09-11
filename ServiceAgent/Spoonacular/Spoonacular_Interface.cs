using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Spoonacular
{
    public interface Spoonacular_Interface
    {
        Task<Recipe> SearchRecipes(string ingredients);
        Task<Recipe> SearchRecipesByIngredients(string ingredients);

    }
}
