using MilitaryElite.Enums;
using MilitaryElite.RanksInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Jobs
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionState missionState)
        {
            CodeName = codeName;
            State = missionState;
        }

        public string CodeName { get; private set; }
        public MissionState State { get; private set; }

        public void CompleteMission()
        {
            State = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}".TrimEnd();
        }
    }
}
