using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class Course
    {
        public int CourseID { get; set; }

        public int SubjectID { get; set; }

        public string Location { get; set; }

        public string Schedule { get; set; }

        public int LengthInMinutes { get; set; }

        public string CourseType { get; set; }

        public Course(int courseID, int subjectID, string location, string schedule, int lengthInMinutes, string courseType)
        {
            CourseID = courseID;
            SubjectID = subjectID;
            Location = location;
            Schedule = schedule;
            LengthInMinutes = lengthInMinutes;
            CourseType = courseType;
        }
    }
}
