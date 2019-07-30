using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes
{
    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;
        private bool isOverbooked;

        protected Airplane(int seats, int bagCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = bagCompartments;

            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }

        //TODO add fields
        public int Seats {get;}

        public int BaggageCompartments { get;}

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => 
            this.passengers.AsReadOnly();

        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int seat)
        {
            //TODO can occur an error
            var passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);

            return passenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var passengerLuggage = this.baggageCompartment.Where(x => x.Owner.Username == passenger.Username).ToList();

            this.baggageCompartment.RemoveAll(x => x.Owner.Username == passenger.Username);

            return passengerLuggage;
        }

        public void LoadBag(IBag bag)
        {
            if (this.baggageCompartment.Count > this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }

            this.baggageCompartment.Add(bag);
        }
    }
}
