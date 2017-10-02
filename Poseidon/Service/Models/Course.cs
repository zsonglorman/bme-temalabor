using System.ComponentModel.DataAnnotations;

namespace Service.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        [Required]
        public int SubjectID { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Required]
        [RegularExpression(
            @"([Hh]étfő)|([Kk]edd)|([Ss]zerda)|([Cc]sütörtök)|([Pp]éntek)|
            ([Mm]onday)|([Tt]uesday)|([Ww]ednesday)|([Tt]hursday)|([Ff]riday), 
            [0-9][0-9]:[0-9][0-9]", 
            ErrorMessage = "Schedule must be the format of: \"day, HH:mm\"")]
        public string Schedule { get; set; }
        [Required]
        public int LengthInMinutes { get; set; }
        [Required]
        [Range(15, 480)]
        [RegularExpression("([Gg]yakorlat)|([Ee]lőadás)|([Llabor])|([Pp]ractice)|([Ll]ecture)|([Ll]aboratory])")]
        public string CourseType { get; set; }
        
        public Subject Subject { get; set; }
    }
}
