using Service.Models.Contracts;
using Service.Models.Devices;
using Service.Models.Parts;

using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Service.Tests
{
    public class DeviceTests
    {
        private readonly List<IPart> parts;
        private Device device;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShouldInitializeCollection_Correctly()
        {
            Phone iPhone = new Phone("X");

            Assert.IsNotNull(iPhone.Parts);
        }

        [Test]
        public void Constructor_ShouldWork_Correctly()
        {
            string expectedMake = "X";
            Phone iPhone = new Phone("X");

            Assert.AreEqual(expectedMake, iPhone.Make);
        }

        [Test]
        public void MakeSetter_ShouldThrow_ExceptionIfMakeIsNull()
        {
            string expectedMake = null;

            Assert.Throws<ArgumentException>(() => { Phone iPhone = new Phone(expectedMake);});
        }


        //ADD TESTS
        [Test]
        public void AddPartMethod_ShouldAdd_DevicePartSuccessfully()
        {
            //Arrange
            PhonePart itemPart = new PhonePart("Battery", 50m, false);
            Phone iPhone = new Phone("X");

            //Act
            iPhone.AddPart(itemPart);

            //Assert
            Assert.That(1, Is.EqualTo(iPhone.Parts.Count));
            Assert.That(iPhone.Parts, Has.Member(itemPart));
        }

        [Test]
        public void AddPartMethod_ShouldThrow_Exception_WhenPartType_IsNotForThisDeviceType()
        {
            //Arrange
            PCPart itemPart = new PCPart("RAM", 20m, false);
            Phone iPhone = new Phone("X");

            //Assert
            Assert.Throws<InvalidOperationException>(() => iPhone.AddPart(itemPart));
        }

        [Test]
        public void AddPartMethod_ShouldThrow_Exception_WhenPartType_AlreadyExists()
        {
            //Arrange
            PhonePart itemPart = new PhonePart("Display", 50m, false);
            Phone iPhone = new Phone("X");

            //Act
            iPhone.AddPart(itemPart);

            //Assert
            Assert.Throws<InvalidOperationException>(() => iPhone.AddPart(itemPart));
        }


        //REMOVE TESTS
        [Test]
        public void RemoveMethod_ShouldRemove_PartSuccessfully()
        {
            //Arrange
            PhonePart itemPart = new PhonePart("Display", 50m, false);
            PhonePart anotherItemPart = new PhonePart("Button", 10m, true);
            Phone iPhone = new Phone("X");

            //Act
            iPhone.AddPart(itemPart);
            iPhone.AddPart(anotherItemPart);
            iPhone.RemovePart(itemPart.Name);


            //Assert
            Assert.AreEqual(1, iPhone.Parts.Count);
            Assert.That(iPhone.Parts, !Contains.Item(itemPart));
            Assert.That(iPhone.Parts, Contains.Item(anotherItemPart));

        }

        [Test]
        public void RemoveMethod_ShouldThrow_ExceptionIfPartNameIsNullOrEmpty()
        {
            //Arrange
            PhonePart itemPart = new PhonePart("Display", 50m, false);
            Phone iPhone = new Phone("X");

            //Act
            iPhone.AddPart(itemPart);

            //Assert
            Assert.Throws<ArgumentException>(() => iPhone.RemovePart(null));
        }

        [Test]
        public void RemoveMethod_ShouldThrow_ExceptionIfPartDoesNotExist()
        {
            //Arrange
            PhonePart itemPart = new PhonePart("Display", 50m, false);
            PhonePart itemToRemove = new PhonePart("Camera Lens", 100m, false);
            Phone iPhone = new Phone("X");

            //Act
            iPhone.AddPart(itemPart);

            //Assert
            Assert.Throws<InvalidOperationException>(() => iPhone.RemovePart(itemToRemove.Name));
        }


        //REPAIR TESTS
        [Test]
        public void RepairPartMethod_ShouldRepair_DevicePartSuccessfully()
        {
            //Arrange
            PhonePart itemPart = new PhonePart("Battery", 50m, true);
            Phone iPhone = new Phone("X");

            //Act
            iPhone.AddPart(itemPart);
            iPhone.RepairPart(itemPart.Name);

            //Assert
            Assert.AreEqual(itemPart.IsBroken, false);
        }

        [Test]
        public void RepairMethod_ShouldThrow_ExceptionIfPartNameIsNullOrEmpty()
        {
            //Arrange
            Phone iPhone = new Phone("X");

            //Act
            PhonePart itemPart = new PhonePart("Battery", 50m, false);
            iPhone.AddPart(itemPart);

            //Assert
            Assert.Throws<ArgumentException>(() => iPhone.RemovePart(""));
        }


        [Test]
        public void RepairMethod_ShouldThrow_ExceptionIfPartDoesNotExist()
        {
            //Arrange
            PhonePart itemPart = new PhonePart("Display", 50m, false);
            Phone iPhone = new Phone("X");

            //Assert
            Assert.Throws<InvalidOperationException>(() => iPhone.RepairPart(itemPart.Name));
        }


        [Test]
        public void RepairPartMethod_ShouldThrow_Exception_WhenPartType_IsNotNotBroken()
        {
            //Arrange
            PhonePart itemPart = new PhonePart("Chip", 20m, false);
            Phone iPhone = new Phone("X");

            //Act
            iPhone.AddPart(itemPart);

            //Assert
            Assert.Throws<InvalidOperationException>(() => iPhone.RepairPart(itemPart.Name));
        }


    }
}
