using Moq;
using NUnit.Framework;
using Skeleton.FakeInterfaces;
using Skeleton.Tests.Fakes;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroGainsExperienceAfterAttackIfTargetDies_USINGfakes()
    {
        ITarget fakeTarget = new FakeTarget();
        IWeapon fakeWeapon = new FakeWeapon();
        Hero hero = new Hero("Dzhano", fakeWeapon);

        hero.Attack(fakeTarget);

        Assert.That(hero.Experience, Is.EqualTo(fakeTarget.GiveExperience()), 
            "Hero doesn't earn experience when he/she kills target.");
    }

    [Test]
    public void HeroGainsExperienceAfterAttackIfTargetDies_USINGmoq()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
        fakeTarget.Setup(p => p.Health).Returns(0);
        fakeTarget.Setup(p => p.IsDead()).Returns(true);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Hero hero = new Hero("Dzhano", fakeWeapon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.That(hero.Experience, Is.EqualTo(fakeTarget.Object.GiveExperience()),
            "Hero doesn't earn experience when he/she kills target.");
    }
}