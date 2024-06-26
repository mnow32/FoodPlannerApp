using FoodPlannerAPI.Models;
using FoodPlannerAPI.Services;
using FoodPlannerAPI.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodPlannerAPI.DTOs;

namespace FoodPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;
        private readonly IUserContext _userContext;
        public ListController(IUserContext userContext, IListService listService)
        {
            _userContext = userContext;
            _listService = listService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetNewList()
        {
            CurrentUser? currentUser = _userContext.GetCurrentUser();
            var response = await _listService.GetLatestListByUserIdAsync(currentUser!.Id);            
            
            if (response is not null)
            {
                return Ok(response);
            }
            return NotFound();
        }


        [HttpGet("all")]
        [Authorize]
        public async Task<IActionResult> GetAllLists()
        {
            CurrentUser? currentUser = _userContext.GetCurrentUser();
            var response = await _listService.GetAllListsByUserIdAsync(currentUser!.Id);
            if(response is not null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateList([FromBody] RecipeListDTO newList)
        {
            CurrentUser? currentUser = _userContext.GetCurrentUser();
            RecipeListModel newListModel = RecipeListModel.FromEntity(newList);
            newListModel.User = currentUser!.Id;
            int id = await _listService.CreateNewListAsync(newListModel);
            return Ok(id);
        }

    }
}
