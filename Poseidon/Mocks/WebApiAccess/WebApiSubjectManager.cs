using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Mocks.Factory
{
    class WebApiSubjectManager : ISubjectManager
    {
        public List<Subject> GetSubjects()
        {
            // TODO call web API and return results of the call
            return new List<Subject>()
            {
                new Subject(1, "A programozás alapjai 1", "BMEVIEEAA00", 7, 1, "Dr. Czirkos Zoltán"),
                new Subject(2, "Bevezetés a számításelméletbe 1", "BMEVISZAA00", 4, 1, "Dr. Szeszlér Dávid")
            };
        }
    }
}