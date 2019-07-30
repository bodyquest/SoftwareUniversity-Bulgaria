// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;
    using Travel.Core.Controllers;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Items;

    [TestFixture]
    public class FlightControllerTests
    {
        // to test the TakeOff() method I need:
        // Airport
        // Trips
        // Airplane
        // Passenger
        // Bags -> items

        // trip.IsCompleted
        // if AppendLine trip.Id string is appended correctly
        // LoadCarryOnBaggage(trip) method
        // if airplane is overbooked - ejected message and the data 
        // if trip is completed

	   
	    public void Test_IfTakeOffMethod_WorksProperly()
	    {
            //test if completed
            var airport = new Airport();

            // test if plane is overbooked
            //test load carry on baggage
            var plane = new LigthAirplane();

            var passengers = new Passenger[10];
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Gosho" + i);
                plane.AddPassenger(passengers[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    var bag = new Bag(passengers[i], new Item[] { new Colombian() });
                    passengers[i].Bags.Add(bag);
                }
                else
                {
                    var bag = new Bag(passengers[i], new Item[] { new Toothbrush() });
                    passengers[i].Bags.Add(bag);
                }
            }
            
            var trip = new Trip("Tuk", "Tam", plane);
            airport.AddTrip(trip);

            FlightController flightController = new FlightController(airport);

            var completedTrip = new Trip("tam", "tuk", new MediumAirplane());

            //test isCompleted
            completedTrip.Complete();
            airport.AddTrip(completedTrip);

            var actualResult = flightController.TakeOff();
            var expectedResult = actualResult = "TukTam1:\r\nOverbooked! Ejected Gosho1, Gosho0, Gosho3, Gosho7, Gosho8\r\nConfiscated 3 bags ($50006)\r\nSuccessfully transported 5 passengers from Tuk to Tam.\r\nConfiscated bags: 3 (3 items) => $50006";

            Assert.AreEqual(actualResult, expectedResult);
            Assert.AreEqual(trip.IsCompleted, true);
        }

        [Test]
        public void CheckIf_Trip_IsCompleted()
        {
            //Arrange
            var airport = new Airport();
            var plane = new LigthAirplane();
            var trip = new Trip("Tuk", "Tam", plane);
            var passenger = new Passenger("Gosho");
            var bag = new Bag(passenger, new Item[] { new Colombian()});

            FlightController flightController = new FlightController(airport);

            //Act
            passenger.Bags.Add(bag);
            airport.AddTrip(trip);
            trip.Complete();

            var expected = flightController.TakeOff();
            var actual = "Confiscated bags: 0 (0 items) => $0";

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestIf_AirplaneIs_Overbooked()
        {
            //Arrange
            var airport = new Airport();
            var plane = new LigthAirplane();
            var trip = new Trip("Tuk", "Tam", plane);

            FlightController flightController = new FlightController(airport);

            //Act
            var passengers = new Passenger[10];
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Gosho" + i);
                plane.AddPassenger(passengers[i]);
            }

            airport.AddTrip(trip);

            var expected = flightController.TakeOff();
            var actual = "TukTam1:\r\nOverbooked! Ejected Gosho1, Gosho0, Gosho3, Gosho7, Gosho8\r\nConfiscated 0 bags ($0)\r\nSuccessfully transported 5 passengers from Tuk to Tam.\r\nConfiscated bags: 0 (0 items) => $0";

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(trip.IsCompleted, true);
        }

        [Test]
        public void Test_LoadCarryOnBaggage()
        {
            //Arrange
            var airport = new Airport();
            var plane = new LigthAirplane();
            var trip = new Trip("Tuk", "Tam", plane);

            FlightController flightController = new FlightController(airport);

            //Act
            var passengers = new Passenger[10];
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Gosho" + i);
                plane.AddPassenger(passengers[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    var bag = new Bag(passengers[i], new Item[] { new Colombian() });
                    passengers[i].Bags.Add(bag);
                }
                else
                {
                    var bag = new Bag(passengers[i], new Item[] { new Toothbrush() });
                    passengers[i].Bags.Add(bag);
                }
            }

            airport.AddTrip(trip);

            var expected = flightController.TakeOff();
            var actual = "TukTam1:\r\nOverbooked! Ejected Gosho1, Gosho0, Gosho3, Gosho7, Gosho8\r\nConfiscated 3 bags ($50006)\r\nSuccessfully transported 5 passengers from Tuk to Tam.\r\nConfiscated bags: 3 (3 items) => $50006";

            //Assert
            Assert.AreEqual(expected, actual);
        }
    } 
}
