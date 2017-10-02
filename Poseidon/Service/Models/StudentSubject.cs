using System.ComponentModel.DataAnnotations;

namespace Service.Models
{ 

    public class StudentSubject
    {
        [Required]
        public int StudentID { get; set; }
        [Required]
        public int SubjectID { get; set; }
        [Required]
        [Range(1, 18)]
        [Display(Name = "Enrollment Semester")]
        public int EnrollmentSemenster { get; set; }
        [Required]
        [Display(Name = "Signature")]
        public bool Signature { get; set; }
        [Required]
        [Display(Name = "Passed")]
        public bool Passed { get; set; }
        [Required]
        [Range(1, 5)]
        [Display(Name = "Grade")]
        public int Grade { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
