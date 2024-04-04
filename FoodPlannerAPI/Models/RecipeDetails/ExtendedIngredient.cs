namespace FoodPlannerAPI.Models
{
    public partial class RecipeDetailsModel
    {
        public class ExtendedIngredient
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Aisle { get; set; }
            public Measures? Measures { get; set; }
            public string? Original { get; set; }
            public string? OriginalName { get; set; }
        }
    }
}
