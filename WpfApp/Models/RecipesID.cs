using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class RecipesID
    {
        private int id { get; }
        public string title { get; }
        public string image { get; }
        public string imageType { get; }
        private List<Ingredient> ingredients { get; } //רשימת המרכיבים כולל כמות
        private List<Steps> instructions { get; }//רשימת ההוראות 




        internal class Ingredient
        {
            public string name { get; }

            public double amount { get; }

            public string unit { get; }
        }

        internal class Steps
        {
            public int nuber { get; }

            public string step { get; }
        }
    }
}
