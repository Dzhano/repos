using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(10, 10);
    }
    
    [Test]
    public void LosesHealthAfterAttack_IfNotCilled()
    {
        dummy.TakeAttack(2);
        Assert.That(dummy.Health, Is.EqualTo(8), "Dummys health doesn't changes after taking attack.");
    }

    [Test]
    public void GivesXPIfDead()
    {
        dummy.TakeAttack(10);
        Assert.That(dummy.GiveExperience(),
            Is.EqualTo(10),
            "Dead dummy doesn't give experience.");
    }

    [Test]
    public void LosesHealthAfterAttack_IfAlreadyCilled()
    {
        dummy.TakeAttack(10);
        Assert.That(() => dummy.TakeAttack(1),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."), 
            "Dead dummys health changes after taking attack.");
    }

    [Test]
    public void GiveException_IfGivesXPIfAlive()
    {
        dummy.TakeAttack(9);
        Assert.That(() => dummy.GiveExperience(), 
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."),
            "Living dummy gives experience.");
    }
}
