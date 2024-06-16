using FoodPlannerAPI.Models;

namespace FoodPlannerAPI.Services
{
    public interface IListService
    {
        Task<RecipeListModel> GetLatestListByUserIdAsync(string id);
        Task<IEnumerable<RecipeListModel>> GetAllListsByUserIdAsync(string id);
    }
}