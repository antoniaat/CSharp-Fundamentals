using Moq;
using NUnit.Framework;
using Skeleton.Interfaces;

namespace Skeleton.Tests
{
    public class HeroTests
    {
        private const int DummyExperience = 20;
        private const string HeroName = "Superman";

        [Test]
        public void HeroGainingXpWhenTargetDies()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(f => f.GiveExperience()).Returns(DummyExperience);
            fakeTarget.Setup(f => f.IsDead()).Returns(true);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            Hero hero = new Hero(HeroName, fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);

            Assert.AreEqual(DummyExperience, hero.Experience);
        }
    }
}