namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public Person(string firstName, string secondName, int age)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
        }

        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public int Age { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.SecondName} is {this.Age} years old.";
        }
    }
}
