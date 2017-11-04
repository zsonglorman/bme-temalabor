using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Grade")]
    public class GradeController : Controller
    {
        private readonly PoseidonContext context;

        public GradeController(PoseidonContext context)
        {
            this.context = context;
        }

        // Get subject with grades of a semester
        // GET: api/Grade/1
        [HttpGet("{semester}")]
        public IActionResult Get(int semester)
        {
            if (semester == 0)
            {
                return BadRequest();
            }
            else
            {
                var entityGrades = from b in context.StudentSubjects
                                   .Include(nameof(Models.Student))
                                   .Include(nameof(Models.Subject))
                                   where b.EnrollmentSemenster == semester
                                   select b;

                if (entityGrades.ToList().Count == 0)
                {
                    return NotFound();
                }

                var subjectWithGrades = new List<Interfaces.SubjectWithGrade>();

                foreach (Models.StudentSubject s in entityGrades)
                {
                    var subject = new Interfaces.Subject(s.SubjectID, s.Subject.Name, s.Subject.Code, s.Subject.Credit, s.Subject.RecomendedSemester, s.Subject.ResponsibleProfessor);
                    var grade = new Interfaces.Grade(s.StudentID, s.SubjectID, s.EnrollmentSemenster, s.Signature, s.Passed, s.Grade);

                    subjectWithGrades.Add(new Interfaces.SubjectWithGrade(subject, grade));
                }

                return new ObjectResult(subjectWithGrades);
            }
        }

        // Insert a grade for a subject
        // POST: api/Grade/
        [HttpPost]
        public IActionResult Insert([FromBody] Interfaces.Grade grade)
        {
            if (grade == null)
            {
                return BadRequest();
            }

            var student = (from s in context.Students
                            where s.StudentId == grade.StudentID
                            select s).FirstOrDefault();

            var subject = (from s in context.Subjects
                            where s.SubjectID == grade.SubjectID
                            select s).FirstOrDefault();

            var studentSubject = new Models.StudentSubject()
            {
                StudentID = student.StudentId,
                SubjectID = subject.SubjectID,
                EnrollmentSemenster = grade.EnrollmentSemester,
                Signature = grade.Signature,
                Passed = grade.Passed,
                Grade = grade.ReceivedGrade,
                Student = student,
                Subject = subject
            };

            context.StudentSubjects.Add(studentSubject);
            context.SaveChanges();

            return Ok();
        }

        // Update a grade
        // PUT: api/Grade/
        [HttpPut]
        public IActionResult Update([FromBody] Interfaces.Grade grade)
        {
            if (grade == null)
            {
                return BadRequest();
            }

            var grades = from s in context.StudentSubjects
                         where s.StudentID == grade.StudentID
                         && s.SubjectID == grade.SubjectID
                         && s.EnrollmentSemenster == grade.EnrollmentSemester
                         select s;

            if (grades.ToList().Count != 1)
            {
                return NotFound();
            }

            var gradeToUpdate = grades.ToList()[0];

            gradeToUpdate.Signature = grade.Signature;
            gradeToUpdate.Passed = grade.Passed;
            gradeToUpdate.Grade = grade.ReceivedGrade;

            context.SaveChanges();

            return Ok();
        }

        // Delete a grade
        // DELETE: api/Grade/1/1/3
        [HttpDelete("{studentId}/{subjectId}/{enrollmentSemester}")]
        public IActionResult Delete(int studentId, int subjectId, int enrollmentSemester)
        {
            if (studentId == 0 || subjectId == 0 || enrollmentSemester == 0)
            {
                return BadRequest();
            }

            var grades = from s in context.StudentSubjects
                         where s.StudentID == studentId
                         && s.SubjectID == subjectId
                         && s.EnrollmentSemenster == enrollmentSemester
                         select s;

            if (grades.ToList().Count != 1)
            {
                return NotFound();
            }

            var gradeToDelete = grades.ToList()[0];

            context.StudentSubjects.Remove(gradeToDelete);

            context.SaveChanges();

            return Ok();
        }

        // Get subject with grades of a semester
        // GET: api/Grade/?subjectId=1
        [HttpGet]
        public IActionResult GetGradesOfSubject([FromQuery] int subjectId)
        {
            if (subjectId == 0)
            {
                return BadRequest();
            }
            else
            {
                var entityGrades = from b in context.StudentSubjects
                                   .Include(nameof(Models.Student))
                                   .Include(nameof(Models.Subject))
                                   where b.SubjectID == subjectId
                                   select b;

                if (entityGrades.ToList().Count == 0)
                {
                    return NotFound();
                }

                var grades = new List<Interfaces.Grade>();

                foreach (Models.StudentSubject s in entityGrades)
                {
                    var grade = new Interfaces.Grade(s.StudentID, s.SubjectID, s.EnrollmentSemenster, s.Signature, s.Passed, s.Grade);

                    grades.Add(grade);
                }

                return new ObjectResult(grades);
            }
        }
    }
}