namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void Setup()
        {
            aquarium = new Aquarium("Oceania", 10);
            fish = new Fish("Nemo");
        }

        [Test]
        public void Count_ReturnsZero_WhenThereAreNoFishs()
        {
            Assert.AreEqual(aquarium.Count, 0);
        }

        [Test]
        public void Name_Successfull()
        {
            aquarium = new Aquarium("Oceania", 10);
            Assert.AreEqual(aquarium.Name, "Oceania");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Name_ThrowsException_WhenNameIsInvalid(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 6));
        }

        [Test]
        [TestCase(5)]
        [TestCase(0)]
        public void Capacity_Successfull(int capacity)
        {
            aquarium = new Aquarium("Oceania", capacity);
            Assert.AreEqual(aquarium.Capacity, capacity);
        }
        
        [Test]
        public void Capacity_ThrowsException_WhenInputIsLessThanZero()
        {
            Exception exception = Assert.Throws<ArgumentException>(() => new Aquarium("Atlanta", -1));
            Assert.AreEqual(exception.Message, "Invalid aquarium capacity!");
        }

        [Test]
        [TestCase(2)]
        [TestCase(8)]
        [TestCase(10)]
        public void Add_Successfull(int n)
        {
            for (int i = 0; i < n; i++) aquarium.Add(fish);
            Assert.AreEqual(aquarium.Count, n);
        }

        [Test]
        public void Add_ThrowsInvalidOperationException_WhenThereIsNoMoreSpace()
        {
            for (int i = 0; i < 10; i++) aquarium.Add(fish);
            Exception exception = Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
            Assert.AreEqual(exception.Message, "Aquarium is full!");
        }

        [Test]
        public void RemoveFish_Successfull()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish(fish.Name);
            Assert.AreEqual(aquarium.Count, 0);
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(0)]

        public void RemoveFish_ThrowsInvalidOperationException_WhenFishDoesNotExist(int n)
        {
            string name = "Pesho";
            for (int i = 0; i < n; i++) aquarium.Add(fish);
            Exception exception = Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(name));
            Assert.AreEqual(exception.Message, $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void SellFish_Successfull()
        {
            aquarium.Add(fish);
            Fish soldFish = aquarium.SellFish(fish.Name);

            Assert.AreEqual(soldFish.Name, fish.Name);
            Assert.AreEqual(soldFish.Available, false);
        }

        [Test]
        [TestCase(1)]
        [TestCase(0)]
        public void SellFish_ThrowsInvalidOperationException_WhenFishDoesNotExist(int n)
        {
            string name = "Pesho";
            for (int i = 0; i < n; i++) aquarium.Add(fish);
            Exception exception = Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(name));
            Assert.AreEqual(exception.Message, $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void Report_ReturnsNameOfFishes(int n)
        {
            List<string> fishNames = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string fishName = $"Fish{i}";

                aquarium.Add(new Fish(fishName));
                fishNames.Add(fishName);
            }

            string expectedReport = $"Fish available at {aquarium.Name}: {string.Join(", ", fishNames)}";
            string actualReport = aquarium.Report();

            Assert.AreEqual(expectedReport, actualReport);
        }
    }
}
