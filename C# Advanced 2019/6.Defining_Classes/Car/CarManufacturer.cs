using System;

namespace CarManufacturer
{
    class Program
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}







//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Car_Extension
//{
//    public class CarCannotContinueException : Exception
//    {
//        public CarCannotContinueException(string message)
//            : base(message)
//        {
//        }
//    }
//}

