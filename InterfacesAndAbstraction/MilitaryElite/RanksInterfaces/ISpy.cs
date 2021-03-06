using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.RanksInterfaces
{
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
