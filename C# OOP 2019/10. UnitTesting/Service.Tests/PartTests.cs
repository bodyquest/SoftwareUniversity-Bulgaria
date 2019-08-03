using System;
using NUnit.Framework;

using Service.Models.Parts;

namespace Tests
{
    [TestFixture]
    public class PartTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShouldWork_Properly()
        {
            string name = "Display";
            decimal cost = 10m;
            bool isBroken = true;

            PhonePart itemPart = new PhonePart(name, cost, isBroken);

            Assert.AreEqual(name, itemPart.Name);
            Assert.AreEqual(13, itemPart.Cost);
            Assert.AreEqual(isBroken, itemPart.IsBroken);
        }


        [Test]
        public void Constructor_ShouldWork_ProperlyWithTwoParams()
        {
            //Arrange
            var laptopPart = new LaptopPart("LaptopPartName", 10);
            var pCPart = new PCPart("PCPartName", 10);
            var phonePart = new PhonePart("PhonePartName", 10);

            //Assert
            Assert.AreEqual("LaptopPartName", laptopPart.Name);
            Assert.AreEqual(15, laptopPart.Cost);
            Assert.AreEqual(false, laptopPart.IsBroken);

            Assert.AreEqual("PCPartName", pCPart.Name);
            Assert.AreEqual(12, pCPart.Cost);
            Assert.AreEqual(false, pCPart.IsBroken);

            Assert.AreEqual("PhonePartName", phonePart.Name);
            Assert.AreEqual(13, phonePart.Cost);
            Assert.AreEqual(false, phonePart.IsBroken);
        }


        [Test]
        public void Constructor_ShouldWork_ProperlyWithThreeParams()
        {
            //Arrange
            var laptopPart = new LaptopPart("LaptopPartName", 20, true);
            var pCPart = new PCPart("PCPartName", 20, true);
            var phonePart = new PhonePart("PhonePartName", 20, true);

            //Assert
            Assert.AreEqual("LaptopPartName", laptopPart.Name);
            Assert.AreEqual(30, laptopPart.Cost);
            Assert.AreEqual(true, laptopPart.IsBroken);

            Assert.AreEqual("PCPartName", pCPart.Name);
            Assert.AreEqual(24, pCPart.Cost);
            Assert.AreEqual(true, pCPart.IsBroken);

            Assert.AreEqual("PhonePartName", phonePart.Name);
            Assert.AreEqual(26, phonePart.Cost);
            Assert.AreEqual(true, phonePart.IsBroken);
        }


        [Test]
        public void NameSetter_ShouldThrow_ExceptionIfNullOrEmpty()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                PhonePart itemPart = new PhonePart("", 10m);
            });
        }


        [Test]
        public void CostSetter_ShouldThrow_ExceptionIfZero()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                PhonePart itemPart = new PhonePart("Button", 0m);
            });
        }


        [Test]
        public void CostSetter_ShouldThrow_ExceptionIfNegative()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                PhonePart itemPart = new PhonePart("Button", -1m);
            });
        }


        [Test]
        public void RepairMethod_ShouldSet_IsBrokenProperty_ToFalse()
        {
            //Arrange
            bool expectedCondition = false;
            PhonePart itemPart = new PhonePart("Camera", 10m, true);

            //Act
            itemPart.Repair();

            //Assert
            Assert.That(expectedCondition, Is.EqualTo(itemPart.IsBroken));
        }


        [Test]
        public void ReportMethod_ShouldReturn_CorrectReport()
        {
            //Arrange
            PhonePart itemPart = new PhonePart("TouchID", 20m, true);

            string expectedReport = $"TouchID - 26.00$" 
                + Environment.NewLine 
                + $"Broken: True";

            //Assert
            Assert.That(expectedReport, Is.EqualTo(itemPart.Report()));
        }

    }
}