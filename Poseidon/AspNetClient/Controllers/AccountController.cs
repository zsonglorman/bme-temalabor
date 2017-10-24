using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interfaces;

namespace AspNetClient.Controllers
{
    public class AccountController : Controller
    {

        private ISubjectManager subjectManager;

        public AccountController(ISubjectManager subjectManager)
        {
            this.subjectManager = subjectManager;
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            return View();
        }
    }
}