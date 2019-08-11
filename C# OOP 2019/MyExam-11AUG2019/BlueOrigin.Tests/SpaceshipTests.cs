namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        //TODO LIST
        // Validate CTOR (for every child class if any) - this also tests property getters
        // IF Classes hav COLLECTION with PUBLIC GET then check in CTOR by Assert.IsNotNull()
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

        //CTOR
        // 1. Name and Capacity
        // 2. Colleciton not null
        // Count Property
        // Capacity
        // AddMethod  ArgNullEx
        // RemoveMethod ArgEx

        [Test]
        public void Constructor_ShouldInitialize_CollectionnOTnULL()
        {
            //Arrange
            var ship = new Spaceship("Apollo", 3);
            var astronaut = new Astronaut("Buzz", 90);

            //Act
            int expectedCount = 1;
            ship.Add(astronaut);

            //Assert
            Assert.AreEqual(expectedCount ,ship.Count);
        }

        [Test]
        public void Constructor_ShouldInitialize_Correctly()
        {
            //Arrange
            var ship = new Spaceship("Apollo", 3);

            //Act
            int expectedCapacity = 3;

            //Assert
            Assert.AreEqual(expectedCapacity, ship.Capacity);
        }

        [Test]
        public void Capacity_Throws_Exception()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var ship = new Spaceship("Apollo", -1);
            });
        }

        [Test]
        public void NameProperty_Throws_Exception()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var ship = new Spaceship("", 3);
            });
        }

        [Test]
        public void CountProperty_ShouldBeSet_Correctly()
        {
            //Arrange
            var ship = new Spaceship("Apollo", 3);
            var astronaut = new Astronaut("Buzz", 90);
            var astronaut2 = new Astronaut("Michael", 90);

            //Act
            int expectedCount = 2;
            ship.Add(astronaut);
            ship.Add(astronaut2);

            //Assert
            Assert.AreEqual(expectedCount, ship.Count);
        }

        [Test]
        public void AddMethod_ShouldWork_Correctly()
        {
            //Arrange
            var ship = new Spaceship("Apollo", 3);
            var astronaut = new Astronaut("Buzz", 90);

            //Act
            int expectedCount = 1;
            ship.Add(astronaut);

            //Assert
            Assert.AreEqual(expectedCount, ship.Count);
        }

        [Test]
        public void AddMethod_ThrowsException_()
        {
            //Arrange
            var ship = new Spaceship("Apollo", 2);
            var astronaut = new Astronaut("Buzz", 90);
            var astronaut2 = new Astronaut("Neil", 80);
            var astronaut3 = new Astronaut("Michael", 80);


            //Act
            ship.Add(astronaut);
            ship.Add(astronaut2);

            //Assert
            Assert.Throws<InvalidOperationException>(() => { ship.Add(astronaut3); });
        }

        [Test]
        public void AddMethod_ThrowsException_IfAstronautExists()
        {
            //Arrange
            var ship = new Spaceship("Apollo", 3);
            var astronaut = new Astronaut("Buzz", 90);

            //Act
            ship.Add(astronaut);

            //Assert
            Assert.Throws<InvalidOperationException>(() => { ship.Add(astronaut); });
        }

        [Test]
        public void RemoveMethod_ShouldWork_Correctly()
        {
            //Arrange
            var ship = new Spaceship("Apollo", 3);
            var astronaut = new Astronaut("Buzz", 90);

            //Act
            int expected = 0;
            ship.Add(astronaut);
            ship.Remove(astronaut.Name);

            //Assert
            Assert.AreEqual(expected, ship.Count);
        }

       
    }
}