using Skeleton.FakeInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests.Fakes
{
    public class FakeTarget : ITarget
    {
        public void TakeAttack(int attackPoints) {  }

        public int Health => 0;

        public int GiveExperience() => 20;

        public bool IsDead() => true;
    }
}
