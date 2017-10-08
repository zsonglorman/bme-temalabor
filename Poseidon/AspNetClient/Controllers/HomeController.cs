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
        const int MIN_SEARCH_LENGTH = 3;
        private ISubjectManager subjectManager;

        public HomeController( ISubjectManager subjectManager)
        {
            this.subjectManager = subjectManager; 
        }

        public IActionResult Index()
        {
            return View();        
        }
        public IActionResult RegisterForSubjects(string search)
        {
            if (ModelState.IsValid)
            {
                if (search != null && search.Length >= MIN_SEARCH_LENGTH)
                {
                    return View(new RegisterForSubjectsViewModel(
                            subjectManager.GetSubjects().Where(
                            s => s.Name.ToUpper().Contains(search.ToUpper())
                            || s.Code.ToUpper().Contains(search.ToUpper()))
                            .ToList()));
                }
                else
                {
                    return View(new RegisterForSubjectsViewModel(subjectManager.GetSubjects()));
                }
            }
            else
            {
                return Error();
            }

        }
        
        public IActionResult RegisteredSubjects()
        {
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
