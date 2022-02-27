using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Verification_System
{
    class Student
    {
        public Student(string name, string lastName, int grade, char type)
        {
            Name = name;
            LastName = lastName;
            Grade = grade;
            Type = type;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int Grade { get; private set; }
        public char Type { get; private set; }

        public override string ToString()
        {
            return $"{Name} {LastName} - Grade: {Grade}{Type}";
        }
    }
}
