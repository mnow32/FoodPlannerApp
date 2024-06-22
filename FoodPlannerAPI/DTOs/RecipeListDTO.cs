namespace FoodPlannerAPI.DTOs;

public class RecipeListDTO
{
    public string? Name { get; set; }
    public string? URLs { get; set; }
    public string? RecipesNames { get; set; }
    public List<ListDetailsDTO>? ListDetails { get; set; } = new();
    public DateTime CreationDate { get; set; } = DateTime.Now;
}
