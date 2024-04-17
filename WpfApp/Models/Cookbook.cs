using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfApp.Models
{
    public class Cookbook
    {
        public MyRecipes _myRecipes;

        public Cookbook(MyRecipes myRecipes)
        {
            _myRecipes = myRecipes;
        }

        /// <summary>
        /// Get all recipes.
        /// </summary>
        /// <returns>All recipes in my Cookbook.</returns>
        public async Task<IEnumerable<MyRecipe>> GetAllRecipes()
        {
            return await _myRecipes.GetAllRecipes();
        }
    }
}
