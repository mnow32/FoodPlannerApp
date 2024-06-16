using Microsoft.AspNetCore.Identity;

namespace FoodPlannerAPI.Models
{
    public class UserModel : IdentityUser
    {
        public List<RecipeListModel>? Recipes { get; set; } = new();
    }
    
}