namespace Telecom.Tests
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class Tests
    {
        private string make;
        private string model;
        private Dictionary<string, string> phonebook;

        private Phone mobile;

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
        //................................................................................

        [Test]
        public void Constructor_ShouldWork_Correctly()
        {
            //Arrange
            string expectedMake = "Apple";
            string expectedModel = "iPhone";

            this.mobile = new Phone("Apple", "iPhone");

            //Assert
            Assert.AreEqual(expectedMake, this.mobile.Make);
            Assert.AreEqual(expectedModel, this.mobile.Model);
        }

        [Test]
        public void CountSetter_Works_Correctly()
        {
            //Arrange
            int expectedCount = 1;

            this.mobile = new Phone("Apple", "iPhone");

            string name = "Shisho";
            string phone = "555-12345";

            //Act
            this.mobile.AddContact(name, phone);

            //Assert
            Assert.AreEqual(expectedCount, this.mobile.Count);
        }

        [Test]
        public void MakeSetter_ThrowsException_IfMakeIsNullOrEmpty()
        {
            //Assert
            Assert.Throws<ArgumentException>(() => { this.mobile = new Phone("", "iPhone"); });
        }

        [Test]
        public void ModelSetter_ThrowsException_IfMakeIsNullOrEmpty()
        {
            //Assert
            Assert.Throws<ArgumentException>(() => { this.mobile = new Phone("Apple", ""); });
        }

        [Test]
        public void AddContactMethod_ShouldWork_Correctly()
        {
            //Arrange
            this.mobile = new Phone("Apple", "iPhone");

            string name = "Shisho";
            string phone = "555-12345";

            //Act
            this.mobile.AddContact(name, phone);

            //Assert
            Assert.AreEqual(1, this.mobile.Count);
        }

        [Test]
        public void AddContactMethod_ThrowsException_IfNameExistsInPhoneBook()
        {
            //Arrange
            this.mobile = new Phone("Apple", "iPhone");

            string name = "Shisho";
            string phone = "555-11111";

            //Act
            this.mobile.AddContact(name, phone);

            //Assert
            Assert.Throws<InvalidOperationException>(() => { this.mobile.AddContact(name, phone); });
        }

        [Test]
        public void CallMethod_ShouldWork_Correctly()
        {
            //Arrange
            this.mobile = new Phone("Apple", "iPhone");

            string name = "Shisho";
            string phone = "555-11111";
            string expectedResult = $"Calling {name} - {phone}...";

            //Act
            this.mobile.AddContact(name, phone);


            //Assert
            Assert.AreEqual(expectedResult, this.mobile.Call(name));
        }

        [Test]
        public void CallMethod_ThrowsException_IfNameDoesNotExistInPhoneBook()
        {
            //Arrange
            this.mobile = new Phone("Apple", "iPhone");

            string name = "Bakshisho";

            //Assert
            Assert.Throws<InvalidOperationException>(() => { this.mobile.Call(name); });
        }
    }
}