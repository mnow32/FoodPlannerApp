namespace FoodPlannerAPI.Models
{
    public class ListDetailsModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string? Ingredient { get; set; }

        public float Quantity { get; set; }
    }
}