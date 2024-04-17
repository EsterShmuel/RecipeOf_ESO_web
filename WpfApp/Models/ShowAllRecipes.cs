using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    internal class ShowAllRecipes
    {
        public class AllRecipes
        {
            public List<Details>? Results { get; set; }
            public int TotalResults { get; set; }
        }

        public class Details
        {
            public int Id { get; set; }
            public string? Title { get; set; }
            public string? Image { get; set; }
            public string? ImageType { get; set; }
        }
    }
}
