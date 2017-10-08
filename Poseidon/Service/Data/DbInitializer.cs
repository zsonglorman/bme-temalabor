using Service.Models;
using System.Linq;

namespace Service.Data
{
    public class DbInitializer
    {
        public static void Initialize(PoseidonContext context)
        {
            context.Database.EnsureCreated();

            // Checks if there are any data in the context
            if (context.Subjects.Any())
            {
                return;     // DB has been seeded
            }

            // SEED DATABASE

            var subjects = new Subject[]
            {
                new Subject{ SubjectID=1, Name="A programozás alapjai 1", Code="BMEVIEEAA00", Credit=7, RecomendedSemester=1, ResponsibleProfessor="Dr. Czirkos Zoltán"},
                new Subject{ SubjectID=2, Name="Bevezetés a számításelméletbe 1", Code="BMEVISZAA00", Credit=4, RecomendedSemester=1, ResponsibleProfessor="Dr. Szeszlér Dávid"}
            };

            foreach (Subject s in subjects)
            {
                context.Subjects.Add(s);
            }
            context.SaveChanges();


            var students = new Student[]
            {
                new Student{ StudentId=1, Name="Gipsz Jakab", NeptuneCode="A17MZX"},
                new Student{ StudentId=2, Name="Citrom Csilla", NeptuneCode="BE1ASD"},
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();


            var courses = new Course[]
            {
                new Course{ SubjectID=1, Location="Q-I", Schedule="kedd, 08:15", LengthInMinutes=90, CourseType="Előadás" },
                new Course{ SubjectID=1, Location="R4L", Schedule="szerda, 10:15", LengthInMinutes=90, CourseType="Labor" },
                new Course{ SubjectID=2, Location="IB028", Schedule="kedd, 10:15", LengthInMinutes=90, CourseType="Előadás" },
                new Course{ SubjectID=2, Location="E404", Schedule="szerda, 12:15", LengthInMinutes=90, CourseType="Gyakorlat" }
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();


            var studentSubjects = new StudentSubject[]
            {
                new StudentSubject{ StudentID=1, SubjectID=1, EnrollmentSemenster=1, Signature=true, Passed=true, Grade=4},
                new StudentSubject{ StudentID=1, SubjectID=2, EnrollmentSemenster=1, Signature=true, Passed=false, Grade=1},
                new StudentSubject{ StudentID=1, SubjectID=2, EnrollmentSemenster=2, Signature=true, Passed=true, Grade=3},
                new StudentSubject{ StudentID=2, SubjectID=1, EnrollmentSemenster=1, Signature=true, Passed=true, Grade=5},
                new StudentSubject{ StudentID=2, SubjectID=2, EnrollmentSemenster=1, Signature=true, Passed=true, Grade=2},
            };

            foreach (StudentSubject s in studentSubjects)
            {
                context.StudentSubjects.Add(s);
            }
            context.SaveChanges();
        }
    }
}
