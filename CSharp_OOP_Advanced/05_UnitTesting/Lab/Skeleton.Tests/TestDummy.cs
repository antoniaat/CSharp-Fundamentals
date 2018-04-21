using NUnit.Framework;

namespace Skeleton.Tests
{
    public class TestDummy
    {
        private const int AxeAttack = 2;

        private const int AxeDurability = 2;

        private const int DummyHealth = 20;

        private const int DummyXp = 20;

        private const int ExpectedHealthAfterAttack = 18;

        private Axe axe;

        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability); // (2, 2)
            this.dummy = new Dummy(DummyHealth, DummyXp); // (20,20)
        }

        [Test]
        public void DummyTakesDamageAfterAttack()
        {
            // Act
            dummy.TakeAttack(axe.AttackPoints);

            // Assert
            Assert.That(dummy.Health, 
                Is.EqualTo(ExpectedHealthAfterAttack));
        }

        [Test]
        public void BrokenAxeCantAttack()
        {
            // Act
            axe.Attack(dummy);
            axe.Attack(dummy);

            // Assert
            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Axe is broken."));
        }

        [Test]
        public void DeadDummyCantAttack()
        {
            // Act
            dummy.TakeAttack(20);

            // Assert
            Assert.That(() => dummy.TakeAttack(axe.AttackPoints),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXp()
        {
            // Act
            dummy.TakeAttack(20);

            // Assert
            Assert.That(dummy.GiveExperience(), Is.EqualTo(DummyXp),
                "Dead dummy can give XP.");
        }

        [Test]
        public void AliveDummyCantGiveXp()
        {
            // Assert
            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Target is not dead."));
        }
    }
}