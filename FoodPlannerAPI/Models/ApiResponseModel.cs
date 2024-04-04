namespace FoodPlannerAPI.Models
{
    public class ApiResponseModel
    {
        public IEnumerable<RecipeModel>? Results { get; set; }
        public int Offset { get; set; }
        public int Number { get; set; }
        public int TotalResults { get; set; }

    }
}
