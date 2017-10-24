using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetClient.Models
{
    public class HomeViewModel
    {
            public IList<Interfaces.Grade> Grades { get; private set; }


            public HomeViewModel(List<Grade> grades)
            {
                Grades = grades;
            }
        }
}
