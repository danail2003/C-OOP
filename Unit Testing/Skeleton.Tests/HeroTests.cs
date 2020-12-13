using NUnit.Framework;
using Skeleton.Tests;
using Skeleton;
using Moq;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroShouldGainsExperienceWhenTargetDies()
    {
        FakeTarget fakeTarget = new FakeTarget();
        FakeWeapon fakeWeapon = new FakeWeapon();
        Hero hero = new Hero("Hero", fakeWeapon);

        hero.Attack(fakeTarget);

        Assert.AreEqual(fakeTarget.GiveExperience(), hero.Experience);
    }

    [Test]
    public void HeroShouldGainsExperienceWhenTargetDiesMoq()
    {
        Mock<ITarget> target = new Mock<ITarget>();
        target.Setup(x => x.Health).Returns(0);
        target.Setup(x => x.IsDead()).Returns(true);
        target.Setup(x => x.GiveExperience()).Returns(10);

        Mock<IWeapon> weapon = new Mock<IWeapon>();
        Hero hero = new Hero("Hero", weapon.Object);

        hero.Attack(target.Object);

        Assert.AreEqual(10, hero.Experience);
    }
}