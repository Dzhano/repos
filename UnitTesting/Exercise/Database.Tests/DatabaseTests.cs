using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private int[] array;

        [SetUp]
        public void Setup()
        {
            array = new int[0];
            database = new Database.Database(array);
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++) database.Add(i);
            Assert.Throws<InvalidOperationException>(() => database.Add(17), "Add more elements in database even if there isn't any space.");
        }

        [Test]
        public void Add_IncreasesCount_IfCapacityIsNotExceeded()
        {
            int n = 10;
            for (int i = 0; i < n; i++) database.Add(i);
            Assert.That(database.Count, Is.EqualTo(n), "Cannot add more elements in database even if there is still space.");
        }

        [Test]
        public void Remove_Successful_IfDatabaseIsNotEmpty()
        {
            database.Add(8);
            database.Add(9);
            database.Add(10);
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(2), "Database doesn't remove elements successfully.");
        }

        [Test]
        public void Remove_ThrowsException_IfDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove(), "Removes elements even if database is empty.");
        }

        [Test]
        public void Fetch_Returns_TheSameArray()
        {
            Assert.That(database.Fetch(), Is.EqualTo(array), "Database doesn't return the same or all of the elements.");
        }

        [Test]
        public void Fetch_Returns_TheSameArray_SecondTest()
        {
            database.Add(13);
            int[] elements = database.Fetch();
            Assert.IsTrue(elements.Contains(13));
        }

        [Test]
        public void Count_ReturnsZero_WhenDatabaseIsEmpty()
        {
            Assert.That(database.Count, Is.EqualTo(0), "The count is not equal to zero.");
        }

        [Test]
        public void Constructor_ThrowsException_WhenDatabaseCapacityIsExceeded()
        {
            Assert.Throws<InvalidOperationException>
                (() => database = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        public void Constructor_AddingElements()
        {
            int[] arr = { 1, 2, 3 };
            database = new Database.Database(arr);

            Assert.That(database.Count, Is.EqualTo(arr.Length));
            Assert.That(database.Fetch(), Is.EquivalentTo(arr));
        }
    }
}