namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class People
    {
        private List<Person> people;

        public People()
        {
            this.people = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            this.people.Add(person);
        }

        public List<Person> GetOlderThanThirty()
        {
            return this.people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
        }
    }
}
