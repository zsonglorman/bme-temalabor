using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpClient.Models
{
    public class SubjectAndGrade
    {

        //Subject
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Code { get; private set; }

        public int Credit { get; private set; }

        public int RecommendedSemester { get; private set; }

        public string ResponsibleProfessor { get; private set; }

        //Grade
        public int StudentID { get; set; }

        public int SubjectID { get; set; }

        public int EnrollmentSemester { get; set; }

        public bool Signature { get; set; }

        public bool Passed { get; set; }

        public int ReceivedGrade { get; set; }

        public SubjectAndGrade() { }

        public SubjectAndGrade(int id, string name, string code, int credit, int recommendedSemester, string responsibleProfessor, int studentID, int subjectID, int enrollmentSemester, bool signature, bool passed, int receivedGrade)
        {
            Id = id;
            Name = name;
            Code = code;
            Credit = credit;
            RecommendedSemester = recommendedSemester;
            ResponsibleProfessor = responsibleProfessor;

            StudentID = studentID;
            SubjectID = subjectID;
            EnrollmentSemester = enrollmentSemester;
            Signature = signature;
            Passed = passed;
            ReceivedGrade = receivedGrade;
        }

    }
}
