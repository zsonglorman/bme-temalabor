using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Subject")]
    public class SubjectController : Controller
    {
        // GET: api/Subject
        [HttpGet]
        public IEnumerable<Interfaces.Subject> Get()
        {
            // TODO select from DB
            return new List<Interfaces.Subject>()
            {
                new Interfaces.Subject(1, "A programoz�s alapjai 1", "BMEVIEEAA00", 7, 1, "Dr. Czirkos Zolt�n"),
                new Interfaces.Subject(2, "Bevezet�s a sz�m�t�selm�letbe 1", "BMEVISZAA00", 4, 1, "Dr. Szeszl�r D�vid")
            };
        }
    }
}
