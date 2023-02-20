using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriInfo.Models
{
    public class Diet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DietId { get; set; }                 //self generated diet id - primary key

        [Required]
        [MinLength(5)]
        public string? Name { get; set; }
        [Required]
        public string? Benefit { get; set; }           // gain/loss benefit for the diet

        [Range(1,10, ErrorMessage = "Difficulty level should be between 1 and 10.")]
        public int? DifficultLevel { get; set; }        // difficulty level to follow the diet in the range of 1-10

        public virtual ICollection<Food> Foods { get; set; }    //Navigation for the foreign key
    }
}
