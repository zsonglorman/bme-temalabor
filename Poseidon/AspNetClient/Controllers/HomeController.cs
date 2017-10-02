using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interfaces;

namespace AspNetClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // create mocking data access 
            var subjectManager = Mocks.Factory.DataAccessFactory.GetDataAccess();

            // get subjects with data access
            List<Subject> subjects = subjectManager.GetSubjects();

            return Content(string.Join("\r\n", subjects));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
