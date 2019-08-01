using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EXRC_DatabaseExtended
{
    public class DatabaseExtended
    {
        private const int DEFAULT_LENGTH = 16;
        private Person[] database;
        private int index;

        public DatabaseExtended(params Person[] collection)
        {
            this.database = new Person[DEFAULT_LENGTH];
            this.index = 0;

            foreach (var person in collection)
            {
                this.Add(person);
            }
        }

        public ICollection<Person> Database => this.database;

        public void Add(Person person)
        {
            if (index >= DEFAULT_LENGTH)
            {
                throw new InvalidOperationException($"Database is full");
            }

            if (this.database.Any(u => u?.Username == person.Username))
            {
                throw new InvalidOperationException("Username already exists");

            }
            else if (this.database.Any(u => u?.Id == person.Id))
            {
                throw new InvalidOperationException("User Id already exists");
            }
            else
            {
                this.database[this.index++] = person;
            }
        }

        public Person Remove()
        {
            if (this.database.Length == 0)
            {
                throw new InvalidOperationException("Database is empty");
            }

            return this.database[--index];
        }

        public string FindByUsername(string username)
        {
            if (this.database.Any(u => u?.Username == username) == false)
            {
                throw new InvalidOperationException("No such user found");
            }
            else if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException($"Username cannot be null");
            }

            Person person = this.database.First(p => p?.Username == username);
            return $"Found {person.Username} username";
        }

        public string FindById(int id)
        {
            if (this.database.Any(u => u?.Id == id) == false)
            {
                throw new InvalidOperationException("No such user found");
            }
            else if (id < 0)
            {
                throw new ArgumentNullException($"Id cannot be negative");
            }

            Person person = this.database.First(p => p.Id == id);
            return $"Found user with {person.Id} id";
        }

        public Person[] Fetch()
        {
            return this.database.Take(index).ToArray();
        }
    }
}
