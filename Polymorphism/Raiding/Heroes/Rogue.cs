using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Heroes
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) 
            : base(name, 80)
        {
        }

        public override string CastAbility()
        {
            return $"Rogue - {base.Name} hit for {base.Power} damage";
        }
    }
}
