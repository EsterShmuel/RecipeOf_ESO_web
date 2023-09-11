using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recipeOf_ESO_web.Models;
using recipeOf_ESO_web.Data;
using Microsoft.EntityFrameworkCore;

namespace recipeOf_ESO_web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly ApiContext _context;

        public RecipesController(ApiContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(personalRecipeBook recipe)
        {
            if (recipe.Id == 0)
            {
                _context.recipes.Add(recipe);
            }
            else
            {
                var bookingInDb = _context.recipes.Find(recipe.Id);

                if (bookingInDb == null)
                    return new JsonResult(NotFound());

                bookingInDb = recipe;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(recipe));

        }


        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.recipes.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.recipes.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.recipes.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // Get all
        [HttpGet()]
        public JsonResult GetAll()
        {
            var result = _context.recipes.ToList();

            return new JsonResult(Ok(result));
        }

        // PUT(update) 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, personalRecipeBook recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool RecipeExists(long id)
        {
            return (_context.recipes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
