using Service.Models.Parts;

using System;
using NUnit.Framework;

namespace Tests
{
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
            Assert.AreEqual(cost * 1.3m, itemPart.Cost);
            Assert.AreEqual(isBroken, itemPart.IsBroken);
        }

        [Test]
        public void Constructor_ShouldWork_ProperlyWithNonBrokenPart()
        {
            string name = "Display";
            decimal cost = 10m;
            bool isBroken = false;

            PhonePart itemPart = new PhonePart(name, cost, isBroken);

            Assert.AreEqual(name, itemPart.Name);
            Assert.AreEqual(cost * 1.3m, itemPart.Cost);
            Assert.AreEqual(isBroken, itemPart.IsBroken);
        }


        [Test]
        public void NameSetter_ShouldThrow_ExceptionIfNullOrEmpty()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                PhonePart itemPart = new PhonePart("", 10m, false);
            });
        }


        [Test]
        public void CostSetter_ShouldThrow_ExceptionIfZero()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                PhonePart itemPart = new PhonePart("Button", 0m, false);
            });
        }

        [Test]
        public void CostSetter_ShouldThrow_ExceptionIfNegative()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                PhonePart itemPart = new PhonePart("Button", -1m, false);
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
        public void ReportMethod_ShouldReturn_CorrectStringInfo()
        {
            //Arrange
            PhonePart itemPart = new PhonePart("TouchID", 20m, true);

            string expectedReport = $"{ itemPart.Name} - { itemPart.Cost:f2}$" 
                + Environment.NewLine 
                + $"Broken: {itemPart.IsBroken}";

            //Assert
            Assert.That(expectedReport, Is.EqualTo(itemPart.Report()));
        }

    }
}