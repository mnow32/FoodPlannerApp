

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodPlannerAPI.Models
{

    
    public class RecipeListModel
    {
        public List<ListDetailsModel> ?ListDetails { get; set; }

        [Key]
        public int RecipeListModelId { get; set; }

        [ForeignKey("UserModel")]
        [MaxLength(450)]
        public string ?User { get; set; }

        public UserModel ?UserModel {get; set; }

        public DateTime CreationDate { get; set; }
    }
}