using NUnit.Framework;
using System;
using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Gosho", 50, 40);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            string name = "Gosho";
            int damage = 50;
            int hp = 40;

            Assert.AreEqual(name, this.warrior.Name);
            Assert.AreEqual(damage, this.warrior.Damage);
            Assert.AreEqual(hp, this.warrior.HP);
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        [TestCase(" ")]
        public void NamePropertyShouldThrowExceptionIfNameIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 10, 10);
            });
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void DamagePropertyShouldThrowExceptionIfValueIsZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Gosho", damage, 10);
            });
        }

        [Test]
        public void HpPropertyShouldThrowExceptionIfValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Gosho", 10, -1);
            });
        }

        [TestCase(25)]
        [TestCase(30)]
        public void AttackMethodShouldThrowExceptionWhenMinHpIsBelowOrEqual30(int hp)
        {
            Warrior weakWarrior = new Warrior("Pesho", 10, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                weakWarrior.Attack(this.warrior);
            });
        }

        [TestCase(30)]
        [TestCase(25)]
        public void AttackMethodShouldThrowExceptionWhenWeAttackWeakWarriors(int hp)
        {
            Warrior weakWarrior = new Warrior("Pesho", 10, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.warrior.Attack(weakWarrior);
            });
        }

        [Test]
        public void AttackMethodShouldThrowExceptionWhenWarriorDamageIsBiggerThanYourHp()
        {
            Warrior weakWarrior = new Warrior("Pesho", 10, 32);

            Assert.Throws<InvalidOperationException>(() =>
            {
                weakWarrior.Attack(this.warrior);
            });
        }

        [Test]
        public void AttackMethodShouldWorkCorrectly()
        {
            Warrior secondWarrior = new Warrior("Pesho", 10, 50);
            int expectedHp = 30;
            secondWarrior.Attack(this.warrior);

            Assert.AreEqual(this.warrior.HP, expectedHp);
        }

        [Test]
        public void HpShouldBeZeroIfDamageOfEnemyIsBiggerThanHp()
        {
            Warrior weakWarrior = new Warrior("Pesho", 10, 39);
            this.warrior.Attack(weakWarrior);

            Assert.AreEqual(0, weakWarrior.HP);
        }
    }
}