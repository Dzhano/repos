using MilitaryElite.RankClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.RanksInterfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }

        void AddPrivate(IPrivate @private);
    }
}
