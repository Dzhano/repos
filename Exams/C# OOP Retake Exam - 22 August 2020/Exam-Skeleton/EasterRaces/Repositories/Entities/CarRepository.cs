using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private Dictionary<string, ICar> models;

        public CarRepository() => models = new Dictionary<string, ICar>();

        public void Add(ICar model)
        {
            if (models.ContainsKey(model.Model))
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model.Model));

            models.Add(model.Model, model);
        }

        public IReadOnlyCollection<ICar> GetAll() => models.Values;

        public ICar GetByName(string name)
        {
            ICar car = models.FirstOrDefault(t => t.Key == name).Value;
            if (car == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, name));
            return car;
        }

        public bool Remove(ICar model) => models.Remove(model.Model);
    }
}
