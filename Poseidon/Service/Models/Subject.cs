using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Models
{
    public class Subject
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 100 characters long.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The subject code must be between 5 and 20 characters long.")]
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Credit")]
        public int Credit { get; set; }
        [Required]
        [Display(Name = "Recommended Semester")]
        public int RecomendedSemester { get; set; }
        [Display(Name = "Responsible Professor")]
        public string ResponsibleProfessor { get; set; }
    }
}
