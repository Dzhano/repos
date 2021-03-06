using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.RanksInterfaces
{
    public interface ISoldier
    {
        string ID { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}
