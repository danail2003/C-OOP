namespace Robots.Tests
{
    using System;
    using Robots;
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            this.robot = new Robot("Gosho", 10);
            this.robotManager = new RobotManager(2);
        }

        [Test]
        public void ConstructorShouldInitializeCorrectRobot()
        {
            Robot robot = new Robot("Ivan", 5);

            Assert.AreEqual("Ivan", robot.Name);
            Assert.AreEqual(5, robot.MaximumBattery);
        }

        [Test]
        public void SettersShouldWorkCorrect()
        {
            this.robot.Name = "Ivan";
            this.robot.Battery = 3;

            Assert.AreEqual("Ivan", this.robot.Name);
            Assert.AreEqual(3, this.robot.Battery);
        }

        [Test]
        public void RobotManagerConstructorShouldInitializeCorrectValue()
        {
            RobotManager robotManager = new RobotManager(1);

            Assert.AreEqual(1, robotManager.Capacity);
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenValueIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(-5);
            });
        }

        [Test]
        public void AddShouldThrowExceptionWhenRobotExists()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Add(new Robot("Gosho", 10));
            });
        }

        [Test]
        public void AddShouldThrowExceptionWhenCapacityIsReached()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Add(new Robot("Ivan", 5));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Add(new Robot("Mimi", 4));
            });
        }

        [Test]
        public void AddShoudlWorkProperly()
        {
            this.robotManager.Add(this.robot);

            Assert.AreEqual(1, this.robotManager.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenRobotDoesntExist()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Remove("Mimi");
            });
        }

        [Test]
        public void RemoveShouldWorkProperly()
        {
            this.robotManager.Add(this.robot);

            this.robotManager.Remove(this.robot.Name);

            Assert.AreEqual(0, this.robotManager.Count);
        }

        [Test]
        public void WorkShouldThrowExceptionWhenRobotDoesntExists()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Work("Mimi", "someJob", 4);
            });
        }

        [Test]
        public void WorkShouldThrowExceptionWhenRobotDoesntHaveEnoughBattery()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Work("Gosho", "someJob", 11);
            });
        }

        [Test]
        public void WorkMethodShouldWorkCorrectly()
        {
            this.robotManager.Add(this.robot);

            this.robotManager.Work("Gosho", "job", 5);

            Assert.AreEqual(5, this.robot.Battery);
        }

        [Test]
        public void ChargeShouldThrowExceptionWhenRobotDoesntExist()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Charge("Mimi");
            });
        }

        [Test]
        public void ChargeShouldWorkCorrect()
        {
            this.robotManager.Add(this.robot);

            this.robotManager.Work("Gosho", "job", 5);
            this.robotManager.Charge("Gosho");

            Assert.AreEqual(10, this.robot.Battery);
        }
    }
}
