using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interfaces;
using AspNetClient.Models;
using System.Diagnostics;

namespace AspNetClient.Controllers
{
    public class SubjectsController : Controller
    {
        const int MIN_SEARCH_LENGTH = 3;
        private ISubjectManager subjectManager;

        public SubjectsController(ISubjectManager subjectManager)
        {
            this.subjectManager = subjectManager;
        }
        public IActionResult Index(string search)
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}