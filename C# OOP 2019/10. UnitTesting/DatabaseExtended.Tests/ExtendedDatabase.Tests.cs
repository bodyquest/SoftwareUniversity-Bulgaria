using NUnit.Framework;

using System;
using ExtendedDatabase;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        //TODO LIST
        // Validate CTOR (for every child class if any) - this also tests property getters
        //
        // Validate CTOR initialize collection ? (for every child class if any)
        //
        // Validate Properties' setter condtitions and exceptions
        //
        // method test for CORRECT execution
        //
        // method tests for exceptions thrown from the method
        //
        // Validate overriden methods in child classes if different validations there

        //...........................................................................................
        //•	Add
        //    o   If there are already users with this username, InvalidOperationException is thrown.
        //    o If there are already users with this id, InvalidOperationException is thrown.

        //•	Remove

        //•	FindByUsername
        //    o   If no user is present by this username, InvalidOperationException is thrown.
        //    o If username parameter is null, ArgumentNullException is thrown.
        //    o Arguments are all CaseSensitive.

        //•	FindById
        //    o   If no user is present by this id, InvalidOperationException is thrown.
        //    o If negative ids are found, ArgumentOutOfRangeException is thrown.

        private ExtendedDatabase.ExtendedDatabase database;
        private List<Person> collection;

        private Person Shisho;
        private Person Bakshisho;
        private Person BabaVuna;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PersonConstructor_ShouldWork_Correctly()
        {
            //Arrange
            long expectedId = 1;
            string expectedName = "Shisho";

            this.Shisho = new Person(1, "Shisho");

            //Assert
            Assert.AreEqual(expectedId, this.Shisho.Id);
            Assert.AreEqual(expectedName, this.Shisho.UserName);
        }

        [Test]
        public void CountPropertySetter_Works_Correctly()
        {
            //Arrange
            int expectedCount = 1;

            this.Shisho = new Person(1, "Shisho");
            Person[] collection = { this.Shisho };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            //Assert
            Assert.AreEqual(expectedCount, this.database.Count);
        }


        [Test]
        public void Constructor_ShouldWork_Correctly()
        {
            //Arrange
            this.Shisho = new Person(01, "Shisho");
            this.Bakshisho = new Person(02, "Bakshisho");
            this.BabaVuna = new Person(03, "BabaVuna");
            Person[] collection = { this.Shisho, this.Bakshisho, this.BabaVuna};

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            int expectedCount = 3;

            //Assert
            Assert.AreEqual(expectedCount, this.database.Count);
        }


        //ADD METHODS
        [Test]
        public void AddMethod_ShouldWork_Correctly()
        {
            //Arrange
            int expectedCount = 3;

            this.Shisho = new Person(01, "Shisho");
            this.Bakshisho = new Person(02, "Bakshisho");
            this.BabaVuna = new Person(03, "BabaVuna");
            Person[] collection = { this.Shisho, this.Bakshisho };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            //Act
            this.database.Add(this.BabaVuna);

            //Assert
            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void AddMethod_ThrowsException_IFIdExists()
        {
            //Arrange
            this.Shisho = new Person(01, "Shisho");
            this.Bakshisho = new Person(02, "Bakshisho");
            this.BabaVuna = new Person(03, "BabaVuna");
            var desaPoetesa = new Person(03, "DesaPoetesa");

            Person[] collection = { this.Shisho, this.Bakshisho, this.BabaVuna };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(desaPoetesa));
        }

        [Test]
        public void AddMethod_ThrowsException_IFUsernameExists()
        {
            //Arrange
            this.Shisho = new Person(01, "Shisho");
            this.Bakshisho = new Person(02, "Bakshisho");
            this.BabaVuna = new Person(03, "BabaVuna");
            var taxiDriver = new Person(04, "Bakshisho");

            Person[] collection = { this.Shisho, this.Bakshisho, this.BabaVuna };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(taxiDriver));
        }


        [Test]
        public void AddMethod_ThrowsException_IfCountIsMax()
        {
            //Arrange
            this.Shisho = new Person(01, "Shisho");
            this.BabaVuna = new Person(17, "BabaVuna");

            Person[] collection = { this.Shisho };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            //Act
            for (int i = 2; i <= 16; i++)
            {
                var newPerson = new Person(i, $"Person{i}");
                this.database.Add(newPerson);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(this.BabaVuna));
        }

        //ADDRANGE METHOD
        [Test]
        public void AddRangeMethod_ThrowsException_WithMoreThan16People()
        {
            this.collection = new List<Person>();
            for (long i = 1; i <= 17; i++)
            {
                collection.Add(new Person(i, $"Person{i}"));
            }
            Person[] collectionArray = collection.ToArray();

            Assert.Throws<ArgumentException>(() => this.database = new ExtendedDatabase.ExtendedDatabase(collectionArray));
        }


        //REMOVE MOETHODS
        [Test]
        public void RemoveMethod_ShouldWork_Correctly()
        {
            //Arrange
            long expectedCount = 2;

            this.Shisho = new Person(01, "Shisho");
            this.Bakshisho = new Person(02, "Bakshisho");
            this.BabaVuna = new Person(03, "BabaVuna");

            Person[] collection = { this.Shisho, this.Bakshisho, this.BabaVuna };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            //Act
            this.database.Remove();

            //Assert
            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void RemoveMethod_ShouldThrow_Exception_IfDatabaseIsEmpty()
        {
            //Arrange
            this.Shisho = new Person(01, "Shisho");
            this.Bakshisho = new Person(02, "Bakshisho");

            Person[] collection = { this.Shisho, this.Bakshisho };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            //Act
            this.database.Remove();
            this.database.Remove();

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }


        //FINDByUserName METHODS
        [Test]
        public void FindByUsernameMethod_ShouldWork_Correctly()
        {
            //Arrange
            this.Shisho = new Person(01, "Shisho");
            this.BabaVuna = new Person(03, "BabaVuna");

            Person[] collection = { this.Shisho };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            //Act
            var personToFindByUsername = this.database.FindByUsername("Shisho");

            //Assert
            Assert.AreEqual(this.Shisho, personToFindByUsername);
        }

        [Test]
        public void FindByUsernameMethod_ThrowsException_ForNonExistingUser()
        {
            //Arrange
            this.Shisho = new Person(01, "Shisho");
            this.Bakshisho = new Person(02, "Bakshisho");

            Person[] collection = { this.Shisho };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(this.Bakshisho.UserName));
        }

        [Test]
        public void FindByUsernameMethod_ThrowsException_ForNullUsername()
        {
            //Arrange
            this.Shisho = new Person(01, "Shisho");

            Person[] collection = { this.Shisho };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);
            //Assert
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername("")); ;
        }


        //FINDByID METHODS
        [Test]
        public void FindByIdMethod_ShouldWork_Correctly()
        {
            //Arrange
            this.Shisho = new Person(01, "Shisho");
            this.BabaVuna = new Person(03, "BabaVuna");

            Person[] collection = { this.Shisho };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            //Act
            var personToFindById = this.database.FindById(1);

            //Assert
            Assert.AreEqual(this.Shisho, personToFindById);
        }

        [Test]
        public void FindByIdMethod_ThrowsException_ForNonExistingUser()
        {
            //Arrange
            this.Shisho = new Person(01, "Shisho");
            this.BabaVuna = new Person(03, "BabaVuna");

            Person[] collection = { this.Shisho };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(3)); ;
        }

        [Test]
        public void FindByIdMethod_ThrowsException_ForNegativeId()
        {
            //Arrange
            this.Shisho = new Person(01, "Shisho");

            Person[] collection = { this.Shisho };

            this.database = new ExtendedDatabase.ExtendedDatabase(collection);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1));
        }
    }
}