using NUnit.Framework;

public class AxeTests
{
    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        // Arrange
        var axe = new Axe(10, 10);
        var dummy = new Dummy(10, 10);

        // Act
        axe.Attack(dummy);

        // Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
    }
}