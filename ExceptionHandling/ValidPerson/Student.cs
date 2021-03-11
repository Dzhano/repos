using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidPerson
{
    public class Student
    {
        private string name;

        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Any(ch => !char.IsLetter(ch)))
                    throw new InvalidPersonNameException(value, "Name cannot contain special characters or numeric values.");
                name = value;
            }
        }
        public string Email { get; set; }
    }
}
