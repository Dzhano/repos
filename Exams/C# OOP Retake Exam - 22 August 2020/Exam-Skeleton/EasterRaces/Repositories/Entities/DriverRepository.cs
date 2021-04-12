using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private Dictionary<string, IDriver> models;

        public DriverRepository() => models = new Dictionary<string, IDriver>();

        public void Add(IDriver model) 
        {
            if (models.ContainsKey(model.Name))
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, model.Name));

            models.Add(model.Name, model);
        }

        public IReadOnlyCollection<IDriver> GetAll() => models.Values;

        public IDriver GetByName(string name)
        {
            IDriver driver = models.FirstOrDefault(t => t.Key == name).Value;
            if (driver == null) 
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, name));
            return driver;
        }

        public bool Remove(IDriver model) => models.Remove(model.Name);
    }
}
