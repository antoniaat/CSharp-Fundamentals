using System.Linq;
using NUnit.Framework;

public class DatabaseTest
{
    public Database Database;

    [SetUp]
    public void TestInit()
    {
        Database = new Database(1, 2, 3, 4);
    }

    [Test]
    public void CreateDatabase()
    {
        // Arrange
        int[] testingArray = new int[16];

        // Act
        Database database = new Database { Data = testingArray };

        // Assert
        Assert.AreEqual(16, database.Data.Length);
    }

    [Test]
    public void AddElements()
    {
        // Act
        Database.Add(1254);

        // Assert
        Assert.IsTrue(Database.Data.Contains(1254));
    }

    [Test]
    public void RemoveLastElement()
    {
        // Arrange
        //int lastElementInCollection = Database.Data[Database.Data.Length - 1];
        int lastElementInDatabase = Database.Data.Last(x => x != 0);

        // Act
        Database.Remove();

        // Assert 
        Assert.AreNotEqual(Database.Data.Last(x => x != 0), lastElementInDatabase);
    }
}