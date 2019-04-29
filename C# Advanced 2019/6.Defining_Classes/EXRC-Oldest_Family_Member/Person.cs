using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        //CONSTRUCTORS are between FIELDS and PROPERTIES
        //full cosntructor
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Person(int age) : this("No name", age)
        {
        }
        public Person() : this("No name", 1)
        {
        }
        public string Name
        {
            get { return name; }

            set { name = value; }
        }
        public int Age
        {
            get { return age; }

            set { age = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
