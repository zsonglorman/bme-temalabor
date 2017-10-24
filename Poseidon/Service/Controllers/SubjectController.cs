using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Service.Data;
using System.Linq;

namespace Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Subject")]
    public class SubjectController : Controller
    {

        private readonly PoseidonContext context;

        public SubjectController(PoseidonContext context)
        {
            this.context = context;
        }

        // GET: api/Subject
        [HttpGet]
        public IEnumerable<Interfaces.Subject> GetAll()
        {
            Models.Subject[] entitySubjects = context.Subjects.ToArray<Models.Subject>();

            List<Interfaces.Subject> subjects = new List<Interfaces.Subject>();

            foreach (Models.Subject s in entitySubjects)
            {
                subjects.Add(new Interfaces.Subject(s.SubjectID, s.Name, s.Code, s.Credit, s.RecomendedSemester, s.ResponsibleProfessor));
            }

            return subjects;
        }

        // GET: api/Subject/test
        [HttpGet("{keyword}")]        
        public IActionResult SearchByKeyword(string keyword)
        {
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 2)
            {
                return BadRequest();
            }
            else
            {
                var entitySubjects = from b in context.Subjects
                            where b.Name.ToUpper().Contains(keyword.ToUpper()) || b.Code.ToUpper().Contains(keyword.ToUpper())
                            select b;                

                List<Interfaces.Subject> subjects = new List<Interfaces.Subject>();

                foreach (Models.Subject s in entitySubjects)
                {
                    subjects.Add(new Interfaces.Subject(s.SubjectID, s.Name, s.Code, s.Credit, s.RecomendedSemester, s.ResponsibleProfessor));
                }

                return new ObjectResult(subjects);
            }
        }
    }
}
