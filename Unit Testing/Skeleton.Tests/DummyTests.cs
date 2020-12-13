using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int health = 10;
    private const int experience = 10;
    private const int attackPoints = 10;
    private Dummy dummy;

    [SetUp]
    public void TestUnit()
    {
        this.dummy = new Dummy(health, experience);
    }

    [Test]
    public void DummyShouldLoseHealthAfterEachAttack()
    {
        dummy.TakeAttack(5);

        Assert.IsTrue(this.dummy.Health < health, "Dummy doesn't lose health after attack!");
    }

    [Test]
    public void DeadDummyShouldThrowExceptionWhenAttacked()
    {
        dummy.TakeAttack(6);
        dummy.TakeAttack(6);

        Assert.That(() => dummy.TakeAttack(6), Throws.Exception.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyShouldGiveExperience()
    {
        dummy.TakeAttack(attackPoints);

        Assert.AreEqual(10, dummy.GiveExperience(), "Dead dummy doesn't give experience");
    }

    [Test]
    public void AliveDummyCantGiveExperience()
    {
        Assert.That(() => dummy.GiveExperience(), Throws.Exception.With.Message.EqualTo("Target is not dead."));
    }
}
