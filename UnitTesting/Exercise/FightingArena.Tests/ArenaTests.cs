using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        private const string warriorName = "Dzhano";
        private const int warriorDamage = 15;
        private const int warriorHP = 120;
        private Warrior warrior = new Warrior(warriorName, warriorDamage, warriorHP);

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Constructor_InitializeWarriors()
        {
            Assert.That(arena.Warriors, Is.Not.Null);
        }
        
        [Test]
        public void Constructor_InitializeArena()
        {
            arena = new Arena();
            Assert.That(arena, Is.Not.Null);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void Enroll_ListWarriorsAddSuccessful_EmptyOr_OneOrMoreWarrior(int n)
        {
            List<Warrior> someWarriors = new List<Warrior>(); 
            for (int i = 0; i < n; i++)
            {
                Warrior newWarrior = new Warrior($"{warriorName}{i}", warriorDamage, warriorHP);
                someWarriors.Add(newWarrior);
                arena.Enroll(newWarrior);
            }

            Assert.That(arena.Warriors, Is.EqualTo(someWarriors));
            Assert.That(arena.Count, Is.EqualTo(someWarriors.Count), "Count doesn't work properly."); // We can test the count directly here.
            Assert.That(arena.Warriors.Count, Is.EqualTo(someWarriors.Count), "Count doesn't work properly."); // We can test the count directly here.
        }

        [Test]
        public void Enrol_ThrowsException_IfWarriorWithThatNameAlreadyExist()
        {
            arena.Enroll(warrior);
            Assert.That(() => arena.Enroll(warrior), 
                Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"),
                "More warriors with the same name can be enrolled.");
        }

        [Test]
        public void Fight_Successful()
        {
            string defender = "EnemyWarrior";
            Warrior enemy = new Warrior(defender, 62, 105);

            arena.Enroll(new Warrior(warriorName, warriorDamage, warriorHP));
            arena.Enroll(new Warrior(defender, 62, 105));

            arena.Fight(warriorName, defender);
            warrior.Attack(enemy);

            List<Warrior> warriors = arena.Warriors.ToList();

            Assert.That(warriors[0].Name, Is.EqualTo(warrior.Name));
            Assert.That(warriors[0].HP, Is.EqualTo(warrior.HP));
            Assert.That(warriors[0].Damage, Is.EqualTo(warrior.Damage));
            Assert.That(warriors[1].Name, Is.EqualTo(enemy.Name));
            Assert.That(warriors[1].HP, Is.EqualTo(enemy.HP));
            Assert.That(warriors[1].Damage, Is.EqualTo(enemy.Damage));
            Assert.That(2, Is.EqualTo(arena.Count)); // We can test the count directly here.
            Assert.That(2, Is.EqualTo(arena.Warriors.Count)); // We can test the count directly here.
        }

        [Test]
        [TestCase(warriorName, "Peter")]
        [TestCase("Peter", warriorName)]
        [TestCase("Gosho", "Peter")]
        public void Fight_ThrowsException_IfOneOrBothWarriorsDoesNotExist(string attacker, string defender)
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, defender), "The fight shouldn't be possible.");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Count(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Warrior newWarrior = new Warrior($"{warriorName}{i}", warriorDamage, warriorHP);
                arena.Enroll(newWarrior);
            }

            Assert.That(arena.Count, Is.EqualTo(n), "Count doesn't work properly.");
        }
    }
}
