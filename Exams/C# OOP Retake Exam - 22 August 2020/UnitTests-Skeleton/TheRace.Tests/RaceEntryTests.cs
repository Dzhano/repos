using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        private UnitDriver driver;
        private UnitCar car;

        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
            car = new UnitCar("Ford S-Max", 200, 500);
            driver = new UnitDriver("Dzhano", car);
        }

        [Test]
        public void AddDriver_Successfull()
        {
            Assert.AreEqual(race.AddDriver(driver), $"Driver {driver.Name} added in race.");
        }
        
        [Test]
        public void AddDriver_ThrowsInvalidOperationException_WhenDriverIsNull()
        {
            Exception exception = Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
            Assert.AreEqual(exception.Message, "Driver cannot be null.");
        }
        
        [Test]
        public void AddDriver_ThrowsInvalidOperationException_WhenCarAlreadyExist()
        {
            race.AddDriver(driver);
            Exception exception = Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
            Assert.AreEqual(exception.Message, $"Driver {driver.Name} is already added.");
        }
        
        [Test]
        public void Counter_IsZero_WhenDriverIsEmpty()
        {
            Assert.AreEqual(race.Counter, 0);
        }

        [Test]
        public void CalculateAverageHorsePower_Successfull()
        {
            race.AddDriver(driver);
            race.AddDriver(new UnitDriver("Tisho", new UnitCar("Audi", 160, 300)));

            double averageHorsePower = race.CalculateAverageHorsePower();
            Assert.AreEqual(averageHorsePower, 180);
        }
        
        [Test]
        public void CalculateAverageHorsePower_ThrowsInvalidOperationException_WhenDriversAreLessThanMinParticipants()
        {
            race.AddDriver(driver);
            Exception exception = Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
            Assert.AreEqual(exception.Message, "The race cannot start with less than 2 participants.");
        }
    }
}