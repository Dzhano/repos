using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.RanksInterfaces
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}
