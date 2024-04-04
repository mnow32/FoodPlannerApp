using FoodPlannerAPI.Models;

namespace FoodPlannerAPI.Services
{
    public interface IRecipeService
    {
        Task<ApiResponseModel> GetRecipesAsync();
    }
}