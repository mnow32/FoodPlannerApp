namespace FoodPlannerAPI.DTOs;

public class RecipeListDTO
{        
    public List<ListDetailsDTO>? ListDetails { get; set; } = new();
    public DateTime CreationDate { get; set; } = DateTime.Now;
}
