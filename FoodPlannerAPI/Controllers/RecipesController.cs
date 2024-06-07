using FoodPlannerAPI.Models;
using FoodPlannerAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize]
        public async Task<IActionResult> GetRecipes()
        {
            string? query = HttpContext.Request.QueryString.Value;

            if (query is null)
            {
                query = "";
            }
            else
            {
                query = query.Replace('?', '&');
            }

            var response = await _recipeService.GetRecipeListByQueryAsync(query!);

            if (response is not null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeDetails(int id)
        {
            var response = await _recipeService.GetRecipeDetailsByIdAsync(id);

            if (response is not null)
            {
                return Ok(response);
            }

            return NotFound();
        }
    }
}
