using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class MyRecipes
    {
        public List<MyRecipe> _recipes;

        public MyRecipes()
        {
            _recipes = new List<MyRecipe>();
        }

        public async Task<IEnumerable<MyRecipe>> GetAllRecipes()
        {
            return _recipes;    
        }


        public async Task AddRecipe(MyRecipe myRecipe)
        {

            foreach (var recipe in _recipes)
                {
                if (recipe.Conflict(myRecipe))
                    throw new Exception(); 
                }

            _recipes.Add(myRecipe);
        }
    }
}
