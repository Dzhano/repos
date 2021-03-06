using MilitaryElite.RanksInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.RankClasses
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string id, string firstName, string lastName)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string ID { get;}
        public string FirstName { get;}
        public string LastName { get;}

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {ID}";
        }
    }
}
