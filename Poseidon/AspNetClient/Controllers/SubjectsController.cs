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
            ViewData.Add("Search", search);
            if (search != null && search.Length >= MIN_SEARCH_LENGTH)
            {
                return View(new RegisterForSubjectsViewModel(
                        subjectManager.SearchSubjects(search), subjectManager.GetSubjectsWithGrades()));
            }
            else
            {
                return View(new RegisterForSubjectsViewModel(subjectManager.GetSubjects(), subjectManager.GetSubjectsWithGrades()));
            }
        }

        // GET: Movies/Register/5
        public IActionResult Register(int? id)
        {
            foreach(Subject i in subjectManager.GetSubjects())
                if(i.Id == id)
                    return PartialView(new SubjectViewModel(i));
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Modify(int? id)
        {
            return PartialView(id);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpPost]
        public IActionResult Insert()
        {
            int id = int.Parse(Request.Form["id"]);
            bool sign = bool.Parse(Request.Form["sign"]);
            int mark = int.Parse(Request.Form["mark"]);
            int semester = int.Parse(Request.Form["semester"]);

            bool passed = false;
            if ((int)mark > 1 && sign == true)
                passed = true;
            Grade grade = new Grade(0, id, semester, sign, passed, mark);
            //subjectManager.InsertGradeOfSubject(grade);
            return Content("Success");

            //return null;
        }
        [HttpPost]
        public IActionResult Delete()
        {
            int id = int.Parse(Request.Form["id"]);
            bool sign = false;
            int mark = 1;
            int semester = int.Parse(Request.Form["semester"]);

            bool passed = false;
            if ((int)mark > 1 && sign == true)
                passed = true;
            Grade grade = new Grade(0, id, semester, sign, passed, mark);
            //subjectManager.DeleteGradeOfSubject(grade);
            return null;
        }
        [HttpPost]
        public IActionResult Update()
        {
            int id = int.Parse(Request.Form["id"]);
            bool sign = bool.Parse(Request.Form["sign"]);
            int mark = int.Parse(Request.Form["mark"]);
            int semester = int.Parse(Request.Form["semester"]);

            bool passed = false;
            if ((int)mark > 1 && sign == true)
                passed = true;
            Grade grade = new Grade(0, id, semester, sign, passed, mark);
            //subjectManager.UpdateGradeOfSubject(grade);
            return null;
        }
    }
}