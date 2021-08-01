namespace _02.LegionSystem.PerformanceTests
{
    using NUnit.Framework;
    using System;
    using System.Diagnostics;
    using _02.LegionSystem.Interfaces;
    using _02.LegionSystem;
    using _02.LegionSystem.Models;

    public class LegionSystemPerformanceTests
    {
        [Test]
        public void Create_1000_Enemies()
        {
            IArmy legion = new Legion();
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < 1_000; i++)
            {
                legion.Create(new Biomechanoid(i + 1, rnd.Next(500)));
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }

        [Test]
        public void GetByAttackSpeed_1000_Enemies()
        {
            IArmy legion = new Legion();
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < 1_000; i++)
            {
                legion.Create(new Biomechanoid(i + 1, rnd.Next(500)));
            }

            sw.Start();
            for (int i = 0; i < 1_000; i++)
            {
                legion.GetByAttackSpeed(i + 1);
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 90);
        }

        [Test]
        public void Contains_1000_Enemies()
        {
            IArmy legion = new Legion();
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < 1_000; i++)
            {
                legion.Create(new Biomechanoid(i + 1, rnd.Next(500)));
            }

            var getAll = legion.GetOrderedByHealth();

            sw.Start();
            for (int i = 0; i < 1_000; i++)
            {
                legion.Contains(getAll[i]);
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }

        [Test]
        public void GetFastest_1000_Enemies()
        {
            IArmy legion = new Legion();
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < 1_000; i++)
            {
                legion.Create(new Biomechanoid(i + 1, rnd.Next(500)));
            }

            sw.Start();
            for (int i = 0; i < 1_000; i++)
            {
                legion.GetFastest();
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }

        [Test]
        public void GetSlowest_1000_Enemies()
        {
            IArmy legion = new Legion();
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < 1_000; i++)
            {
                legion.Create(new Biomechanoid(i + 1, rnd.Next(500)));
            }

            sw.Start();
            for (int i = 0; i < 1_000; i++)
            {
                legion.GetSlowest();
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }

        [Test]
        public void ShootFastest_1000_Enemies()
        {
            IArmy legion = new Legion();
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < 1_000; i++)
            {
                legion.Create(new Biomechanoid(i + 1, rnd.Next(500)));
            }

            sw.Start();
            for (int i = 0; i < 1_000; i++)
            {
                legion.ShootFastest();
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }

        [Test]
        public void ShootSlowest_1000_Enemies()
        {
            IArmy legion = new Legion();
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < 1_000; i++)
            {
                legion.Create(new Biomechanoid(i + 1, rnd.Next(500)));
            }

            sw.Start();
            for (int i = 0; i < 1_000; i++)
            {
                legion.ShootSlowest();
            }
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }

        [Test]
        public void GetOrderedByHealth_1000_Enemies()
        {
            IArmy legion = new Legion();
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < 1_000; i++)
            {
                legion.Create(new Biomechanoid(i + 1, rnd.Next(500)));
            }

            sw.Start();
            legion.GetOrderedByHealth();
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 100);
        }

        [Test]
        public void GetFaster_1000_Enemies()
        {
            IArmy legion = new Legion();
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < 1_000; i++)
            {
                legion.Create(new Biomechanoid(i + 1, rnd.Next(500)));
            }

            sw.Start();
            legion.GetFaster(0);
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }

        [Test]
        public void GetSlower_1000_Enemies()
        {
            IArmy legion = new Legion();
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < 1_000; i++)
            {
                legion.Create(new Biomechanoid(i + 1, rnd.Next(500)));
            }

            sw.Start();
            legion.GetSlower(1_001);
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
        }
    }
}