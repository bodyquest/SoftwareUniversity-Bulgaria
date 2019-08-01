using System;
using NUnit.Framework;
using EXRC_DatabaseExtended;

namespace Tests
{
    [TestFixture]
    public class DatabaseExtendedTests
    {
        // CTOR initializes collection - OK

        // add person
        //      - if collection is full
        //      - if username already exists
        //      - if id already exists
        //      - if added successfully - OK

        // remove person

        // find by username
        //      - if username is null
        //      - if no such user there
        //      - if found user is as expected - OK

        // find by id
        //      - if id is negative
        //      - if no such user there
        //      - if found user is as expected - OK

        private Person[] collection;
        private DatabaseExtended database;

        private Person Shisho;
        private Person Bakshisho;
        private Person BabaVuna;

        [SetUp]
        public void SetUp()
        {
            Shisho = new Person("Shisho", 01);
            Bakshisho = new Person("Bakshisho", 02);
            BabaVuna = new Person("BabaVuna", 03);
            
        }

        [Test]
        public void Constructor_ShouldInitialize_CollectionSuccessfully()
        {
            //Arrange
            this.collection = new Person[] { Shisho, Bakshisho, BabaVuna };
            var database = new DatabaseExtended(collection);

            //Act
            var actual = database.Fetch();

            //Assert
            Assert.AreEqual(actual, this.collection);
        }

        [Test]
        public void FindByUsernameMethod_ShouldReturn_StringWithFoundUser()
        {
            this.collection = new Person[] { Shisho, Bakshisho, BabaVuna };
            var database = new DatabaseExtended(collection);

            var expected = database.FindByUsername("Shisho");
            var actual = "Found Shisho username";

            Assert.AreEqual(expected, actual, "Username returned is not as expected");
        }

        [Test]
        public void FindByIdMethod_ShouldReturn_StringWithFoundId()
        {
            this.collection = new Person[] { Shisho, Bakshisho, BabaVuna };
            var database = new DatabaseExtended(collection);

            var expected = database.FindById(02);
            var actual = $"Found user with {02} id";

            Assert.AreEqual(expected, actual, "Id returned is not as expected");
        }

        [Test]
        public void AddMethod_ShouldAddPerson_Successfully()
        {
            //Arrange
            this.collection = new Person[] { Shisho, Bakshisho, BabaVuna };
            var database = new DatabaseExtended(collection);
            var newPerson = new Person("Kanalin Colov", 04);

            //Act
            database.Add(newPerson);
            var actual = database.Fetch();
            var expected = new Person[] { Shisho, Bakshisho, BabaVuna, newPerson };

            Assert.That(expected, Is.EqualTo(actual), "Database elements count is not as expected");
        }
    }
}