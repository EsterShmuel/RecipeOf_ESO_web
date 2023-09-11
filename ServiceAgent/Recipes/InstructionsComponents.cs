using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Recipes
{
    public class InstructionsComponents
    {
       public List<Steps> steps {  get; set; }
    }

    public class Steps
    {
        public int number { get; set; }
        public string step {  get; set; }

        public List<Ingredient> ingredients {  get; set; }


    }

    public class Ingredient
    {
        public int id { get; set; }
        public string name { get; set; }

    }

}
