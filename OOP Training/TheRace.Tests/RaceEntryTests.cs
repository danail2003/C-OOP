using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitRider unitRider;
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.unitRider = new UnitRider("Gosho", new UnitMotorcycle("BMW", 100, 35));
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void ConstructorShouldInitializeCorrectValue()
        {
            UnitRider unitRider = new UnitRider("Pesho", new UnitMotorcycle("Yamaha", 50, 150));

            Assert.AreEqual("Pesho", unitRider.Name);
            Assert.AreEqual("Yamaha", unitRider.Motorcycle.Model);
            Assert.AreEqual(50, unitRider.Motorcycle.HorsePower);
            Assert.AreEqual(150, unitRider.Motorcycle.CubicCentimeters);
        }

        [Test]
        public void RaceEntryConstructorShouldWorkCorrect()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void AddRiderShouldThrowExceptionWhenRiderIsNull()
        {
            UnitRider unitRider = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.AddRider(unitRider);
            });
        }

        [Test]
        public void AddRidetShouldThrowExceptionWhenRiderExist()
        {
            this.raceEntry.AddRider(this.unitRider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.AddRider(this.unitRider);
            });
        }

        [Test]
        public void AddRiderShouldWorkProperly()
        {
            this.raceEntry.AddRider(this.unitRider);

            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void AddRiderShouldAddCorrectRider()
        {
            string message = $"Rider {this.unitRider.Name} added in race.";

            Assert.AreEqual(message, this.raceEntry.AddRider(this.unitRider));
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowExceptionWhenCountIsLessThanMinParticipants()
        {
            this.raceEntry.AddRider(this.unitRider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.CalculateAverageHorsePower();
            });
        }

        [Test]
        public void CalculateAverageHorsePowerShouldReturnCorrectValue()
        {
            this.raceEntry.AddRider(this.unitRider);
            this.raceEntry.AddRider(new UnitRider("Ivan", new UnitMotorcycle("Suzuki", 75, 100)));

            Assert.AreEqual(87.5, this.raceEntry.CalculateAverageHorsePower());
        }
    }
}