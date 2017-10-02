using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string NeptuneCode { get; set; }
    }
}
