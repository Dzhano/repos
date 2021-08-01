namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using _02.LegionSystem.Interfaces;

    public class Legion : IArmy
    {
        private DoubleQueue queue;

        public Legion() => queue = new DoubleQueue();

        public int Size => queue.Size;

        public bool Contains(IEnemy enemy) => queue.Constains(enemy.AttackSpeed);

        public void Create(IEnemy enemy) => queue.Add(enemy);

        public IEnemy GetByAttackSpeed(int speed)
        {
            if (!queue.Constains(speed)) return null;
            //if (!queue.Constains(speed)) return null;

            return queue.GetBySpeed(speed); 
        }

        public List<IEnemy> GetFaster(int speed) => queue.GetFaster(speed);

        public IEnemy GetFastest() => queue.PeekBiggest();

        public IEnemy[] GetOrderedByHealth() => queue.GetOrderedByHealth();

        public List<IEnemy> GetSlower(int speed) => queue.GetSlower(speed);

        public IEnemy GetSlowest() => queue.PeekSmallest();

        public void ShootFastest() => queue.DequeueBiggest();

        public void ShootSlowest() => queue.DequeueSmallest();
    }
}
