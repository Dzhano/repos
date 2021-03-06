using MilitaryElite.RanksInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.RankClasses
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates => this.privates.AsReadOnly();

        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.ID} Salary: {base.Salary:F2}");
            text.AppendLine("Privates:");
            foreach (IPrivate @private in privates) 
                text.AppendLine($"  {@private.ToString()}");
            return text.ToString().TrimEnd();
        }
    }
}
