using MilitaryElite.RanksInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.RankClasses
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"Name: {base.FirstName} {base.LastName} Id: {base.ID} Salary: {this.Salary:F2}";
        }
    }
}
