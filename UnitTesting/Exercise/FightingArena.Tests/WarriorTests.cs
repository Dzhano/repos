using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        private const string name = "Dzhano";
        private const int damage = 15;
        private const int hp = 120;

        private const string secondName = "Second";

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior(name, damage, hp);
        }

        [Test]
        public void Constructor_Successful()
        {
            Warrior secondWarrior = new Warrior(name, damage, hp);

            Assert.That(warrior.Name, Is.EqualTo(secondWarrior.Name));
            Assert.That(warrior.Damage, Is.EqualTo(secondWarrior.Damage));
            Assert.That(warrior.HP, Is.EqualTo(secondWarrior.HP));
        }
        
        [Test]
        [TestCase(null, damage, hp)]
        [TestCase(" ", damage, hp)]
        [TestCase("", damage, hp)]
        [TestCase("  ", damage, hp)]
        [TestCase(name, 0, hp)]
        [TestCase(name, -2, hp)]
        [TestCase(name, damage, -5)]
        public void Constructor_Name_ThrowsException_IfItIsNullOrWhiteSpace(string badName, int badDamage, int badHP)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(badName, badDamage, badHP),
                "One of the inputs is unacceptable.");
        }



        [Test]
        [TestCase(62, 105)]
        [TestCase(62, 31)]
        public void Attack_Successful_WithSecondHP_BiggerOrEqualThanFirstDamage(int secondDamage, int secondHP)
        {
            warrior = new Warrior(name, 31, hp);
            Warrior secondWarrior = new Warrior(secondName, secondDamage, secondHP);

            warrior.Attack(secondWarrior);

            Assert.That(warrior.HP, Is.EqualTo(hp - secondDamage));
            Assert.That(secondWarrior.HP, Is.EqualTo(secondHP - 31));
        }

        [Test]
        [TestCase(62, 49)]
        [TestCase(62, 36)]
        public void Attack_Successful_WithSecondHP_SmallerThanFirstDamage(int secondDamage, int secondHP)
        {
            warrior = new Warrior(name, 50, hp);
            Warrior secondWarrior = new Warrior(secondName, secondDamage, secondHP);

            warrior.Attack(secondWarrior);

            Assert.That(warrior.HP, Is.EqualTo(hp - secondDamage));
            Assert.That(secondWarrior.HP, Is.EqualTo(0));
        }
        
        [Test]
        [TestCase(12, 62, 105)]
        [TestCase(30, 62, 105)]
        [TestCase(hp, 130, 105)]
        [TestCase(hp, 62, 12)]
        [TestCase(hp, 62, 30)]
        public void Attack_ThrowsException(int firstHP, int secondDamage, int secondHP)
        {
            warrior = new Warrior(name, damage, firstHP);
            Warrior secondWarrior = new Warrior(secondName, secondDamage, secondHP);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(secondWarrior));
        }
    }
}