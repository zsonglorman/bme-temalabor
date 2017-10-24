using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetClient.Models
{
    public class HomeViewModel
    {
            public IList<Interfaces.SubjectWithGrades> SubjectWithGrades { get; private set; }


            public HomeViewModel(List<SubjectWithGrades> subjectWithGrades)
            {
                SubjectWithGrades = subjectWithGrades;
            }
        }
}
