﻿using System;
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

        public HomeController( ISubjectManager subjectManager)
        {
            this.subjectManager = subjectManager; 
        }

        [HttpGet]
        public IActionResult Modify(int? id)
        {
            foreach (SubjectWithGrade i in subjectManager.GetSubjectsWithGradesOfSemester(HomeViewModel.Semester))
                if (i.Subject.Id == id)
                    return PartialView(new ModifySubjectViewModel(i));
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index(int? id)
        {
            if(id.HasValue) return View(new HomeViewModel(subjectManager.GetSubjectsWithGradesOfSemester(id.Value), id.Value));
            else return View(new HomeViewModel(subjectManager.GetSubjectsWithGradesOfSemester(1), 1));
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

        [HttpPost]
        public IActionResult Delete()
        {
            int id = int.Parse(Request.Form["id"]);
            int studentId = int.Parse(Request.Form["studentId"]);
            bool sign = bool.Parse(Request.Form["sign"]);
            int mark = int.Parse(Request.Form["mark"]);
            int semester = int.Parse(Request.Form["semester"]);

            bool passed = false;
            if ((int)mark > 1 && sign == true)
                passed = true;
            Grade grade = new Grade(studentId, id, semester, sign, passed, mark);
            subjectManager.DeleteGradeOfSubject(grade);
            return Content("Success");
        }
        [HttpPost]
        public IActionResult Modify()
        {
            int id = int.Parse(Request.Form["id"]);
            int studentId = int.Parse(Request.Form["studentId"]);
            bool sign = bool.Parse(Request.Form["sign"]);
            int mark = int.Parse(Request.Form["mark"]);
            int semester = int.Parse(Request.Form["semester"]);

            bool passed = false;
            if ((int)mark > 1 && sign == true)
                passed = true;
            Grade grade = new Grade(studentId, id, semester, sign, passed, mark);
         
            subjectManager.UpdateGradeOfSubject(grade);
            return Content("Success");
        }
    }
}
