using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp.Models
{
    public class MyRecipe
    {
        public RecipesID _recipesID { get; }
        public int _stars { get; }
        public string _comments { get; }
        public List<Image> _myImage { get; }

        //בכל שימוש במתכון נוסיף אוביקט הזה את התאריך 
        public List<DateTime> _usedRecipeDates { get; }


        public MyRecipe(RecipesID recipesID, int stars, string comments,List<Image> image, List<DateTime> usedRecipeDates)
        {
            _recipesID = recipesID;
            _stars = stars;
            _comments = comments;
            _myImage = image;
            _usedRecipeDates = usedRecipeDates;
        }
        public bool Conflict(MyRecipe myRecipe)
        {
            if (_recipesID != myRecipe._recipesID)
            {
                return false;
            }
            return true;
        }
    }
}
