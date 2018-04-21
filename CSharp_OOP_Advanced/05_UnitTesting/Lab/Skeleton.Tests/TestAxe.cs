using NUnit.Framework;

namespace Skeleton.Tests
{
    public class TestAxe
    {
        private const int AxeAttack = 2;

        private const int AxeDurability = 2;

        private const int DummyHealth = 20;

        private const int DummyXp = 20;

        private Axe axe;

        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyXp);
        }

        [Test]
        public void AxeLosesDurabilyAfterAttack()
        {
            //// Act
            axe.Attack(dummy);

            // Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(1),
                "Axe Durability doesn't change after attack");
        }
    }
}