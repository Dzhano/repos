using MilitaryElite.Enums;
using MilitaryElite.RanksInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.RankClasses
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => missions.AsReadOnly();

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.ID} Salary: {base.Salary:F2}");
            builder.AppendLine($"Corps: {base.Corps}"); 
            builder.AppendLine("Missions:");
            foreach (IMission mission in missions)
                builder.AppendLine($"  {mission.ToString()}");
            return builder.ToString().TrimEnd();
        }
    }
}
