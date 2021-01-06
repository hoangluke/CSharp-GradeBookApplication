using System;
using System.Linq;
using GradeBook.Enums;

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
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var orderedStudents = Students.OrderByDescending(student => student.AverageGrade);

            int rank = 1;
            foreach (var student in orderedStudents)
            {
                if (averageGrade >= student.AverageGrade)
                {
                    break;
                }
                rank += 1;
            }

            double percentage = ((double)rank / Students.Count) * 100;

            if (percentage <= 20)
            {
                return 'A';
            }
            else if (percentage <= 40)
            {
                return 'B';
            }
            else if (percentage <= 60)
            {
                return 'C';
            }
            else if (percentage <= 80)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
