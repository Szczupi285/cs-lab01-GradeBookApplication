using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using GradeBook.GradeBooks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook 
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }


        public override char GetLetterGrade(double averageGrade)
        {
            
            if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
                List<double> Grades = new List<double>();
                foreach (var student in Students)
                {
                    
                    Grades.Add(student.AverageGrade);
                }
                
                double twentyPercent = Students.Count / 5.0;
                int higherGradesThanInput = 0;
                foreach(var grade in Grades)
                {
                    if (grade > averageGrade)
                    {
                        higherGradesThanInput++;
                    }

                }
                int posOfInput = Students.Count - higherGradesThanInput;
                if(posOfInput > Students.Count - twentyPercent)
                {
                    return 'A';
                }
                else if(posOfInput > Students.Count - twentyPercent * 2.0)
                {
                    return 'B';
                }
                else if (posOfInput > Students.Count - twentyPercent * 3.0)
                {
                    return 'C';
                }
                else if (posOfInput > Students.Count - twentyPercent * 4.0)
                {
                    return 'D';
                }
                else
                {
                    return 'F';
                }

            
            
            
        }



        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
            
        }



        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }




    }
}
