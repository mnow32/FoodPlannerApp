using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodPlannerAPI.Models
{
    public class ListDetailsModel
    {
        [Key]
        public int ListDetailsModelId { get; set; }

        [ForeignKey("RecipeListModel")]
        [MaxLength(450)]
        public int RecipeList { get; set; }

        public string? Ingredient { get; set; }

        public float Quantity { get; set; }

        public RecipeListModel? RecipeListModel { get; set; }
    }
}