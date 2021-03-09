using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Heroes
{
    public class Druid : BaseHero
    {
        public Druid(string name) 
            : base(name, 80)
        {
        }

        public override string CastAbility()
        {
            return $"Druid - {base.Name} healed for {base.Power}";
        }
    }
}
