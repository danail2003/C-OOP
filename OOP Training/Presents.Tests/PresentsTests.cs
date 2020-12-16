namespace Presents.Tests
{
    using System;
    using NUnit.Framework;
    using Presents;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [SetUp]
        public void UnitTest()
        {
            this.present = new Present("Car", 2.5);
            this.bag = new Bag();
        }

        [Test]
        public void ConstructorShouldInitializeCorrectPresent()
        {
            Present present = new Present("Doll", 2);

            string presentName = "Doll";
            double presentMagic = 2;

            Assert.AreEqual(presentName, present.Name);
            Assert.AreEqual(presentMagic, present.Magic);
        }

        [Test]
        public void PresentSettersShouldWorkCorrectly()
        {
            this.present.Name = "Doll";
            this.present.Magic = 3;

            Assert.AreEqual(this.present.Name, "Doll");
            Assert.AreEqual(this.present.Magic, 3);
        }

        [Test]
        public void CreateShouldThrowExceptionWhenPresentIsNull()
        {
            Present present = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.bag.Create(present);
            });
        }

        [Test]
        public void CreateShouldThrowExceptionWhenPresentExists()
        {
            this.bag.Create(this.present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.bag.Create(this.present);
            });
        }

        [Test]
        public void CreateShouldWorkProperly()
        {
            string message = $"Successfully added present {this.present.Name}.";

            Assert.AreEqual(message, this.bag.Create(this.present));
        }

        [Test]
        public void RemoveShouldReturnTrueIfPresentExist()
        {
            this.bag.Create(this.present);

            Assert.IsTrue(this.bag.Remove(this.present));
        }

        [Test]
        public void RemoveShouldReturnFalseIfPresentDoesntExist()
        {
            Assert.IsFalse(this.bag.Remove(this.present));
        }

        [Test]
        public void GetPresentWithLeastMagicShouldWorkProperly()
        {
            Present secondPresent = new Present("Doll", 3);
            Present thirdPresent = new Present("Soldier", 5);
            Present fourthPresent = new Present("Book", 1);

            this.bag.Create(this.present);
            this.bag.Create(secondPresent);
            this.bag.Create(thirdPresent);
            this.bag.Create(fourthPresent);

            Assert.AreEqual(fourthPresent, this.bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void GetPresentShouldReturnCorrectPresent()
        {
            Present secondPresent = new Present("Doll", 5);
            Present thirdPresent = new Present("Soldier", 8);

            this.bag.Create(this.present);
            this.bag.Create(secondPresent);
            this.bag.Create(thirdPresent);

            Assert.AreEqual(thirdPresent, this.bag.GetPresent("Soldier"));
        }

        [Test]
        public void GetPresentShouldWorkProperly()
        {
            Present secondPresent = new Present("Soldier", 5);
            Present thirdPresent = new Present("Book", 8);

            this.bag.Create(this.present);
            this.bag.Create(secondPresent);
            this.bag.Create(thirdPresent);

            Assert.AreEqual(3, this.bag.GetPresents().Count);
        }
    }
}
