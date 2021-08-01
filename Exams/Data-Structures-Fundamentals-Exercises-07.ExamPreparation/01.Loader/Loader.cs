namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Loader : IBuffer
    {
        private List<IEntity> entities;

        public Loader() => entities = new List<IEntity>();


        public int EntitiesCount => entities.Count;

        public void Add(IEntity entity) => entities.Add(entity);

        public void Clear() => entities.Clear();

        public bool Contains(IEntity entity) => entities.Contains(entity);

        public IEntity Extract(int id)
        {
            IEntity entity = entities.FirstOrDefault(e => e.Id == id);

            entities.Remove(entity);

            return entity;
        }

        public IEntity Find(IEntity entity) => entities.FirstOrDefault(e => e == entity);

        public List<IEntity> GetAll() => new List<IEntity>(entities);

        public void RemoveSold() => entities.RemoveAll(e => e.Status == BaseEntityStatus.Sold);

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            if (!Contains(oldEntity)) throw new InvalidOperationException("Entity not found");

            int index = entities.IndexOf(oldEntity);
            entities[index] = newEntity;
        }

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound) 
            => entities.Where(e => e.Status >= lowerBound && e.Status <= upperBound).ToList();

        public void Swap(IEntity first, IEntity second)
        {
            int firstIndex = entities.IndexOf(first);
            int secondIndex = entities.IndexOf(second);

            if (firstIndex == -1 || secondIndex == -1)
                throw new InvalidOperationException("Entity not found");

            entities[firstIndex] = second;
            entities[secondIndex] = first;
        }

        public IEntity[] ToArray() => entities.ToArray();

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            foreach (IEntity entity in entities) 
                if (entity.Status == oldStatus) entity.Status = newStatus;
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            for (int i = 0; i < EntitiesCount; i++) yield return entities[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
