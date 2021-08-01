namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;
    using _02.LegionSystem.Interfaces;

    public class Legion : IArmy
    {
        private OrderedSet<IEnemy> _enemies;

        public Legion()
        {
            this._enemies = new OrderedSet<IEnemy>();
        }

        // O(1)
        public int Size => this._enemies.Count;

        // O(logN)
        public void Create(IEnemy enemy)
        {
            this._enemies.Add(enemy);
        }

        // O(n*logN)
        public IEnemy GetByAttackSpeed(int speed)
        {
            for (int i = 0; i < this.Size; i++)
            {
                var enemy = this._enemies[i];
                if (enemy.AttackSpeed == speed)
                {
                    return enemy;
                }
            }

            return null;
        }

        // O(logN)
        public bool Contains(IEnemy enemy)
        {
            return this._enemies.Contains(enemy);
        }

        // O(logN)
        public IEnemy GetFastest()
        {
            this.EnsureNotEmpty();

            return this._enemies.GetFirst();
        }

        // O(logN)
        public IEnemy GetSlowest()
        {
            this.EnsureNotEmpty();

            return this._enemies.GetLast();
        }

        // O(logN)
        public void ShootFastest()
        {
            this.EnsureNotEmpty();

            this._enemies.RemoveFirst();
        }

        // O(logN)
        public void ShootSlowest()
        {
            this.EnsureNotEmpty();

            this._enemies.RemoveLast();
        }

        // O(n ^ 2) ?
        public IEnemy[] GetOrderedByHealth()
        {
            var byHealthSet = new OrderedBag<IEnemy>(this._enemies, 
                CompareByHealth);

            return byHealthSet.ToArray();
        }

        // O(n)
        public List<IEnemy> GetFaster(int speed)
        {
            var result = new List<IEnemy>(this.Size);

            foreach (var enemy in this._enemies)
            {
                if (enemy.AttackSpeed > speed)
                {
                    result.Add(enemy);
                }
            }

            return result;
        }

        // O(n)
        public List<IEnemy> GetSlower(int speed)
        {
            var result = new List<IEnemy>(this.Size);

            foreach (var enemy in this._enemies)
            {
                if (enemy.AttackSpeed < speed)
                {
                    result.Add(enemy);
                }
            }

            return result;
        }

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
        }

        private int CompareByHealth(IEnemy first, IEnemy second)
        {
            return second.Health - first.Health;
        }
    }
}
