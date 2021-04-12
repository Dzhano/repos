using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private Dictionary<string, IRace> models;

        public RaceRepository() => models = new Dictionary<string, IRace>();

        public void Add(IRace model) 
        {
            if (models.ContainsKey(model.Name))
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, model.Name));

            models.Add(model.Name, model);
        }

        public IReadOnlyCollection<IRace> GetAll() => models.Values;

        public IRace GetByName(string name)
        {
            IRace race = models.FirstOrDefault(t => t.Key == name).Value;
            if (race == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, name));
            return race;
        }

        public bool Remove(IRace model) => models.Remove(model.Name);
    }
}
