using FoodPlannerAPI.Models;

namespace FoodPlannerAPI.Services
{
    public interface IListService
    {
        Task<RecipeListModel> GetLatestListIdByUserIdAsync(string id);
        Task<IEnumerable<RecipeListModel>> GetAllListsByUserIdAsync(string id);
    }
}