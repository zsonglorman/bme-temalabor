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
        public static int Semester { get; set; }

        public int numOfGrade(int grade)
        {
            int sum = 0;
            foreach (SubjectWithGrade i in SubjectWithGrade)
            {
                if (i.Grade.ReceivedGrade == grade)
                {
                    sum++;
                }

            }
            return sum;
        }
        public HomeViewModel(List<SubjectWithGrade> subjectWithGrade, int semester)
        {
            if (subjectWithGrade != null)
                SubjectWithGrade = subjectWithGrade;
            else
                SubjectWithGrade = new List<SubjectWithGrade>();
            Semester = semester;
        }
    }
}
