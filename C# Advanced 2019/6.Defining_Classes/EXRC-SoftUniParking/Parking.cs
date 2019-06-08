namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Parking
    {
        private Dictionary<string, Car> cars;

        private int capacity;

        public Parking(int cap)
        {
            capacity = cap;
            cars = new Dictionary<string, Car>();
        }

        public int Count
        {
            get { return cars.Count; }
        }

        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNum))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car.RegistrationNum, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNum}";
        }

        public string RemoveCar(string registrationNum)
        {
            if (!cars.ContainsKey(registrationNum))
            {
                return $"Car with that registration number, doesn't exist!";
            }

            cars.Remove(registrationNum);
            return $"Successfully removed {registrationNum}";
        }

        public Car GetCar(string registrationNum)
        {
            Car car = null;
            if (cars.ContainsKey(registrationNum))
            {
                car = cars[registrationNum];
            }

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNum in registrationNumbers)
            {
                RemoveCar(regNum);
            }
        }
    }
}
