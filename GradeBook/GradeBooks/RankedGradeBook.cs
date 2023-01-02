using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Security;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
                throw new InvalidOperationException("Ranked Grading required 5 or more students");

            var threshould = (int)Math.Ceiling(Student.Count * .2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if(grades[threshould - 1] <= averageGrade)
                return 'A';
            else if (grades[(threshould*2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(threshould*3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(threshould*4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';


        }
    }
}
