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

        public HomeController()
        {
            this.subjectManager = Mocks.Factory.DataAccessFactory.GetDataAccess(); 
        }

        public IActionResult Index()
        {
            // get subjects with data access

            return View();
            //return Content(string.Join("\r\n", subjects));
        }

        public IActionResult RegisterForSubjects()
        {
            ViewBag.Subjects = subjectManager.GetSubjects();

            return View();
        }

        public IActionResult RegisteredSubjects()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Settings()
        {

            return View();
        }

        public IActionResult SignOut()
        {
            return Content("NotImplemented");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
