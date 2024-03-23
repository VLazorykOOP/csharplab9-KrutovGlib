using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT
{
    class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Group { get; set; }
        public int[] Grades { get; set; }

        public Student(string lastName, string firstName, string middleName, string group, int[] grades)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Group = group;
            Grades = grades;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}, Group: {Group}, Grades: {string.Join(", ", Grades)}";
        }
    }
}
