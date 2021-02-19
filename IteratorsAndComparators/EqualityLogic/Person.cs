using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityLogic
{
    class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
                return this.Name.CompareTo(other.Name);
            if (this.Age.CompareTo(other.Age) != 0)
                return this.Age.CompareTo(other.Age);
            return 0;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }
        public override bool Equals(object other)
        {
            return this.GetHashCode() == other.GetHashCode();
        }
    }
}
