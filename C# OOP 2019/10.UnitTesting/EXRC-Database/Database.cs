using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EXRC_Database
{
    public class Database
    {
        private const int DEFAULT_LENGTH = 16;
        private Person[] database;
        private int index;

        public Database(params Person [] collection)
            : this(collection.ToList())
        {
        }

        public Database(IEnumerable <Person> collection)
        {
            this.ValidateCollection(collection.ToArray());
            this.index = 0;
            this.database = new Person[DEFAULT_LENGTH];
            this.DatabaseElements = collection.ToArray();
        }

        public int[] DatabaseElements
        {
            get
            {
                List<Person> people = new List<Person>();
                for (int i = 0; i < index; i++)
                {
                    people.Add(this.database[i]);
                }

                return people.ToArray();
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    this.database[this.index] = value[i];
                    this.index++;
                }
            }
        }

        public void ValidateCollection(int [] value)
        {
            if (value.Length > 16 || value.Length < 1)
            {
                throw new InvalidOperationException("Invalid collection size");
            }
        }

        public void Add(int number)
        {
            if (index >= 16)
            {
                throw new InvalidOperationException($"Database is full");
            }

            this.database[this.index] = number;
            this.index++;
        }

        public void Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Database is empty");
            }

            this.database[this.index - 1] = default(int);
            this.index--;
        }



    }
}
