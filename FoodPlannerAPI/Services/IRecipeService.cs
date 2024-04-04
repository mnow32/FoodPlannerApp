using FoodPlannerAPI.Models;

namespace FoodPlannerAPI.Services
{
    public interface IRecipeService
    {
        Task<ApiResponseModel> GetRecipeListByQueryAsync(string query);
    }
}