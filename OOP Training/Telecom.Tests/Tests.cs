namespace Telecom.Tests
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;
    using Telecom;

    [TestFixture]
    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void UnitTest()
        {
            this.phone = new Phone("Samsung", "S10");
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            List<Phone> phones = new List<Phone>();

            Phone phone = new Phone("Apple", "10");
            phones.Add(phone);

            Assert.AreEqual(1, phones.Count);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            string make = "Samsung";
            string model = "S10";

            Assert.AreEqual(make, this.phone.Make);
            Assert.AreEqual(model, this.phone.Model);
        }

        [Test]
        public void AddMethodShouldInitializeCorrectCount()
        {
            int count = 1;
            this.phone.AddContact("Gosho", "088956215");

            Assert.AreEqual(count, this.phone.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenNameExists()
        {
            this.phone.AddContact("Gosho", "08952355995");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.AddContact("Gosho", "0895233");
            });
        }

        [Test]
        public void CallMethodShouldThrowExceptionWhenPersonDoesntExist()
        {
            this.phone.AddContact("Gosho", "089563214");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.Call("Pesho");
            });
        }

        [Test]
        public void CallMethodShouldWorkProperly()
        {
            string name = "Gosho";
            string number = "08953456";

            this.phone.AddContact(name, number);
            string message = $"Calling {name} - {number}...";

            Assert.AreEqual(this.phone.Call("Gosho"), message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void MakePropertyShouldThrowExceptionWhenValueIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(make, "S10");
            });
        }

        [TestCase(null)]
        [TestCase("")]
        public void ModelPropertyShouldThrowExceptionWhenValueIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone("Samsung", model);
            });
        }
    }
}