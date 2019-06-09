namespace EXRC_Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            int carsQty = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < carsQty; i++)
            {
                var array = Console.ReadLine().Split(' ').ToArray();
                string model = array[0];
                int speed = int.Parse(array[1]);
                int power = int.Parse(array[2]);
                int weight = int.Parse(array[3]);
                string type = array[4];
                double tire1Pressure = double.Parse(array[5]);
                int tire1Age = int.Parse(array[6]);

                double tire2Pressure = double.Parse(array[7]);
                int tire2Age = int.Parse(array[8]);

                double tire3Pressure = double.Parse(array[9]);
                int tire3Age = int.Parse(array[10]);

                double tire4Pressure = double.Parse(array[11]);
                int tire4Age = int.Parse(array[12]);

                Car car = new Car();
                car.Model = model;
                Engine engine = new Engine(speed, power);
                car.Engine = engine;
                Cargo cargo = new Cargo(weight, type);
                car.Cargo = cargo;

                Tire[] tires = new Tire[4];
                tires[0] = new Tire(tire1Pressure, tire1Age);
                tires[1] = new Tire(tire2Pressure, tire2Age);
                tires[2] = new Tire(tire3Pressure, tire3Age);
                tires[3] = new Tire(tire4Pressure, tire4Age);
                car.Tires = tires;

                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Cargo.Type == command)
                    {
                        for (int j = 0; j < cars[i].Tires.Length; j++)
                        {
                            if ((cars[i].Tires)[j].Pressure < 1)
                            {
                                Console.WriteLine(cars[i].ToString());
                                return;
                            }
                        }
                    }
                }
            }
            else if (command == "flamable")
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Cargo.Type == command)
                    {
                        if (cars[i].Engine.Power > 250)
                        {
                            Console.WriteLine(cars[i].ToString());
                        }
                    }
                }
            }
        }
    }
}
