using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NutriInfo.Models
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }         //auto generated primary key - foodid

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }       //name of the food

        [Required]
        public string? RichIn { get; set; }     //prominently rich in which nutrient

        [Required]
        public int DietId { get; set; }         //foreign key - the diet for which the food is good
        public virtual Diet Diet { get; set; }  //navigation property for the Diet(parent) table
    }
}
