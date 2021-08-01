namespace _01.Inventory.PerformanceTests
{
    using _01.Inventory;
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using NUnit.Framework;
    using System;
    using System.Diagnostics;

    public class InventoryPerformanceTests
    {
        [Test]
        public void Add_1000_Entries()
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            IHolder inventory = new Inventory();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                int rndAmmunition = rnd.Next(100);
                int rndMaxCapacity = rndAmmunition + 10;

                inventory.Add(new Pistol(i, rndMaxCapacity, rndAmmunition));
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }

        [Test]
        public void GetById_1000_Entries()
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            IHolder inventory = new Inventory();
            for (int i = 0; i < 1000; i++)
            {
                int rndAmmunition = rnd.Next(100);
                int rndMaxCapacity = rndAmmunition + 10;

                inventory.Add(new Pistol(i, rndMaxCapacity, rndAmmunition));
            }

            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                inventory.GetById(1000 - i);
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 30);
        }

        [Test]
        public void Contains_1000_Entries()
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            IHolder inventory = new Inventory();
            for (int i = 0; i < 1000; i++)
            {
                int rndAmmunition = rnd.Next(100);
                int rndMaxCapacity = rndAmmunition + 10;

                inventory.Add(new Pistol(i, rndMaxCapacity, rndAmmunition));
            }

            var allWeapons = inventory.RetrieveAll();

            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                inventory.Contains(allWeapons[allWeapons.Count - i - 1]);
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 50);
        }

        [Test]
        public void Refill_1000_Entries()
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            IHolder inventory = new Inventory();
            for (int i = 0; i < 1000; i++)
            {
                int rndAmmunition = rnd.Next(100);
                int rndMaxCapacity = rndAmmunition + 10;

                inventory.Add(new Pistol(i, rndMaxCapacity, rndAmmunition));
            }

            var allWeapons = inventory.RetrieveAll();
            var weaponToRefil = allWeapons[0];

            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                inventory.Refill(weaponToRefil, 0);
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }

        [Test]
        public void Fire_1000_Entries()
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            IHolder inventory = new Inventory();
            for (int i = 0; i < 1000; i++)
            {
                int rndAmmunition = rnd.Next(100);
                int rndMaxCapacity = rndAmmunition + 10;

                inventory.Add(new Pistol(i, rndMaxCapacity, rndAmmunition));
            }

            var allWeapons = inventory.RetrieveAll();
            var weaponToFire = allWeapons[0];

            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                inventory.Fire(weaponToFire, 0);
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }

        [Test]
        public void RemoveById_1000_Entries()
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            IHolder inventory = new Inventory();
            for (int i = 0; i < 1000; i++)
            {
                int rndAmmunition = rnd.Next(100);
                int rndMaxCapacity = rndAmmunition + 10;

                inventory.Add(new Pistol(i, rndMaxCapacity, rndAmmunition));
            }


            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                inventory.RemoveById(1000 - i - 1);
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 30);
        }

        [Test]
        public void Swap_1000_Entries()
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            IHolder inventory = new Inventory();
            for (int i = 0; i < 1000; i++)
            {
                int rndAmmunition = rnd.Next(100);
                int rndMaxCapacity = rndAmmunition + 10;

                inventory.Add(new Pistol(i, rndMaxCapacity, rndAmmunition));
            }

            var allWeapons = inventory.RetrieveAll();
            var secondToLast = allWeapons[allWeapons.Count - 2];
            var last = allWeapons[allWeapons.Count - 1];

            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                inventory.Swap(secondToLast, last);
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 90);
        }

        [Test]
        public void RetrieveInRange_1000_Entries()
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            IHolder inventory = new Inventory();
            for (int i = 0; i < 1000; i++)
            {
                int rndAmmunition = rnd.Next(100);
                int rndMaxCapacity = rndAmmunition + 10;

                inventory.Add(new Pistol(inventory.Capacity, rndMaxCapacity, rndAmmunition));
                inventory.Add(new Minigun(inventory.Capacity, rndMaxCapacity, rndAmmunition));
                inventory.Add(new Cannon(inventory.Capacity, rndMaxCapacity, rndAmmunition));
            }

            sw.Start();
            inventory.RetriveInRange(Category.Light, Category.Heavy);
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }


        [Test]
        public void EmptyArsenal_1000_Entries()
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            IHolder inventory = new Inventory();
            for (int i = 0; i < 1000; i++)
            {
                int rndAmmunition = rnd.Next(100);
                int rndMaxCapacity = rndAmmunition + 10;

                inventory.Add(new Pistol(i, rndMaxCapacity, rndAmmunition));
            }

            sw.Start();
            inventory.EmptyArsenal(Category.Light);
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }

        [Test]
        public void RemoveHeavy_1000_Entries()
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            IHolder inventory = new Inventory();
            for (int i = 0; i < 1000; i++)
            {
                int rndAmmunition = rnd.Next(100);
                int rndMaxCapacity = rndAmmunition + 10;

                inventory.Add(new Cannon(i, rndMaxCapacity, rndAmmunition));
            }

            sw.Start();
            inventory.RemoveHeavy();
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }
    }
}