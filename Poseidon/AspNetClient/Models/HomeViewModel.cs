using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetClient.Models
{
    public class HomeViewModel
    {
            public IList<Interfaces.SubjectWithGrade> SubjectWithGrade { get; private set; }


            public HomeViewModel(List<SubjectWithGrade> subjectWithGrade)
            {
                SubjectWithGrade = subjectWithGrade;
            }
        }
}
