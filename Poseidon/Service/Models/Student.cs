using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Models
{
    public class Student
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 100 characters long.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Neptun code must be 6 characters long.")]
        [Display(Name = "Neptune Code")]
        public string NeptuneCode { get; set; }
    }
}
