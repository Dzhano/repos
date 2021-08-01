namespace _02.Data
{
    using _02.Data.Interfaces;
    using _02.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Data : IRepository
    {
        private OrderedSet<IEntity> entities2;
        private PriorityQueue<IEntity> entities3;

        public Data()
        {
            entities2 = new OrderedSet<IEntity>();
        }

        public int Size => entities2.Count;

        public void Add(IEntity entity) => entities2.Add(entity);

        public IRepository Copy() => this;

        public IEntity DequeueMostRecent()
        {
            if (Size <= 0) throw new InvalidOperationException("Operation on empty Data");

            return entities2.RemoveFirst();
        }

        public List<IEntity> GetAll() => new List<IEntity>(entities2);

        public List<IEntity> GetAllByType(string type)
        {
            if (type == typeof(Invoice).Name || type == typeof(StoreClient).Name || type == typeof(User).Name)
                return entities2.Where(e => e.GetType().Name == type).ToList();
            throw new InvalidOperationException("Invalid type: " + type);
        }

        public IEntity GetById(int id) => entities2.FirstOrDefault(e => e.Id == id);

        public List<IEntity> GetByParentId(int parentId) => entities2.Where(e => e.ParentId == parentId).ToList();

        public IEntity PeekMostRecent()
        {
            if (Size <= 0) throw new InvalidOperationException("Operation on empty Data");

            return entities2.GetFirst();
        }
    }
}
