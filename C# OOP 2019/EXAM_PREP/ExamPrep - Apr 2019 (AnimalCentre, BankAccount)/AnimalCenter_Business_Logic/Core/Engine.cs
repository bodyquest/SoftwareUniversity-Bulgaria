using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using AnimalCentre_Business_Logic.Core.Contracts;

namespace AnimalCentre_Business_Logic.Core
{
    public class Engine : IEngine
    {
        private AnimalCentre animalCentre;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
        }

        public void Run()
        {
            // console
            // pass to animal centre
            // print console
            // catch exception

            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    string[] args = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string command = args[0];
                    string[] arguments = args.Skip(1).ToArray();

                    string result = ReadCommand(command, arguments);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("InvalidOperationException" + e.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("ArgumentException" + ae.Message);
                }

                input = Console.ReadLine();
            }

            string adoptedAnimals = this.animalCentre.AllAdoptedAnimals();
            Console.WriteLine(adoptedAnimals);
        }

        private string ReadCommand(string command, string[] arguments)
        {

            string result = string.Empty;
            string name = string.Empty;
            int procedureTime  = 0;


            switch (command)
            {
                case "RegisterAnimal":
                    string type = arguments[0];
                    name = arguments[1];
                    int energy = int.Parse(arguments[2]);
                    int happiness = int.Parse(arguments[3]);
                    procedureTime = int.Parse(arguments[4]);

                    result = this.animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);

                    break;
                case "Chip":
                    name = arguments[0];
                    procedureTime = int.Parse(arguments[1]);

                    result = this.animalCentre.Chip(name, procedureTime);

                    break;
                case "Vaccinate":
                    name = arguments[0];
                    procedureTime = int.Parse(arguments[1]);

                    result = this.animalCentre.Vaccinate(name, procedureTime);

                    break;
                case "Fitness":
                    name = arguments[0];
                    procedureTime = int.Parse(arguments[1]);

                    result = this.animalCentre.Fitness(name, procedureTime);
                    break;
                case "Play":
                    name = arguments[0];
                    procedureTime = int.Parse(arguments[1]);

                    result = this.animalCentre.Play(name, procedureTime);

                    break;
                case "DentalCare":
                    name = arguments[0];
                    procedureTime = int.Parse(arguments[1]);

                    result = this.animalCentre.DentalCare(name, procedureTime);

                    break;
                case "NailTrim":
                    name = arguments[0];
                    procedureTime = int.Parse(arguments[1]);

                    result = this.animalCentre.NailTrim(name, procedureTime);

                    break;
                case "Adopt":
                    name = arguments[0];
                    string owner = arguments[1];
                    result = this.animalCentre.Adopt(name, owner);
                    break;
                case "History":
                    name = arguments[0];
                    result = this.animalCentre.History(name);

                    break;
            }

            return result;
        }
    }
}
