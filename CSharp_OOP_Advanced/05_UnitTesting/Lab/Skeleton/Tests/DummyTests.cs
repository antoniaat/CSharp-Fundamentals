using NUnit.Framework;

public class DummyTests
{
    [Test]
    public void DummyLoosesHealthIfAttacked()
    {
        // Arrange
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        // Act
        axe.Attack(dummy);

        // Assert
        Assert.That(dummy.Health, Is.EqualTo(0),
            "Dummy loses health if attacked.");
    }

    [Test]
    public void DummyLosesHealthAfterAttack()
    {
        // Arrange
        Dummy dummy = new Dummy(20, 10);

        // Act
        dummy.TakeAttack(5);

        // Assert
        Assert.That(dummy.Health, Is.EqualTo(15));
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        // Arrange
        Axe axe = new Axe(1, 1);
        Dummy dummy = new Dummy(10, 10);

        // Act
        axe.Attack(dummy);

        // Assert
        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
    }

    [Test]
    public void DeadDummyCantAttack()
    {
        // Arrange
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        // Act
        axe.Attack(dummy);

        // Assert
        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Dead Dummy can't be attacked."));
    }

    [Test]
    public void DeadDummyCanGiveXp()
    {
        // Arrange
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        // Act
        axe.Attack(dummy);

        // Assert
        if (dummy.IsDead())
        {
            Assert.That(dummy.GiveExperience(), Is.AtLeast(1),
                "Dead dummy can give XP.");
        }
    }

    [Test]
    public void AliveDummyCantGiveXp()
    {
        // Arrange
        var axe = new Axe(10, 10);
        var dummy = new Dummy(10, 10);

        // Act
        axe.Attack(dummy);

        // Assert
        if (!dummy.IsDead())
        {
            Assert.That(dummy.GiveExperience(), Is.EqualTo(0),
                "Dead dummy can give XP.");
        }
    }
}