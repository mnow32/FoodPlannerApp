namespace FoodPlannerAPI.DTOs;

public class RecipeListDTO
{
    public string? Name { get; set; }
    public List<string>? URLs { get; set; } = new();
    public List<string>? RecipesNames { get; set; } = new();
    public List<ListDetailsDTO>? ListDetails { get; set; } = new();
    public DateTime CreationDate { get; set; } = DateTime.Now;
}
