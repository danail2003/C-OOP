namespace ParkingSystem.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark softPark;
        private const string Make = "Audi";
        private const string RegNumber = "999999";

        [SetUp]
        public void Setup()
        {
            this.car = new Car(Make, RegNumber);
            this.softPark = new SoftPark();
        }

        [Test]
        public void ConstructorShouldWorkCorrect()
        {
            Car car = new Car(Make, RegNumber);

            string makeName = "Audi";
            string registrationNumber = "999999";

            Assert.AreEqual(makeName, car.Make);
            Assert.AreEqual(registrationNumber, car.RegistrationNumber);
        }

        [Test]
        public void ConstructorSoftParkShouldWorkCorrect()
        {
            SoftPark softPark = new SoftPark();

            Assert.AreEqual(12, softPark.Parking.Count);
        }

        [Test]
        public void ParkCarShouldThrowExceptionWhenSpotDoesntExists()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("N5", this.car);
            });
        }

        [Test]
        public void ParkCarShouldThrowExceptionWhenSpotIsTaken()
        {
            this.softPark.ParkCar("A1", new Car("BMW", "123"));

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("A1", this.car);
            });
        }

        [Test]
        public void ParkCarShouldThrowExceptionWhenCarIsAlreadyParked()
        {
            this.softPark.ParkCar("A1", this.car);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.softPark.ParkCar("B2", this.car);
            });
        }

        [Test]
        public void ParkCarShouldWorkProperly()
        {
            string message = $"Car:{car.RegistrationNumber} parked successfully!";

            Assert.AreEqual(message, this.softPark.ParkCar("A1", this.car));
        }

        [Test]
        public void RemoveCarShouldThrowExceptionWhenSpotDoesntExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("N5", this.car);
            });
        }

        [Test]
        public void RemoveCarShouldThrowExceptionWhenInThisSpotThatCarDoesntExist()
        {
            this.softPark.ParkCar("A1", this.car);

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("A1", new Car("Mercedes", "4645"));
            });
        }

        [Test]
        public void RemoveCarShouldWorkCorrectly()
        {
            this.softPark.ParkCar("A1", this.car);

            string message = $"Remove car:{car.RegistrationNumber} successfully!";

            Assert.AreEqual(message, this.softPark.RemoveCar("A1", this.car));
        }
    }
}