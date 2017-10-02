using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Models
{
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Credit { get; set; }
        public int RecomendedSemester { get; set; }
        public string ResponsibleProfessor { get; set; }
    }
}
