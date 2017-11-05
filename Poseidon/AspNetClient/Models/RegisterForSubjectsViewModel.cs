using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;

namespace AspNetClient.Models
{
    public class RegisterForSubjectsViewModel
    {

        public IList<Interfaces.Subject> Subjects { get; private set; }
        public IList<Interfaces.SubjectWithGrade> SubjectsWithGrades { get; private set; }  


        public RegisterForSubjectsViewModel(List<Subject> subjects, List<SubjectWithGrade> subjectWithGrades)
        {
            if (subjects != null)
                Subjects = subjects;
            else
                Subjects = new List<Subject>();
            if (subjectWithGrades != null)
                SubjectsWithGrades = subjectWithGrades;
            else
                SubjectsWithGrades = new List<SubjectWithGrade>();

        }

        public bool alreadyRegistered(int subjectId)
        {
            foreach(SubjectWithGrade i in SubjectsWithGrades)
            {
                if (i.Subject.Id == subjectId)
                    return true;
            }
            return false;
        }


    }
}
