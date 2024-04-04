namespace FoodPlannerAPI.Models
{
    public partial class RecipeDetailsModel
    {
        public class Metric
        {
            public float Amount { get; set; }
            public string? UnitLong { get; set; }
        }
    }
}
