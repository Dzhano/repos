using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverRepository;
        private CarRepository carRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
            raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = driverRepository.GetByName(driverName);
            ICar car = carRepository.GetByName(carModel);

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = raceRepository.GetByName(raceName);
            IDriver driver = driverRepository.GetByName(driverName);

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            Car car = null;
            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    break;
            }
            carRepository.Add(car);
            return string.Format(OutputMessages.CarCreated, $"{type}Car", model);
        }

        public string CreateDriver(string driverName)
        {
            driverRepository.Add(new Driver(driverName));
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            raceRepository.Add(new Race(name, laps));
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.GetByName(raceName);
            if (race == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));

            IReadOnlyCollection<IDriver> drivers = race.Drivers;
            if (drivers.Count < 3)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));

            List<IDriver> winners = drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).ToList();
            raceRepository.Remove(race);

            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winners[0].Name, raceName));
            output.AppendLine(string.Format(OutputMessages.DriverSecondPosition, winners[1].Name, raceName));
            output.AppendLine(string.Format(OutputMessages.DriverThirdPosition, winners[2].Name, raceName));
            return output.ToString().TrimEnd();
        }
    }
}
