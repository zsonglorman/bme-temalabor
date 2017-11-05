using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetClient.Models
{
    public class ModifySubjectViewModel
    {
        public SubjectWithGrade SubjectWithGrade { get; private set; }
        public ModifySubjectViewModel(SubjectWithGrade subjectWithGrade)
        {
            SubjectWithGrade = subjectWithGrade;
        }
    }
}
