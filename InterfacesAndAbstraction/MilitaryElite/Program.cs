using MilitaryElite.Enums;
using MilitaryElite.Jobs;
using MilitaryElite.RankClasses;
using MilitaryElite.RanksInterfaces;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string id = data[1];
                string firstName = data[2];
                string lastname = data[3];
                decimal salary = 0;
                if (data[0] != nameof(Spy)) salary = decimal.Parse(data[4]);

                switch (data[0])
                {
                    case nameof(Private):
                        IPrivate @private = new Private(id, firstName, lastname, salary);
                        soldiers.Add(id, @private);
                        break;
                    case nameof(LieutenantGeneral):
                        ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastname, salary);
                        for (int i = 5; i < data.Length; i++)
                        {
                            string privateID = data[i];
                            if (soldiers.ContainsKey(privateID)) 
                                lieutenantGeneral.AddPrivate((IPrivate) soldiers[privateID]);
                        }
                        soldiers.Add(id, lieutenantGeneral);
                        break;
                    case nameof(Engineer):
                        bool isCorpsValid = Enum.TryParse(data[5], out Corps corps);
                        if (!isCorpsValid) continue;

                        IEngineer engineer = new Engineer(id, firstName, lastname, salary, corps);
                        for (int i = 6; i < data.Length; i += 2)
                        {
                            string part = data[i];
                            int hoursWorked = int.Parse(data[i + 1]);
                            IRepair repair = new Repair(part, hoursWorked);
                            engineer.AddRepair(repair);
                        }

                        soldiers.Add(id, engineer);
                        break;
                    case nameof(Commando):
                        bool isCorpsCValid = Enum.TryParse(data[5], out Corps corpsC);
                        if (!isCorpsCValid) continue;

                        ICommando commando = new Commando(id, firstName, lastname, salary, corpsC);
                        for (int i = 6; i < data.Length; i += 2)
                        {
                            string codeName = data[i];
                            string missionState = data[i + 1];

                            bool isMissionStateValid = Enum.TryParse(missionState, out MissionState state);
                            if (!isMissionStateValid) continue;

                            IMission mission = new Mission(codeName, state);
                            commando.AddMission(mission);
                        }

                        soldiers.Add(id, commando);
                        break;
                    case nameof(Spy):
                        int codeNumber = int.Parse(data[4]);
                        ISpy spy = new Spy(id, firstName, lastname, codeNumber);
                        soldiers.Add(id, spy);
                        break;
                }
            }

            foreach (ISoldier soldier in soldiers.Values)
                Console.WriteLine(soldier);
        }
    }
}
