using GradeBook.Enums;
using System.Linq;
using System;

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
            {
                throw new Exception("Ranked-grading requires a minimum of 5 students to work)");
            }

            var twentyPercentCount = Math.Abs(Students.Count * .20);
            var higherStudentCount = Students.Count(s => s.AverageGrade > averageGrade);

            if(higherStudentCount == 0) { return 'A'; }

            var result = higherStudentCount / twentyPercentCount;

            if(result < 1)
            {
                return 'A';
            }
            if(result < 2)
            {
                return 'B';
            }
            if(result < 3)
            {
                return 'C';
            }
            if(result < 4)
            {
                return 'D';
            }
            return 'F';
        }
    }
}
