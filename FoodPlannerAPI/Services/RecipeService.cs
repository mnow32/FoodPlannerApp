using FoodPlannerAPI.Models;
using System.Collections;

namespace FoodPlannerAPI.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public RecipeService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }
        
        public async Task<ApiResponseModel> GetRecipesAsync()
        {
            ApiResponseModel? recipes = new();

            var client = _clientFactory.CreateClient();

            string? apiKey = _configuration["ApiKey"];

            string address = $"https://api.spoonacular.com/recipes/complexSearch?apiKey={apiKey}&number=20";

            recipes = await client.GetFromJsonAsync<ApiResponseModel>(address);

            return recipes!;
        }
    }
}
