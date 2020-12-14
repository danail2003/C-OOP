namespace Aquariums.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    
    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void TestUnit()
        {
            this.fish = new Fish("Gosho");
            this.aquarium = new Aquarium("Ocean", 10);
        }

        [Test]
        public void ConstructorShouldWorkCorrect()
        {
            Fish fish = new Fish("Ivan");

            string name = "Ivan";

            Assert.AreEqual(name, fish.Name);
            Assert.IsTrue(fish.Available);
        }

        [Test]
        public void ConstructorInitializeValueCorrect()
        {
            Aquarium aquarium = new Aquarium("Ocean", 10);

            string name = "Ocean";
            int capacity = 10;

            Assert.AreEqual(name, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
        }

        [Test]
        public void FishNameShouldWorkCorrect()
        {
            this.fish.Name = "Pesho";

            Assert.AreEqual(this.fish.Name, "Pesho");
        }

        [Test]
        public void FishAvailableShouldWorkProperly()
        {
            this.fish.Available = false;

            Assert.IsFalse(this.fish.Available);
        }

        [TestCase("")]
        [TestCase(null)]
        public void NameShouldThrowExceptionWhenValueIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.aquarium = new Aquarium(name, 10);
            });
        }

        [Test]
        public void NameShouldReturnCorrectValue()
        {
            Aquarium aquarium = new Aquarium("Sea", 10);

            Assert.AreEqual("Sea", aquarium.Name);
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenValueIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.aquarium = new Aquarium("Ocean", -1);
            });
        }

        [Test]
        public void CapacityShouldWorkCorrect()
        {
            Assert.AreEqual(10, this.aquarium.Capacity);
        }

        [Test]
        public void FishCountShouldReturnCorrectValue()
        {
            this.aquarium.Add(new Fish("Nemo"));
            this.aquarium.Add(new Fish("Dorry"));

            Assert.AreEqual(2, this.aquarium.Count);
        }

        [Test]
        public void AddShouldThrowExceptionWhenCapacityIsFull()
        {
            this.aquarium.Add(new Fish("1"));
            this.aquarium.Add(new Fish("2"));
            this.aquarium.Add(new Fish("3"));
            this.aquarium.Add(new Fish("4"));
            this.aquarium.Add(new Fish("5"));
            this.aquarium.Add(new Fish("6"));
            this.aquarium.Add(new Fish("7"));
            this.aquarium.Add(new Fish("8"));
            this.aquarium.Add(new Fish("9"));
            this.aquarium.Add(new Fish("10"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.aquarium.Add(new Fish("11"));
            });
        }

        [Test]
        public void AddShouldWorkCorrect()
        {
            this.aquarium.Add(this.fish);

            Assert.AreEqual(1, this.aquarium.Count);
        }

        [TestCase("Dorry")]
        public void RemoveFishShouldThrowExceptionWhenFishIsNull(string name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.aquarium.RemoveFish(name);
            });
        }

        [Test]
        public void RemoveFishShouldWorkProperly()
        {
            this.aquarium.Add(new Fish("1"));
            this.aquarium.Add(new Fish("2"));
            this.aquarium.Add(new Fish("3"));

            this.aquarium.RemoveFish("2");

            Assert.AreEqual(2, this.aquarium.Count);
        }

        [TestCase("Godo")]
        public void SellFishShouldThrowExceptionWhenFishDoesntExists(string name)
        {
            this.aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.aquarium.SellFish(name);
            });
        }

        [Test]
        public void SellFishShouldWorkCorrect()
        {
            this.aquarium.Add(fish);

            this.aquarium.SellFish(fish.Name);

            Assert.IsFalse(this.fish.Available);
        }

        [Test]
        public void SellFishShouldReturnCorrectFish()
        {
            this.aquarium.Add(this.fish);
            this.aquarium.Add(new Fish("nemo"));

            Fish soldFish = this.aquarium.SellFish("nemo");

            Assert.AreEqual("nemo", soldFish.Name);
            Assert.IsFalse(soldFish.Available);
        }

        [Test]
        public void ReportShouldWorkCorrect()
        {
            List<Fish> allFish = new List<Fish>();
            allFish.Add(this.fish);
            allFish.Add(new Fish("Nemo"));
            this.aquarium.Add(this.fish);
            this.aquarium.Add(new Fish("Nemo"));

            string message = $"Fish available at {this.aquarium.Name}: {string.Join(", ", allFish.Select(x=>x.Name))}";

            Assert.AreEqual(this.aquarium.Report(), message);
        }
    }
}
