using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private ExtendedDatabase.Person[] people;

        [SetUp]
        public void Setup()
        {
            people = new ExtendedDatabase.Person[0];
            database = new ExtendedDatabase.ExtendedDatabase(people);
        }

        [Test]
        public void Constructor_AddingPeople_Successfully()
        {
            database = new ExtendedDatabase.ExtendedDatabase
                (new ExtendedDatabase.Person(0001, "DJ"),
                new ExtendedDatabase.Person(0002, "MJ"));

            Assert.That(database.Count, Is.EqualTo(2), "Doesn't add people properly.");
        }

        [Test]
        public void Constructor_AddingPeople_Failing()
        {
            people = new ExtendedDatabase.Person[17]; 

            Assert.Throws<ArgumentException>
                (() => database = new ExtendedDatabase.ExtendedDatabase(people), "More people are being added than 16.");
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        public void Add_Successfull(int n)
        {
            for (int i = 1; i <= n; i++) 
                database.Add(new ExtendedDatabase.Person(0123456780 + i, $"Dzhano{i}"));

            Assert.That(database.Count, Is.EqualTo(n), "Doesn't add people properly.");
        }
        
        /*[Test]
        public void Add_Successfull_MorePeople()
        {
            database.Add(new ExtendedDatabase.Person(0123456789, "Dzhano"));
            database.Add(new ExtendedDatabase.Person(0123456764, "Peron"));
            database.Add(new ExtendedDatabase.Person(0123456289, "Misho"));

            Assert.That(database.Count, Is.EqualTo(3), "Doesn't add people properly.");
        }*/

        [Test]
        [TestCase(0000000017, "Dzhano")]
        [TestCase(0000001317, "Gosho")]
        public void Add_Failure_UsernameOrIDAlreadyExist(long id, string name)
        {
            database.Add(new ExtendedDatabase.Person(0000001317, "Dzhano"));

            Assert.Throws<InvalidOperationException>
                (() => database.Add(new ExtendedDatabase.Person(id, name)),
                "There can be two or more people with the same username or ID.");
        }
        
        /*[Test]
        public void Add_Failure_IDAlreadyExist()
        {
            database.Add(new ExtendedDatabase.Person(0000001317, "Dzhano"));

            Assert.Throws<InvalidOperationException>
                (() => database.Add(new ExtendedDatabase.Person(0000001317, "Gosho")),
                "There can be two or more people with the same ID.");
        }*/
        
        [Test]
        public void Add_Failure_ExceedTheRange()
        {
            for (int i = 1; i <= 16; i++)
            {
                ExtendedDatabase.Person person = new ExtendedDatabase.Person(0000000000 + i, $"Person{i}");
                database.Add(person);
            }

            Assert.That(() => database.Add(new ExtendedDatabase.Person(0000000017, "Person17")), 
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"), 
                "More people can be added.");
        }

        [Test]
        public void Remove_Successfull()
        {
            database.Add(new ExtendedDatabase.Person(1659, "New person"));
            database.Add(new ExtendedDatabase.Person(1699, "Second person"));
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(1), "Doesn't remove people properly.");
        }

        [Test]
        public void Remove_ThrowsException_IfDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove(), 
                "Removes people even if database is empty.");
        }

        [Test]
        public void FindByUsername_Successful()
        {
            ExtendedDatabase.Person person = new ExtendedDatabase.Person(1317, "Dzhano");
            database.Add(person);
            Assert.That(database.FindByUsername("Dzhano"), Is.EqualTo(person),
                "\"FindByUsername\" doesn't find the person I am looking for by his username.");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_ThrowsException_IfParameterIsNull(string name)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name),
                "\"FindByUsername\" accepts invalid parameter.");
        }
        
        /*[Test]
        public void FindByUsername_ThrowsException_IfParameterIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(""),
                "\"FindByUsername\" accepts invalid empty parameter.");
        }*/
        
        [Test]
        public void FindByUsername_ThrowsException_IfNoSuchPersonExist()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Gosho"), 
                "\"FindByUsername\" finds nonexisting person.");
        }

        [Test]
        public void FindById_Successful()
        {
            ExtendedDatabase.Person person = new ExtendedDatabase.Person(1317, "Dzhano");
            database.Add(person);
            Assert.That(database.FindById(1317), Is.EqualTo(person),
                "\"FindById\" doesn't find the person I am looking for by his ID.");
        }

        [Test]
        public void FindById_ThrowsException_IfIDParameterIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-9845), 
                "\"FindById\" accepts negative ID parameter.");
        }

        [Test]
        public void FindById_ThrowsException_IfNoSuchPersonExist()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(0425),
                "\"FindById\" finds nonexisting person.");
        }
    }
}