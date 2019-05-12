using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_Family_Tree
{
    public class Person
    {
        public Person(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public Person(string data)
        {
            if (Char.IsDigit(data[0]))
            {
                this.Birthdate = data;
            }
            else
            {
                this.Name = data;
            }
        }

        public string Name { get; set; }

        public string Birthdate { get; set; }


        private string relation;

        public string Relation
        {
            get { return relation; }
            set
            {

                relation = value;
            }
        }
    }
}
