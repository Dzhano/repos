namespace _02.Data
{
    using _02.Data.Interfaces;
    using _02.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Data : IRepository
    {
        private List<IEntity> entities;

        public Data() => entities = new List<IEntity>();

        public int Size => entities.Count;

        public void Add(IEntity entity)
        {
            entities.Add(entity);
            HeapifyUp(Size - 1);
        }

        public IRepository Copy() => this;

        public IEntity DequeueMostRecent()
        {
            if (Size > 0)
            {
                IEntity returned = entities[0];
                entities[0] = entities[entities.Count - 1];
                entities.RemoveAt(entities.Count - 1);

                HeapifyDown(0);

                return returned;
            }
            else throw new InvalidOperationException("Operation on empty Data");
        }

        public List<IEntity> GetAll() => new List<IEntity>(entities);

        public List<IEntity> GetAllByType(string type)
        {
            if (type == typeof(Invoice).Name || type == typeof(StoreClient).Name || type == typeof(User).Name)
                return entities.Where(e => e.GetType().Name == type).ToList();
            throw new InvalidOperationException("Invalid type: " + type);
        }

        public IEntity GetById(int id) => entities.FirstOrDefault(e => e.Id == id);

        public List<IEntity> GetByParentId(int parentId) => entities.Where(e => e.ParentId == parentId).ToList();

        public IEntity PeekMostRecent()
        {
            if (Size > 0) return entities[0];
            else throw new InvalidOperationException("Operation on empty Data");
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;
            while (index > 0 && entities[index].CompareTo(entities[parentIndex]) > 0)
            {
                IEntity temp = entities[index];
                entities[index] = entities[parentIndex];
                entities[parentIndex] = temp;

                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= entities.Count) return;
            if ((rightChildIndex < entities.Count) && entities[leftChildIndex].CompareTo(entities[rightChildIndex]) < 0)
                maxChildIndex = rightChildIndex;

            if (entities[index].CompareTo(entities[maxChildIndex]) < 0)
            {
                IEntity temp = entities[index];
                entities[index] = entities[maxChildIndex];
                entities[maxChildIndex] = temp;
                HeapifyDown(maxChildIndex);
            }
        }
    }
}
