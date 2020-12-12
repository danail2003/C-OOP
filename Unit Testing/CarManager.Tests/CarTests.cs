using NUnit.Framework;
using System;
using CarManager;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Audi", "A8", 8.5, 15);
        }

        [Test]
        public void ConstructorShouldReturnCorrectCount()
        {
            Assert.IsNotNull(car);
        }

        [Test]
        public void MakePropertyShouldThrowExceptionWhenIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(null, "123", 15, 16);
            });
        }

        [Test]
        public void ModelPropertyShouldThrowExceptionWhenIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", null, 15, 16);
            });
        }

        [Test]
        public void FuelConsumptionShouldThrowExceptionIfDataIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "A8", 0, 15);
            });
        }

        [Test]
        public void FuelConsumptionShouldThrowExceptionIfDataIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "A8", -5, 15);
            });
        }

        [Test]
        public void FuelCapacityShouldThrowExceptionIfDataIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "A8", 10, 0);
            });
        }

        [Test]
        public void FuelCapacityShouldThrowExceptionIfDataIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "A8", 10, -5);
            });
        }

        [Test]
        public void FuelAmountShouldThrowException()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void RefuelMethodShouldThrowExceptionIfDataIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            });
        }

        [Test]
        public void RefuelMethodShouldThrowExceptionIfDataIsnegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-5);
            });
        }

        [Test]
        public void FuelAmountShouldIncreaseWhenRefueling()
        {
            double amount = 15;
            car.Refuel(amount);

            Assert.AreEqual(car.FuelAmount, amount);
        }

        [Test]
        public void DriveMethodShouldThrowExceptionWhenNeededFuelIsBiggerThanFuelAmount()
        {
            car.Refuel(1);
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }

        [Test]
        public void DriveMethodShouldWorkCorrectly()
        {
            car.Refuel(10);
            car.Drive(10);

            double fuel = 9.15;

            Assert.AreEqual(fuel, car.FuelAmount);
        }

        [Test]
        public void RefuelingShouldWorkCorrectly()
        {
            car.Refuel(20);

            Assert.AreEqual(15, car.FuelAmount);
        }
    }
}