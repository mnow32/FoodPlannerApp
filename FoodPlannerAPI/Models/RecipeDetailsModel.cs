namespace FoodPlannerAPI.Models
{
    public partial class RecipeDetailsModel
    {        
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? ImageType { get; set; }
        public int Servings { get; set; }            
        public float HealthScore { get; set; }              
        public bool DairyFree { get; set; }
        public bool GlutenFree { get; set; }
        public bool Ketogenic { get; set; }           
        public bool Sustainable { get; set; }
        public bool Vegan { get; set; }
        public bool Vegetarian { get; set; }           
        public IEnumerable<string>? DishTypes { get; set; }
        public IEnumerable<ExtendedIngredient>? ExtendedIngredients { get; set; }
        public string? Summary { get; set; }        

    }
}
