using Moq;
using NUnit.Framework;

[TestFixture()]
public class HeroTests
{
    private const int DummyExperience = 20;
    private const string HeroName = "Gzero";

    [Test]
    public void HeroGainingXPWhenTargetDies()
    {
        //Arrange
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(p => p.GiveExperience()).Returns(DummyExperience);
        fakeTarget.Setup(p => p.IsDead()).Returns(true);
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Hero hero = new Hero(HeroName, fakeWeapon.Object);

        //Act
        hero.Attack(fakeTarget.Object);

        //Assert
        Assert.AreEqual(DummyExperience, hero.Experience);
    }
}