using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.RanksInterfaces
{
    public interface IRepair
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}
