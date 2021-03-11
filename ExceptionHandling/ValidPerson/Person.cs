using System;
using System.Collections.Generic;
using System.Text;

namespace ValidPerson
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new InvalidPersonNameException(value, "First name cannot be null or empty.");
                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new InvalidPersonNameException(value, "Last name cannot be null or empty.");
                lastName = value;
            }
        }
        public int Age
        {
            get => age;
            set
            {
                if (value < 0 || value > 120)
                    throw new ArgumentOutOfRangeException(value.ToString(), "Age should be in range [0 ... 120].");
                age = value;
            }
        }
    }
}
