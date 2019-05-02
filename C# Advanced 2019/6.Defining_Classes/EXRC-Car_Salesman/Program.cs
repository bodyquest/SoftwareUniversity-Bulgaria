using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Car_Salesman
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = null;

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                if (engineInfo.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                else if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else
                {
                    bool isDisplacement = int.TryParse(engineInfo[2], out int displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineInfo[2]);
                    }
                }
                engines.Add(engine);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                string engineModel = carInfo[1];

                Engine engine = engines
                    .Where(x => x.Model == engineModel)
                    .FirstOrDefault();
                Car car = null;

                if (carInfo.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (carInfo.Length == 4)
                {
                    double weight = double.Parse(carInfo[2]);
                    string color = carInfo[3];

                    car = new Car(model, engine, weight, color);
                }
                else
                {
                    bool isWeight = double.TryParse(carInfo[2], out double weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, carInfo[2]);
                    }
                }

                cars.Add(car);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
