using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.FakeInterfaces
{
    public interface ITarget
    {
        void TakeAttack(int attackPoints);

        int Health { get; }

        int GiveExperience();

        bool IsDead();
    }
}
