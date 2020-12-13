using NUnit.Framework;
using System;
using System.Collections.Generic;
using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        private Warrior firstWarrior;
        private Warrior secondWarrior;

        [SetUp]
        public void Setup()
        {
            this.firstWarrior = new Warrior("Gosho", 20, 40);
            this.secondWarrior = new Warrior("Pesho", 22, 38);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Arena arena = new Arena();
            List<Warrior> warriors = new List<Warrior>();

            CollectionAssert.AreEqual(arena.Warriors, warriors);
        }

        [Test]
        public void CountPropertyShouldWorkCorrectly()
        {
            Arena arena = new Arena();
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            int count = 2;

            Assert.AreEqual(count, arena.Count);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionWhenNamesAreEqual()
        {
            Warrior warrior = new Warrior("Gosho", 15, 30);
            Arena arena = new Arena();
            arena.Enroll(firstWarrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            });
        }

        [Test]
        public void EnrollMethodShouldWorkProperly()
        {
            Arena arena = new Arena();
            arena.Enroll(this.firstWarrior);
            arena.Enroll(this.secondWarrior);

            List<Warrior> warriors = new List<Warrior>();
            warriors.Add(this.firstWarrior);
            warriors.Add(this.secondWarrior);

            CollectionAssert.AreEqual(arena.Warriors, warriors);
        }

        [Test]
        public void FightMethodShouldThrowExceptionWhenDefenderNameIsNull()
        {
            Arena arena = new Arena();
            arena.Enroll(this.firstWarrior);
            string attacker = this.firstWarrior.Name;
            string defender = this.secondWarrior.Name;

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attacker, defender);
            });
        }

        [Test]
        public void FightMethodShouldThrowExceptionWhenAttackerIsNull()
        {
            Arena arena = new Arena();
            arena.Enroll(this.secondWarrior);
            string attacker = this.firstWarrior.Name;
            string defender = this.secondWarrior.Name;

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attacker, defender);
            });
        }

        [Test]
        public void FightMethodShouldWorkProperly()
        {
            Arena arena = new Arena();
            arena.Enroll(this.firstWarrior);
            arena.Enroll(this.secondWarrior);

            string attacker = this.firstWarrior.Name;
            string defender = this.secondWarrior.Name;

            arena.Fight(attacker, defender);
            int expectedHp = 18;

            Assert.AreEqual(expectedHp, this.secondWarrior.HP);
        }
    }
}
