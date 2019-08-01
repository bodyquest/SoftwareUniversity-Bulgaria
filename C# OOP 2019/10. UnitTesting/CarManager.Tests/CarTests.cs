using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        // CTORS
        //  - with params

        // PROPs
        //  - Make - OK
        //  - Model - OK
        //  - FuelConsum - OK
        //  - FuelAmmount - OK
        //  - FuelCapacity - OK

        // METHODS()
        //  - Refuel() - OK
        //  - Drive() - OK

        private Car car;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShouldWork_Correctly()
        {
            //Arrange
            string make = "Audi";
            string model = "Quattro";
            double fuelConsum = 5;
            double fuelCapacity = 60;

            this.car = new Car(make, model, fuelConsum, fuelCapacity);

            //Assert
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsum, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void MakeSetter_ShouldThrowException_IfMakeNullOrEmpty()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("", "Quattro", 5, 60);
            });
        }

        [Test]
        public void ModelSetter_ShouldThrowException_IfMakeNullOrEmpty()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "", 5, 60);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionSetter_ShouldThrowException_IfZeroOrNegative(double fuelConsum)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "Quattro", fuelConsum, 60);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacitySetter_ShouldThrowException_IfZeroOrNegative(double fuelCapacity)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "Quattro", 5, fuelCapacity);
            });
        }

        [Test]
        [TestCase(5)]
        public void RefuelMethod_Works_Properly(double fuel)
        {
            //Arrange
            Car car = new Car("Audi", "Quattro", 5, 50);
            double expectedAmount = 5;

            //Act
            car.Refuel(fuel);

            //Assert
            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }

        [Test]
        [TestCase(51)]
        public void RefuelMethod_WorksProperly_WhenRefuelingWithMoreThanCapacity(double fuel)
        {
            //Arrange
            Car car = new Car("Audi", "Quattro", 5, 50);
            double expectedAmount = 50;

            //Act
            car.Refuel(fuel);

            //Assert
            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelMethod_ThrowsException_IfRefuelingWithNegativeOrZeroNumber(double fuelAmount)
        {
            //Arrange
            Car car = new Car("Audi", "Quattro", 5, 50);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>car.Refuel(fuelAmount));
        }

        [Test]
        public void DriveMethod_Works_Properly()
        {
            //Arrange
            Car car = new Car("Audi", "Quattro", 5, 50);
            double expectedAmount = 4;

            //Act
            car.Refuel(5);
            car.Drive(20);

            //Assert
            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }


        [Test]
        [TestCase(50)]
        public void DriveMethod_ThrowsException_IfDrivingNeedsMoreFuel(double distance)
        {
            //Arrange
            Car car = new Car("Audi", "Quattro", 5, 50);

            //Act
            car.Refuel(2);

            //Assert
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }
    }
}