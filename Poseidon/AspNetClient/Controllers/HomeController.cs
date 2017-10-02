using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetClient.Models;
using Interfaces;

namespace AspNetClient.Controllers
{
    public class HomeController : Controller
    {
        private ISubjectManager subjectManager;

        public HomeController(ISubjectManager subjectManager)
        {
            this.subjectManager = subjectManager;
        }

        public IActionResult Index()
        {
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
