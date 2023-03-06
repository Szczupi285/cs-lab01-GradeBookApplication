using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;

namespace GradeBook.GradeBooks 
{
    public class StandardGradeBook : BaseGradeBook
    {
        string name { get; set; }
        public StandardGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Standard;
        }
       
    }
}
