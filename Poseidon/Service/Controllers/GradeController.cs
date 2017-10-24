using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Data;

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
                                    where b.EnrollmentSemenster == semester
                                   select b;

                if (entityGrades.ToList().Count == 0)
                {
                    return NotFound();
                }

                var subjectWithGrades = new List<Interfaces.SubjectWithGrades>();

                int currentSubjectId = -1;
                Interfaces.Subject currentSubject = null;
                List<Interfaces.Grade> currentGrades = new List<Interfaces.Grade>();

                foreach (Models.StudentSubject s in entityGrades)
                {
                    if (s.Subject.SubjectID != currentSubjectId)
                    {
                        if (currentSubject != null)
                        {
                            subjectWithGrades.Add(new Interfaces.SubjectWithGrades(currentSubject, currentGrades));
                        }

                        currentSubjectId = s.Subject.SubjectID;
                        currentSubject = new Interfaces.Subject(s.SubjectID, s.Subject.Name, s.Subject.Code, s.Subject.Credit, s.Subject.RecomendedSemester, s.Subject.ResponsibleProfessor);
                        currentGrades.Clear();
                        currentGrades.Add(new Interfaces.Grade(s.StudentID, s.SubjectID, s.EnrollmentSemenster, s.Signature, s.Passed, s.Grade));
                    }
                    else
                    {
                        currentGrades.Add(new Interfaces.Grade(s.StudentID, s.SubjectID, s.EnrollmentSemenster, s.Signature, s.Passed, s.Grade));
                    }
                }

                return new ObjectResult(subjectWithGrades);
            }
        }
    }
}