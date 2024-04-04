using FoodPlannerAPI.Models;
using FoodPlannerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("query")]
        public async Task<IActionResult> GetRecipes([FromQuery] int id, [FromQuery] string name)
        {
            string _name = name;
            int _id = id;

            //var response = await _recipeService.GetRecipesAsync();
            /*if(response is not null)
            {
                return Ok(response);
            }
            return NotFound();*/
            return Ok();
        }
    }
}
