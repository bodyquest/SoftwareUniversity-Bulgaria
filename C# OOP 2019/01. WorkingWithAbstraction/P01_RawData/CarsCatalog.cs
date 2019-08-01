namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CarsCatalog
    {
        private const int tireCount = 4;
        private List<Car> cars;
        private EngineFactory engineFactory;

        public CarsCatalog(EngineFactory engineFactory)
        {
            this.cars = new List<Car>();
            this.engineFactory = engineFactory;
        }

        public void Add(string []parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            Engine engine = engineFactory.Create(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoType, cargoWeight);
            Tire[] tires = GetTires(parameters.Skip(5).ToList());

            int tireIndex = 0;

            Car car = new Car(model, engine, cargo, tires);
            cars.Add(car);
        }

        private Tire[] GetTires(List<string> tireParameters)
        {
            Tire[] tires = new Tire[tireCount];

            int tireIndex = 0;
            for (int j = 0; j < 8; j += 2)
            {
                double tirePressure = double.Parse(tireParameters[j]);
                int tireAge = int.Parse(tireParameters[j + 1]);
                Tire tire = new Tire(tirePressure, tireAge);
                tires[tireIndex] = tire;

                tireIndex++;
            }

            return tires;
        }

        public List<Car> GetCars() => this.cars;
    }
}
