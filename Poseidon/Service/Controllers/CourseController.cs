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
    [Route("api/Course")]
    public class CourseController : Controller
    {
        private readonly PoseidonContext context;

        public CourseController(PoseidonContext context)
        {
            this.context = context;
        }

        // Get courses of a subject
        // GET: api/Course/1
        [HttpGet("{subjectId}")]
        public IActionResult Get(int subjectId)
        {
            if (subjectId == 0)
            {
                return BadRequest();
            }
            else
            {
                var entityCourses = from b in context.Courses
                                     where b.SubjectID == subjectId
                                     select b;

                if (entityCourses.ToList().Count == 0)
                {
                    return NotFound();
                }

                List<Interfaces.Course> courses = new List<Interfaces.Course>();

                foreach (Models.Course s in entityCourses)
                {
                    courses.Add(new Interfaces.Course(s.CourseID, s.SubjectID, s.Location, s.Schedule, s.LengthInMinutes, s.CourseType));
                }

                return new ObjectResult(courses);
            }
        }
    }
}