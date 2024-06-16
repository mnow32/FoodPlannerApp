using FoodPlannerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using System.Collections;
using System.Net;

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
        
        public async Task<RecipeListModel> GetLatestListIdByUserIdAsync(string id)
        {
            var lists = await _appDbContext.RecipeList.ToListAsync();            
            RecipeListModel? list = lists
            .Where(list => list.User == id)
            .OrderByDescending(list => list.CreationDate)
            .FirstOrDefault();            
            if (list is not null)
            {
                var listDetails = await _appDbContext.ListDetails.Where(details => details.RecipeList == list.RecipeListModelId).ToListAsync();
                if (listDetails is not null)
                {
                    //foreach (var detail in listDetails)
                    //{
                    //    list.ListDetails!.Add(detail);
                    //}

                    var listSerialize = JsonConvert.SerializeObject(list,
                        Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }
                    );

                    RecipeListModel listDeserialize = JsonConvert.DeserializeObject<RecipeListModel>( listSerialize )!;

                    return listDeserialize!;
                }
                
            }
            return null!;
            
        }

        public async Task<IEnumerable<RecipeListModel>> GetAllListsByUserIdAsync(string id)
        {
            var lists = await _appDbContext.RecipeList.ToListAsync();
            IEnumerable<RecipeListModel>? AllLists = lists.Where(list => list.User == id);
            return AllLists;
        }

        

    }
}
