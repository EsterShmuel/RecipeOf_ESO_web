using Microsoft.EntityFrameworkCore;
using recipeOf_ESO_web.Models;

namespace recipeOf_ESO_web.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<personalRecipeBook> recipes { get; set;} = null!;
    }
}
