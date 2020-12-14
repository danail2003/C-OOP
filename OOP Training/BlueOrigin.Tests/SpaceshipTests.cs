namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SpaceshipTests
    {
        private Astronaut astronaut;
        private Spaceship spaceship;

        [SetUp]
        public void UnitTest()
        {
            this.astronaut = new Astronaut("Gosho", 2.5);
            this.spaceship = new Spaceship("Battlecruiser", 3);
        }

        [Test]
        public void ConstructorShouldInitializeCorrectAstronaut()
        {
            Astronaut astronaut = new Astronaut("Ivan", 3);

            string name = "Ivan";
            double oxygen = 3;

            Assert.AreEqual(astronaut.Name, name);
            Assert.AreEqual(astronaut.OxygenInPercentage, oxygen);
        }

        [Test]
        public void ConstructorOfSpaceshipShouldWorkProperly()
        {
            Spaceship spaceship = new Spaceship("Pesho", 5);

            string name = "Pesho";
            int capacity = 5;

            Assert.AreEqual(spaceship.Name, name);
            Assert.AreEqual(spaceship.Capacity, capacity);
            Assert.AreEqual(spaceship.Count, 0);
        }

        [TestCase("")]
        [TestCase(null)]
        public void NameShoudlThrowExceptionWhenIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Spaceship spaceship = new Spaceship(name, 5);
            });
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenValueIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Spaceship spaceship = new Spaceship("Ivan", -2);
            });
        }

        [Test]
        public void AddShouldThrowExceptionWhenCapacityIsFull()
        {
            this.spaceship.Add(new Astronaut("Ivan", 5.5));
            this.spaceship.Add(new Astronaut("Pesho", 5));
            this.spaceship.Add(new Astronaut("Mimi", 5.6));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(this.astronaut);
            });
        }

        [Test]
        public void AddShouldThrowExceptionWhenAstronautExists()
        {
            this.spaceship.Add(this.astronaut);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(this.astronaut);
            });
        }

        [Test]
        public void AddShouldWorkCorrect()
        {
            this.spaceship.Add(this.astronaut);
            this.spaceship.Add(new Astronaut("Ivan", 5));
            this.spaceship.Add(new Astronaut("Pesho", 6));

            Assert.AreEqual(3, this.spaceship.Count);
        }

        [Test]
        public void RemoveShouldReturnTrueWhenRemoveIsSuccessful()
        {
            this.spaceship.Add(this.astronaut);

            Assert.AreEqual(true, this.spaceship.Remove(this.astronaut.Name));
        }

        [Test]
        public void RemoveShouldReturnFalseWhenAstronautDoesntExist()
        {
            this.spaceship.Add(this.astronaut);
            this.spaceship.Add(new Astronaut("Ivan", 4));

            Assert.AreEqual(false, this.spaceship.Remove("fdsf"));
        }

        [Test]
        public void RemoveShouldWorkCorrect()
        {
            this.spaceship.Add(this.astronaut);
            this.spaceship.Remove("Gosho");

            Assert.AreEqual(0, this.spaceship.Count);
        }
    }
}