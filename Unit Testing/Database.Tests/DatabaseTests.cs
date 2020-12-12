using NUnit.Framework;
using System;

namespace Tests
{
    using Database;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        [SetUp]
        public void TestUnit()
        {
            this.database = new Database(data);
        }

        [Test]
        public void CapacityShouldBe16Integers()
        {
            this.database = new Database(data);

            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [TestCase(new int[] { 1, 2, 3})]
        [TestCase(new int[] { })]
        public void ConstructorShouldWorkCorectly(int[] data)
        {
            this.database = new Database(data);

            int count = data.Length;
            int actualCount = this.database.Count;

            Assert.AreEqual(count, actualCount);
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenCollectionIsBigger()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database(array);
            });
        }

        [Test]
        public void EmptyArrayShouldThrowExceptionWhenWeTryRemoving()
        {
            this.database = new Database();

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            int[] array = new int[] { 1, 2 };
            this.database = new Database(array);
            int count = 3;
            this.database.Add(3);

            Assert.AreEqual(database.Count, count);
        }

        [Test]
        public void RemoveMethodShouldRemoveLastElement()
        {
            this.database = new Database(data);
            this.database.Remove();
            int count = 15;

            Assert.AreEqual(this.database.Count, count);
        }

        [TestCase(new int[] { 1, 2, 3})]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void ArrayShouldReturnArray(int[] expectedArray)
        {
            this.database = new Database(expectedArray);
            int[] actualData = this.database.Fetch();

            CollectionAssert.AreEqual(expectedArray, actualData);
        }

        [Test]
        public void FetchMethodShouldReturnCorrectLength()
        {
            this.database = new Database(data);
            int count = data.Length;

            Assert.AreEqual(database.Count, count);
        }
    }
}