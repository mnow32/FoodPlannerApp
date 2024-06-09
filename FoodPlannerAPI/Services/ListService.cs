using FoodPlannerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections;

namespace FoodPlannerAPI.Services
{
    public class ListService : IListService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _appDbContext;

        public ListService(IConfiguration configuration, AppDbContext appDbContext)
        {
            _configuration = configuration;
            _appDbContext = appDbContext;
        }
        
        public async Task<RecipeListModel> GetNewListByUserIdAsync(string id)
        {
            var lists = await _appDbContext.RecipeList.ToListAsync();
            RecipeListModel? list = lists.Where(list => list.User == id).FirstOrDefault();
            return list!;
        }

        public async Task<IEnumerable<RecipeListModel>> GetAllListsByUserIdAsync(string id)
        {
            var lists = await _appDbContext.RecipeList.ToListAsync();
            IEnumerable<RecipeListModel>? AllLists = lists.Where(list => list.User == id);
            return AllLists;
        }

        //public async Task<
    }
}
