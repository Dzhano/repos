using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
    }

    [Test]
    [TestCase(-1)]
    [TestCase(0)]
    public void ThrowingException_When_AttackingWithABrokenAxe(int durability)
    {
        Axe axe = new Axe(10, durability);
        Dummy dummy = new Dummy(10, 10);

        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}