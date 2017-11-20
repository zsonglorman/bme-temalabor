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
        public int AllCredits
        {
            get
            {
                int sum = 0;
                foreach (var item in SubjectWithGrade)
                    sum += item.Subject.Credit;
                return sum;
            }
        }
        public int EarnedCredits
        {
            get
            {
                int sum = 0;
                foreach (var item in SubjectWithGrade)
                    if (item.Grade.Passed)
                        sum += item.Subject.Credit;
                return sum;
            }
        }
        public double WeightedAverage
        {
            get
            {
                double average = 0;
                foreach (var item in SubjectWithGrade)
                    average += item.Grade.ReceivedGrade * item.Subject.Credit;
                if (average == 0) return 0;
                if (EarnedCredits == 0) return 1;
                return Math.Round(average / EarnedCredits, 2);
            }
        }
        public double ScholarshipAverage
        {
            get
            {
                double average = 0;
                foreach (var item in SubjectWithGrade)
                    average += item.Grade.ReceivedGrade * item.Subject.Credit;
                if (average == 0) return 0;
                return Math.Round(average / 30, 2);
            }
        }

        public static int Semester { get; set; }
        public int actualSemester { get; set; }
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
            actualSemester = Semester;
        }
    }
}
