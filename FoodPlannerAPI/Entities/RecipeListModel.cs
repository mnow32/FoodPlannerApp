

using FoodPlannerAPI.DTOs;
using FoodPlannerAPI.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodPlannerAPI.Models
{

    
    public class RecipeListModel
    {
        public string? Name { get; set; }
        public  string? URLs { get; set; }
        public string? RecipesNames {  get; set; }
        public List<ListDetailsModel>? ListDetails { get; set; } = new();

        [Key]
        public int RecipeListModelId { get; set; }

        [ForeignKey("UserModel")]
        [MaxLength(450)]
        public string? User { get; set; }
        public UserModel? UserModel {get; set; }
        public DateTime CreationDate { get; set; }
        public static RecipeListModel FromEntity(RecipeListDTO dto)
        {
            return new RecipeListModel()
            {
                ListDetails = dto.ListDetails!.Select(detailsDto => ListDetailsModel.FromEntity(detailsDto)).ToList(),
                CreationDate = dto.CreationDate
            };
        }
    }
}