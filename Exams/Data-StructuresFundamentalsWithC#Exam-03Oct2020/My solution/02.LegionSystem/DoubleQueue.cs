namespace _02.LegionSystem
{
    using _02.LegionSystem.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DoubleQueue
    {
        private List<IEnemy> big;
        private List<IEnemy> small;

        public DoubleQueue()
        {
            big = new List<IEnemy>();
            small = new List<IEnemy>();
        }

        public bool Constains(int speed)
        {
            IEnemy enemy = big.FirstOrDefault(e => e.AttackSpeed == speed);

            if (enemy != null) return true;
            else return false;
        }

        public int Size => big.Count;

        public IEnemy DequeueBiggest()
        {
            if (Size > 0)
            {
                IEnemy returned = big[0];
                big[0] = big[big.Count - 1];
                big.RemoveAt(big.Count - 1);

                HeapifyDownBiggest(0);

                IEnemy enemy2 = small.FirstOrDefault(e => e.AttackSpeed == returned.AttackSpeed);
                small.Remove(enemy2);

                return returned;
            }
            else throw new InvalidOperationException("Legion has no enemies!");
        }

        public IEnemy DequeueSmallest()
        {
            if (Size > 0)
            {
                IEnemy returned = small[0];
                small[0] = small[small.Count - 1];
                small.RemoveAt(small.Count - 1);

                HeapifyDownSmallest(0);

                IEnemy enemy = big.FirstOrDefault(e => e.AttackSpeed == returned.AttackSpeed);
                big.Remove(enemy);

                return returned;
            }
            else throw new InvalidOperationException("Legion has no enemies!");
        }

        public IEnemy GetBySpeed(int speed) => big.FirstOrDefault(e => e.AttackSpeed == speed);

        public void Add(IEnemy element)
        {
            big.Add(element);
            HeapifyUpBiggest(Size - 1);

            small.Add(element);
            HeapifyUpSmallest(Size - 1);
        }

        public IEnemy PeekBiggest()
        {
            if (Size > 0) return big[0];
            else throw new InvalidOperationException("Legion has no enemies!");
        }

        public IEnemy PeekSmallest()
        {
            if (Size > 0) return small[0];
            else throw new InvalidOperationException("Legion has no enemies!");
        }

        public IEnemy[] GetOrderedByHealth() => big.OrderByDescending(e => e.Health).ToArray();

        public List<IEnemy> GetFaster(int speed) => big.Where(e => e.AttackSpeed > speed).ToList();

        public List<IEnemy> GetSlower(int speed) => small.Where(e => e.AttackSpeed < speed).ToList();

        private void HeapifyUpBiggest(int index)
        {
            int parentIndex = (index - 1) / 2;
            while (index > 0 && big[index].CompareTo(big[parentIndex]) > 0)
            {
                IEnemy temp = big[index];
                big[index] = big[parentIndex];
                big[parentIndex] = temp;

                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDownBiggest(int index)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= big.Count) return;
            if ((rightChildIndex < big.Count) && big[leftChildIndex].CompareTo(big[rightChildIndex]) < 0)
                maxChildIndex = rightChildIndex;

            if (big[index].CompareTo(big[maxChildIndex]) < 0)
            {
                IEnemy temp = big[index];
                big[index] = big[maxChildIndex];
                big[maxChildIndex] = temp;
                HeapifyDownBiggest(maxChildIndex);
            }
        }

        private void HeapifyUpSmallest(int index)
        {
            int parentIndex = (index - 1) / 2;
            while (index > 0 && small[index].CompareTo(small[parentIndex]) < 0)
            {
                IEnemy temp = small[index];
                small[index] = small[parentIndex];
                small[parentIndex] = temp;

                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDownSmallest(int index)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= small.Count) return;
            if ((rightChildIndex < small.Count) && small[leftChildIndex].CompareTo(small[rightChildIndex]) > 0)
                maxChildIndex = rightChildIndex;

            if (small[index].CompareTo(small[maxChildIndex]) > 0)
            {
                IEnemy temp = small[index];
                small[index] = small[maxChildIndex];
                small[maxChildIndex] = temp;
                HeapifyDownSmallest(maxChildIndex);
            }
        }
    }
}
