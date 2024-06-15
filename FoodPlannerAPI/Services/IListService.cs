using FoodPlannerAPI.Models;

namespace FoodPlannerAPI.Services
{
    public interface IListService
    {
        Task<RecipeListModel> GetLatestListIdByUser(string id);
        Task<IEnumerable<RecipeListModel>> GetAllListsByUserIdAsync(string id);
        Task<IEnumerable<ListDetailsModel>> GetListDetailsById(int id);
    }
}