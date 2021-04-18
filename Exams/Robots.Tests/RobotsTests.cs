namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            this.robot = new Robot("Gosho", 15);
            this.robotManager = new RobotManager(10);
        }

        [Test]
        public void RobotShouldReturnCorrectValues()
        {
            Assert.AreEqual(this.robot.Name, "Gosho");
            Assert.AreEqual(this.robot.Battery, 15);
            Assert.AreEqual(this.robot.MaximumBattery, 15);
        }

        [Test]
        public void RobotManagerConstructorMustWorkCorrectly()
        {
            Assert.AreEqual(this.robotManager.Capacity, 10);
        }

        [Test]
        public void RobotManagerCapacityMustThrowExceptionIfValueIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager manager = new RobotManager(-1);
            });
        }

        [Test]
        public void CountMustWorkCorrectly()
        {
            this.robotManager.Add(this.robot);
            Assert.AreEqual(this.robotManager.Count, 1);
        }

        [Test]
        public void AddMustThrowExceptionWhenRobotExists()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Add(this.robot);
            });
        }

        [Test]
        public void AddMustThrowExceptionWhenCapacityIsExceeded()
        {
            RobotManager robotManager = new RobotManager(1);

            robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("Pesho", 5));
            });
        }

        [Test]
        public void RemoveMustWorkCorrectly()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Remove(this.robot.Name);

            Assert.AreEqual(this.robotManager.Count, 0);
        }

        [Test]
        public void RemoveMustThrowExceptionWhenNameDoesntExist()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Remove("Ivan");
            });
        }

        [Test]
        public void WorkMustThrowExceptionWhenNameDoesntExist()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Work("Ivan", "sda", 1);
            });
        }

        [Test]
        public void WorkMustThrowExceptionWhenBatteryUsageIsBiggerThanBatteryCapacity()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Work(this.robot.Name, "das", 20);
            });
        }

        [Test]
        public void WorkMustWorkCorrectly()
        {
            this.robotManager.Add(this.robot);

            this.robotManager.Work(this.robot.Name, "dsad", 10);

            Assert.AreEqual(this.robot.Battery, 5);
        }

        [Test]
        public void ChargeMustThrowExceptionWhenNameDoesntExist()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Charge("Ivan");
            });
        }

        [Test]
        public void ChargeMustWorkCorrectly()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Work(this.robot.Name, "dsa", 5);
            this.robotManager.Charge(this.robot.Name);

            Assert.AreEqual(this.robot.Battery, 15);
        }
    }
}
