namespace ParkingSystem.Tests
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class SoftParkTest
    {
        private Car car;
        private string parkSpot;
        private SoftPark softPark;
        private readonly Dictionary<string, Car> parking;

        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
        }

        [Test]
        public void Constructor_Initializes_Successfully_The_Collection()
        {
            int expectedCount = 12;

            Assert.AreEqual(expectedCount, this.softPark.Parking.Count);
            Assert.IsNotNull(this.softPark.Parking);
        }

        [Test]
        public void ParkCarMethod_ShouldWork_Correctly()
        {
            //Arrange
            this.car = new Car("Trabi", "BBQ-666");
            this.parkSpot = "A1";

            //Act
            string expected = $"Car:{this.car.RegistrationNumber} parked successfully!";
            string actual = this.softPark.ParkCar(this.parkSpot, this.car);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ParkCarMethod_ThrowsException_ForNonExistingParkSpot()
        {
            //Arrange
            this.car = new Car("Trabi", "BBQ-666");
            this.parkSpot = "A0";

            //Assert
            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar(this.parkSpot, this.car));
        }

        [Test]
        public void ParkCarMethod_ThrowsException_ForNullCar()
        {
            //Arrange
            this.car = new Car("Trabi", "BBQ-666");
            var newCar = new Car("Moskvitch", "BJJ-777");
            this.parkSpot = "A1";

            //Act
            this.softPark.ParkCar(this.parkSpot, this.car);

            //Assert
            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar(this.parkSpot, newCar));
        }

        [Test]
        public void ParkCarMethod_ThrowsException_ForExistingCar()
        {
            //Arrange
            this.car = new Car("Trabi", "BBQ-666");
            this.parkSpot = "A1";

            //Act
            this.softPark.ParkCar(this.parkSpot, this.car);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.softPark.ParkCar("A2", this.car));
        }

        [Test]
        public void RemoveCarMethod_ShouldWork_Correctly()
        {
            //Arrange
            this.car = new Car("Trabi", "BBQ-666");
            this.parkSpot = "A1";

            //Act
            this.softPark.ParkCar(this.parkSpot, this.car);

            string expected = $"Remove car:{this.car.RegistrationNumber} successfully!";
            string actual = this.softPark.RemoveCar("A1", this.car);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveCarMethod_ThrowsException_ForNonexistingParkingSPot()
        {
            //Arrange
            this.car = new Car("Trabi", "BBQ-666");
            this.parkSpot = "A1";

            //Act
            this.softPark.ParkCar(this.parkSpot, this.car);

            //Assert
            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("A0", this.car));
        }

        [Test]
        public void RemoveCarMethod_ThrowsException_ForRemovingNotSameCarOnTheSpot()
        {
            //Arrange
            this.car = new Car("Trabi", "BBQ-666");
            var newCar = new Car("Moskvitch", "BJJ-777");
            this.parkSpot = "A1";

            //Act
            this.softPark.ParkCar(this.parkSpot, this.car);

            //Assert
            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("A1", newCar));
        }

    }
}