using FoodPlannerAPI.Models;
using System.Collections;

namespace FoodPlannerAPI.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private const string defaultAddress = "https://api.spoonacular.com/recipes";

        public RecipeService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }
        
        public async Task<ApiResponseModel> GetRecipeListByQueryAsync(string query)
        {
            ApiResponseModel? recipes = new();

            var client = _clientFactory.CreateClient();

            string? apiKey = _configuration["apikey"];

            string address = $"{defaultAddress}/complexSearch?apiKey={apiKey}{query}";

            // TODO: Error handling

            recipes = await client.GetFromJsonAsync<ApiResponseModel>(address);

            return recipes!;
        }

        public async Task<RecipeDetailsModel> GetRecipeDetailsByIdAsync(int id)
        {
            RecipeDetailsModel? recipeDetails = new();

            var client = _clientFactory.CreateClient();

            string? apiKey = _configuration["apikey"];

            string address = $"{defaultAddress}/{id}/information?apiKey={apiKey}";

            // TODO: error handling

            recipeDetails = await client.GetFromJsonAsync<RecipeDetailsModel>(address);
                        
            return recipeDetails!;
        }
    }
}
