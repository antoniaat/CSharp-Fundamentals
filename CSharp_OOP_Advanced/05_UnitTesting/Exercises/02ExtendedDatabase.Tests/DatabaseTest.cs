using System.Linq;
using NUnit.Framework;

namespace _02ExtendedDatabase.Tests
{
    public class DatabaseTest
    {
        public Database Database;

        [SetUp]
        public void TestInit()
        {
            Database = new Database();
        }

        [Test]
        public void AddPersonToDatabase()
        {
            //Arrange
            var person = new Person(281726172, "annnie123");

            //Act
            Database.Add(person);

            //Assert
            Assert.IsTrue(Database.PeopleData.Contains(person));
        }

        [Test]
        public void RemoveLastPersonFromDatabase()
        {
            //Arrange
            Database.Add(new Person(8549854985, "Antonia"));
            Database.Add(new Person(98594859, "pepepe123"));
            Person lastPerson = Database.PeopleData.Last();

            //Act
            Database.Remove();
            
            //Assert
            Assert.AreNotEqual(lastPerson, Database.PeopleData.Last());
        }

        [Test]
        public void FindPersonByUsername()
        {
            //Arrange
            Database.Add(new Person(8549854985, "Antonia"));

            //Act
            Person returnedPerson = Database.FindByUsername("Antonia");
            
            //Assert
            Assert.That(returnedPerson.Username, Is.EqualTo("Antonia"));
        }

        [Test]
        public void FindPersonById()
        {
            //Arrange
            Database.Add(new Person(1234, "aasd123"));

            //Act
            Person returnedPerson = Database.FindById(1234);

            //Assert
            Assert.That(returnedPerson.Id, Is.EqualTo(1234));
        }
    }
}
