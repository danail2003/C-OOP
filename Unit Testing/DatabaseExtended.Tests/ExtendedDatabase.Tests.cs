using NUnit.Framework;
using System;

namespace Tests
{
    using ExtendedDatabase;

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private Person firstPerson;
        private Person secondPerson;

        [SetUp]
        public void Setup()
        {
            this.database = new ExtendedDatabase();
            this.firstPerson = new Person(1, "Gosho");
            this.secondPerson = new Person(2, "Pesho");
        }

        [Test]
        public void ConstructorShouldInitializePersonCorectly()
        {
            Person person = new Person(123, "Gosho");
            Person secondPerson = new Person(456, "Pesho");
            var people = new Person[] { person, secondPerson };
            int count = 2;

            Assert.AreEqual(people.Length, count);
        }

        [Test]
        public void ConstructorShouldInitializeCorrectPerson()
        {
            Person person = new Person(1, "Gosho");
            Person expected = person;

            Assert.That(person, Is.EqualTo(expected));
        }

        [Test]
        public void AddRangeMethodShouldThrowExceptionWhenCollectionIsBiggerThan16()
        {
            Person[] people = new Person[17];

            Assert.Throws<ArgumentException>(() =>
            {
                this.database = new ExtendedDatabase(people);
            });
        }

        [Test]
        public void AddRangeMethodShouldWorkProperly()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            this.database = new ExtendedDatabase(people);

            Assert.AreEqual(people.Length, this.database.Count);
        }

        [TestCase(16)]
        public void AddMethodShouldThrowExceptionWhenArrayCountIs16(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Gosho" + i);
            }

            this.database = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(85, "Pesho"));
            });
        }

        [TestCase(4)]
        [TestCase(15)]
        [TestCase(0)]
        public void AddMethodShouldWorkCorrectlyWhenCountIsLessThan16(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Gosho" + i);
                this.database.Add(people[i]);
            }

            this.database = new ExtendedDatabase(people);

            Assert.AreEqual(count, database.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenNameIsExisting()
        {
            this.database.Add(new Person(1, "Gosho"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(2, "Gosho"));
            });
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenIdIsExisiting()
        {
            this.database.Add(new Person(1, "Gosho"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(1, "Pesho"));
            });
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenCollectionIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            Person[] people = new Person[11];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Gosho" + i);
            }

            this.database = new ExtendedDatabase(people);
            this.database.Remove();

            int count = 10;

            Assert.AreEqual(count, database.Count);
        }

        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameShouldThrowExceptionWhenValueIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.database.FindByUsername(name);
            });
        }

        [TestCase("Gosho")]
        [TestCase("Pesho")]
        public void FindByUsernameMethodShouldThrowExceptionWhenNameDoesntExist(string name)
        {
            this.database.Add(secondPerson);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindByUsername("Ivan");
            });
        }

        [Test]
        public void FindByUsernameMethodShouldWorkCorrectly()
        {
            this.database.Add(firstPerson);
            this.database.Add(secondPerson);

            Assert.AreEqual(this.database.FindByUsername("Gosho"), firstPerson);
        }

        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-23545)]
        public void FindByIdMethodShouldThrowExceptionWhenValueIsNegative(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.database.FindById(id);
            });
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionWhenIdDoesntExist()
        {
            this.database.Add(this.firstPerson);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindById(2);
            });
        }

        [Test]
        public void FindByIdMethodShouldWorkProperly()
        {
            this.database.Add(this.firstPerson);
            this.database.Add(this.secondPerson);

            Assert.AreEqual(this.secondPerson, this.database.FindById(2));
        }
    }
}