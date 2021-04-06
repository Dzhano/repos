using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        private const string make = "Ford";
        private const string model = "S-Max";
        private const double fuelConsumption = 20;
        private const double fuelCapacity = 200;

        [SetUp]
        public void Setup()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void Constructor_Successful()
        {
            Car secondCar = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.That(secondCar.Make, Is.EqualTo(car.Make));
            Assert.That(secondCar.Model, Is.EqualTo(car.Model));
            Assert.That(secondCar.FuelConsumption, Is.EqualTo(car.FuelConsumption));
            Assert.That(secondCar.FuelCapacity, Is.EqualTo(car.FuelCapacity));
        }
        
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Constructor_Make_ThrowException(string otherMake)
        {
            Assert.That(() => car = new Car(otherMake, model, fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Constructor_Model_ThrowException(string otherModel)
        {
            Assert.That(() => car = new Car(make, otherModel, fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        [TestCase(0.0)]
        [TestCase(-2.0)]
        public void Constructor_FuelConsumption_ThrowException(double otherFuelConsumption)
        {
            Assert.That(() => car = new Car(make, model, otherFuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        [TestCase(0.0)]
        [TestCase(-1.0)]
        public void Constructor_FuelCapacity_ThrowException(double otherFuelCapacity)
        {
            Assert.That(() => car = new Car(make, model, fuelConsumption, otherFuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        [TestCase(20.0)]
        [TestCase(100.0)]
        public void FuelRefuel_Successful(double fuelToRefuel)
        {
            car.Refuel(fuelToRefuel);
            Assert.That(car.FuelAmount, Is.EqualTo(fuelToRefuel), "Doesn't refuel car properly.");
        }

        [Test]
        [TestCase(0.0)]
        [TestCase(-8.0)]
        public void FuelRefuel_ThrowsException_IfInputIsZeroOrNegative(double fuelToRefuel)
        {
            Assert.That(() => car.Refuel(fuelToRefuel), 
                Throws.ArgumentException.With.
                Message.EqualTo("Fuel amount cannot be zero or negative!"), "Accepts zero or negative amounts.");
        }
        
        [Test]
        [TestCase(200.0)]
        [TestCase(235.0)]
        public void FuelRefuel_Successful_OverOrExactlyAsTheCapacity(double fuelToRefuel)
        {
            car.Refuel(fuelToRefuel);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity), "Adds too much fuel.");
        }

        [Test]
        [TestCase(100.0)]
        [TestCase(500.0)]
        [TestCase(650.0)]
        public void Drive_Successful(double distance)
        {
            car.Refuel(130.00);
            car.Drive(distance);
            Assert.That(car.FuelAmount, Is.EqualTo(130.0 - (distance / 100) * car.FuelConsumption),
                "Doesn't calculate the needed fuel properly.");
        }
        
        [Test]
        [TestCase(651.0)]
        [TestCase(700.0)]
        [TestCase(1000.0)]
        public void Drive_ThrowsException_IfDistanceIsTooMuch(double distance)
        {
            car.Refuel(130.00);
            Assert.That(() => car.Drive(distance), 
                Throws.InvalidOperationException.With.Message
                .EqualTo("You don't have enough fuel to drive!"), 
                "Doesn't calculate the needed fuel properly.");
        }

        [Test]
        public void Drive_ThrowsException_IfFuelIsZero()
        {
            Assert.That(() => car.Drive(20),
                Throws.InvalidOperationException.With.Message
                .EqualTo("You don't have enough fuel to drive!"),
                "Doesn't calculate the needed fuel properly.");
        }
    }
}