using System;
using NUnit.Framework;

using Database;

namespace Tests
{
    public class DatabaseTests
    {
        // Constructor validation
        // ADD() throws exception
        // ADD() if valid number
        // REMOVE() throws exception
        // REMOVE() if valid number
        // FETCH() works correctly

        private Database.Database database;
        private readonly int[] data = new int[] {1, 2, 3, 4};

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(this.data);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(this.database.Count == 4);
        }

        [Test]
        public void AddMethod_ShouldWork_Correctly()
        {
            //Arrange
            int expectedCount = 5;

            //Act
            this.database.Add(1);

            //Assert
            Assert.That(expectedCount, Is.EqualTo(this.database.Count));
        }

        [Test]
        public void AddMethod_ShouldThrow_Exception_IfCountIsMax()
        {
            //Arrange
            int element = 1;

            //Act
            for (int i = 0; i < 12; i++)
            {
                this.database.Add(i);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(element) );
        }

        [Test]
        public void RemoveMethod_ShouldWork_Correctly()
        {
            //Arrange
            int expectedCount = 3;

            //Act
            this.database.Remove();

            //Assert
            Assert.That(expectedCount, Is.EqualTo(this.database.Count));
        }

        [Test]
        public void RemoveMethod_ShouldThrow_Exception_IfDatabaseIsEmpty()
        {
            //Arrange

            //Act
            this.database.Remove();
            this.database.Remove();
            this.database.Remove();
            this.database.Remove();


            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void FetchMethod_ShouldWork_Correctly()
        {
            //Arrange
            int[] result = this.database.Fetch();

            //Act

            //Assert
            CollectionAssert.AreEqual(this.data, result);
        }
    }
}