using FoodPlannerAPI.DTOs;
using FoodPlannerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
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
        
        public async Task<RecipeListModel> GetLatestListByUserIdAsync(string id)
        {
            var list = await _appDbContext.RecipeList
                .Where(list => list.User == id)
                .OrderByDescending(list => list.CreationDate)
                .FirstOrDefaultAsync();               
                        
            if (list is not null)
            {
                var listDetails = await _appDbContext.ListDetails.Where(details => details.RecipeList == list.RecipeListModelId).ToListAsync();
                if (listDetails is not null)
                {
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
            var lists = await _appDbContext.RecipeList
                .Where(list => list.User == id)
                .ToListAsync();

            if (lists is not null)
            {
                foreach (var list in lists)
                {
                    list.ListDetails = await _appDbContext.ListDetails.Where(details => details.RecipeList == list.RecipeListModelId).ToListAsync();
                }

                var listsSerialize = JsonConvert.SerializeObject(lists,
                            Formatting.Indented,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            }
                        );
                IEnumerable<RecipeListModel> listsDeserialize = JsonConvert.DeserializeObject<IEnumerable<RecipeListModel>>(listsSerialize)!;

                return listsDeserialize!;
            }
            return null!;
        }

        public async Task<int> CreateNewListAsync(RecipeListModel newList)
        {
            _appDbContext.RecipeList.Add(newList);

            await _appDbContext.SaveChangesAsync();

            return newList.RecipeListModelId; 
        }

    }
}
