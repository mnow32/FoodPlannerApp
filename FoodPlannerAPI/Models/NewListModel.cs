namespace FoodPlannerAPI.Models
{
    public class NewListModel
    {
        public RecipeListModel RecipeList { get; set; } = new();
        public List<ListDetailsModel> ListDetails { get; set; } = new();
    }
}
