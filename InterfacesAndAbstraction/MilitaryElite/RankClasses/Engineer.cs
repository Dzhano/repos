using MilitaryElite.Enums;
using MilitaryElite.RanksInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.RankClasses
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<IRepair> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => repairs.AsReadOnly();

        public void AddRepair(IRepair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.ID} Salary: {base.Salary:F2}");
            builder.AppendLine($"Corps: {base.Corps}");
            builder.AppendLine("Repairs:");
            foreach (IRepair repair in repairs)
                builder.AppendLine($"  {repair.ToString()}");
            return builder.ToString().TrimEnd();
        }
    }
}
