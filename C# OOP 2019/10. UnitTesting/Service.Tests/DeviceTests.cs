using System;
using NUnit.Framework;

using Service.Models.Parts;
using Service.Models.Devices;

namespace Service.Tests
{
    [TestFixture]
    public class DeviceTests
    {
        private string make;
        private Device device;
        private string name;
        private decimal cost;
        bool isBroken;
        private Part part;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LaptopConstructor_ShouldWork_Correctly()
        {
            string expectedMake = "IBM";

            this.device = new Laptop(expectedMake);

            Assert.AreEqual(expectedMake, this.device.Make);
            Assert.IsNotNull(this.device.Parts);
        }

        [Test]
        public void LaptopAddPartMethod_ShouldWork_Correctly()
        {
            this.make = "IBM";
            this.device = new Laptop(this.make);
            this.name = "Battery";
            this.cost = 10.00m;
            this.isBroken = true;
            this.part = new LaptopPart(name, cost, isBroken);

            this.device.AddPart(this.part);

            Assert.That(this.device.Parts, Has.Member(this.part));
        }

        [Test]
        public void LaptopAddPartMethod_ThrowsException_ForInvalidPartType()
        {
            this.make = "IBM";
            this.device = new Laptop(this.make);
            this.name = "Keyboard";
            this.cost = 10.00m;
            this.isBroken = true;
            this.part = new PCPart(name, cost, isBroken);

            Assert.Throws<InvalidOperationException>(() => this.device.AddPart(this.part));
        }

        [Test]
        public void PCConstructor_ShouldWork_Correctly()
        {
            string expectedMake = "Pravec";

            this.device = new PC(expectedMake);

            Assert.AreEqual(expectedMake, this.device.Make);
            Assert.IsNotNull(this.device.Parts);
        }

        [Test]
        public void PCAddPartMethod_ShouldWork_Correctly()
        {
            this.make = "Pravec";
            this.device = new PC(this.make);
            this.name = "PartName";
            this.cost = 10.00m;
            this.isBroken = true;
            this.part = new PCPart(name, cost, isBroken);

            this.device.AddPart(this.part);

            Assert.That(this.device.Parts, Has.Member(this.part));
        }

        [Test]
        public void PCAddPartMethod_ThrowsException_ForInvalidPartType()
        {
            this.make = "Pravec";
            this.device = new PC(this.make);
            this.name = "PartName";
            this.cost = 10.00m;
            this.isBroken = true;
            this.part = new LaptopPart(name, cost, isBroken);

            Assert.Throws<InvalidOperationException>(() => this.device.AddPart(this.part));
        }

        [Test]
        public void PhoneConstructor_ShouldWork_Correctly()
        {
            string expectedMake = "Apple";

            this.device = new Phone(expectedMake);

            Assert.AreEqual(expectedMake, this.device.Make);
            Assert.IsNotNull(this.device.Parts);
        }

        [Test]
        public void PhoneAddPartMethod_ShouldWork_Correctly()
        {
            this.make = "Apple";
            this.device = new Phone(this.make);
            this.name = "PartName";
            this.cost = 10.00m;
            this.isBroken = true;
            this.part = new PhonePart(name, cost, isBroken);

            this.device.AddPart(this.part);

            Assert.That(this.device.Parts, Has.Member(this.part));
        }

        [Test]
        public void PhoneAddPartMethod_ThrowsException_ForInvalidType()
        {
            this.make = "Apple";
            this.device = new Phone(this.make);
            this.name = "PartName";
            this.cost = 10.00m;
            this.isBroken = true;
            this.part = new LaptopPart(name, cost, isBroken);

            Assert.Throws<InvalidOperationException>(() => this.device.AddPart(this.part));
        }

        [Test]
        public void MakeSetter_ThrowsException_ForNullOrEmptyMake()
        {
            this.make = "";
            Assert.Throws<ArgumentException>(() => this.device = new Laptop(this.make));
        }

        [Test]
        public void DeviceAddPartMethod_ThrowsException_ForExistingPart()
        {
            this.make = "IBM";
            this.device = new Laptop(this.make);
            this.name = "Monitor";
            this.cost = 10.00m;
            this.isBroken = true;
            this.part = new LaptopPart(name, cost, isBroken);

            this.device.AddPart(this.part);

            Assert.Throws<InvalidOperationException>(() => this.device.AddPart(this.part));
        }

        [Test]
        public void DeviceRemovePartMethod_ShouldWork_Correctly()
        {
            this.make = "IBM";
            this.device = new Laptop(this.make);
            this.name = "RAM";
            this.cost = 10.00m;
            this.isBroken = true;
            this.part = new LaptopPart(name, cost, isBroken);

            this.device.AddPart(this.part);
            this.device.RemovePart(this.part.Name);

            Assert.That(this.device.Parts, !Has.Member(part));
        }

        [Test]
        public void DeviceRemovePartMethod_ThrowsException_ForEmptyName()
        {
            this.make = "IBM";
            this.device = new Laptop(this.make);
            this.name = "";

            Assert.Throws<ArgumentException>(() => this.device.RemovePart(this.name));
        }

        [Test]
        public void DeviceRemovePartMethod_ThrowsException_ForNonExistingPart()
        {
            this.make = "IBM";
            this.device = new Laptop(this.make);
            this.name = "Flash";

            Assert.Throws<InvalidOperationException>(() => this.device.RemovePart(this.name));
        }

        [Test]
        public void DeviceRepairPartMethod_ShouldWork_Correctly()
        {
            bool expectedIsBroken = false;
            this.make = "IBM";
            this.device = new Laptop(this.make);
            this.name = "SSD";
            this.cost = 10.0m;
            this.isBroken = true;
            this.part = new LaptopPart(name, cost, isBroken);

            this.device.AddPart(this.part);
            this.device.RepairPart(this.name);

            Assert.AreEqual(expectedIsBroken, this.part.IsBroken);
        }

        [Test]
        public void DeviceRepairPartMethod_ThrowsException_ForEmptyName()
        {
            this.make = "IBM";
            this.device = new Laptop(this.make);
            this.name = "";

            Assert.Throws<ArgumentException>(() => this.device.RepairPart(this.name));
        }

        [Test]
        public void DeviceRepairPartMethod_ThrowsException_ForNonExistingPart()
        {
            this.make = "IBM";
            this.device = new Laptop(this.make);
            this.name = "Flash";

            Assert.Throws<InvalidOperationException>(() => this.device.RepairPart(this.name));
        }

        [Test]
        public void DeviceRepairPartMethod_ThrowsException_ForNonBrokenPart()
        {
            this.make = "IBM";
            this.device = new Laptop(this.make);
            this.name = "Keyboard";
            this.cost = 10.0m;
            this.isBroken = false;
            this.part = new LaptopPart(name, cost, isBroken);

            this.device.AddPart(this.part);

            Assert.Throws<InvalidOperationException>(() => this.device.RepairPart(this.name));
        }
    }
}
