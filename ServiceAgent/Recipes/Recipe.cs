using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Recipes
{
        public class Recipe
        {
            public List<Result>? Results { get; set; }
            public int TotalResults { get; set; }
        }
   
        public class Result
        {
            public int Id { get; set; }
            public string? Title { get; set; }
            public string? Image { get; set; }
            public string? ImageType { get; set; }
        }
    
}
