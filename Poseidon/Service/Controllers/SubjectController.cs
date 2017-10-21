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
        public IEnumerable<Interfaces.Subject> Get()
        {

            Models.Subject[] entitySubjects = context.Subjects.ToArray<Models.Subject>();

            List<Interfaces.Subject> subjects = new List<Interfaces.Subject>();

            foreach (Models.Subject s in entitySubjects)
            {
                subjects.Add(new Interfaces.Subject(s.SubjectID, s.Name, s.Code, s.Credit, s.RecomendedSemester, s.ResponsibleProfessor));
            }

            return subjects;
        }
    }
}
