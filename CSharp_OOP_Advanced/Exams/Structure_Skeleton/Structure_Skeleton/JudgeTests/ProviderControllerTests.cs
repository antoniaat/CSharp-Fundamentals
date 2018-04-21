using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ProviderControllerTests
{
    private EnergyRepository energyRepository;

    private ProviderController providerController;

    private List<string> provider;

    private List<string> secondProvider;

    [SetUp]
    public void SetUpProviderController()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
        provider = new List<string> { "Solar", "1", "100" };
        secondProvider = new List<string> { "Solar", "2", "100" };
    }

    [Test]
    public void ProducesCorrectAmountOfEnergy()
    {
        //Act
        this.providerController.Register(provider);
        this.providerController.Register(secondProvider);

        for (int index = 0; index < 3; index++)
        {
            this.providerController.Produce();
        }

        // Assert
        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(600));
    }

    [Test]
    public void ProviderIsDeleted()
    {
        // Arrange
        provider = new List<string> { "Pressure", "1", "100" };

        //Act
        this.providerController.Register(provider);

        for (int index = 0; index < 8; index++)
        {
            providerController.Produce();
        }

        // Assert
        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }

    [Test]
    public void ProvidersGetRepaired()
    {
        //Act
        this.providerController.Register(provider);
        this.providerController.Repair(100);

        // Assert
        Assert.That(this.providerController.Entities.First().Durability, Is.EqualTo(1600));
    }
}
