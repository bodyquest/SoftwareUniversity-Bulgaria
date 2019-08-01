using EXRC_Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        //ADD() throws exception
        //ADD() if valid number
        //REMOVE() throws exception
        // REMOVE() if valid number
        // Validate() test with contstructor
        // validate get and set for DatabaseElements

        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6);
        }

        [Test]
        public void AddMethod_ShouldThrow_ExceptionWithInvalidParameter()
        {
            for (int i = 0; i < 10; i++)
            {
                this.database.Add(45);
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Add(458));
        }

        [Test]
        public void AddMethod_ShouldWork_Correctly()
        {
            for (int i = 0; i < 5; i++)
            {
                this.database.Add(45);
            }

            Assert.That(11, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void RemoveMethod_ShouldThrow_ExceptionWithEmptyDatabase()
        {
            for (int i = 0; i < 6; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void RemoveMethod_ShouldRemove_OneElement()
        {
            this.database.Remove();

            Assert.That(5, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void Constructor_ShouldInitialize_Correctly()
        {
            //Arrange
            this.database = new Database(1, 2, 3, 4);

            //Assert
            Assert. That(4, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        [TestCase()]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        public void Constructor_ShouldThrow_Exception(params int[] collection)
        {
            Assert.Throws<InvalidOperationException>(() => this.database = new Database(collection));
        }

        [Test]
        public void PropertyDatabaseElements_ShouldSet_Correctly()
        {
            //Arrange
            var collection = new List<int>() { 1, 2, 3, 4, 5, 6};
            
            //Assert
            CollectionAssert.AreEqual(collection, this.database.DatabaseElements);
        }

        [Test]
        public void PropertyDatabaseElements_ShouldGet_Correctly()
        {
            //Arrange
            int expectedCount = 6;

            //Assert
            Assert.That(expectedCount, Is.EqualTo(this.database.DatabaseElements.Length));
        }

    }
}