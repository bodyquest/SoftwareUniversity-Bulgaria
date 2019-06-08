using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int horsePower, string registrationNum)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNum = registrationNum;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNum { get; set; }

        public override string ToString()
        {
            string result = $"Make: {Make}" +
                Environment.NewLine +
                $"Model: {Model}" +
                Environment.NewLine +
                $"HorsePower: {HorsePower}" +
                Environment.NewLine +
                $"RegistrationNumber: {RegistrationNum}";

            return result;
        }
    }
}
