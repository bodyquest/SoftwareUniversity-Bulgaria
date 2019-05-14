using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google
{
    public class Company
    {
        private double salary;
        public Company(string name, string department, string salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }

        public string Name { get; set; }

        public string Department { get; set; }

        public string Salary
        {
            get { return this.salary.ToString("0.00"); }
            set
            {
                this.salary = double.Parse(value);
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Department} {this.Salary}";
        }
    }

    public class Car
    {
        public Car(string model, int speed)
        {
            this.Model = model;
            this.Speed = speed;
        }
        public string Model { get; set; }

        public int Speed { get; set; }

        public override string ToString()
        {
            return $"{this.Model} {this.Speed}";
        }
    }

    public class Pokemon
    {
        public Pokemon(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
        public string Name { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Type}";
        }
    }

    public class Parent
    {
        public Parent(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }
        public string Name { get; set; }

        public string BirthDate { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.BirthDate}";
        }
    }

    public class Child
    {
        public Child(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public string Name { get; set; }

        public string BirthDate { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.BirthDate}";
        }
    }

    public class Person
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="name"></param>
        public Person(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
            this.Parents = new List<Parent>();
            this.Children = new List<Child>();
        }

        public string Name { get; set; }

        public Company Company { get; set; }

        public Car Car { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public List<Parent> Parents { get; set; }

        public List<Child> Children { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(this.Name.ToString());

            result.AppendLine("Company:");
            if (this.Company != null)
            {
                result.AppendLine(this.Company.ToString());
            }
            
            result.AppendLine("Car:");
            if (this.Car != null)
            {
                result.AppendLine(this.Car.ToString());
            }

            result.AppendLine("Pokemon:");

            if (Pokemons.Any())
            {
                result.AppendLine(string.Join(Environment.NewLine, Pokemons));
            }
            result.AppendLine("Parents:");

            if (Parents.Any())
            {
                result.AppendLine(string.Join(Environment.NewLine, Parents));
            }

            result.AppendLine("Children:");

            if (Children.Any())
            {
                result.AppendLine(string.Join(Environment.NewLine, Children));
            }

            return result.ToString().TrimEnd();
        }
    }
}
