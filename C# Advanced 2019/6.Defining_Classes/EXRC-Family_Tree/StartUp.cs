using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Family_Tree
{
    public class Program
    {
        static void Main()
        {
            List<Relation> relations = new List<Relation>();
            List<Person> peopleInfo = new List<Person>();
            string input = Console.ReadLine();
            if (!input.Contains("/"))
            {
                var personInfo = input.Split(' ');
                string name = personInfo[0];
                string surname = personInfo[1];

            }
            else
            {
                var dateInfo = input.Split('/');
                int day = int.Parse(dateInfo[0]);
                int month = int.Parse(dateInfo[1]);
                int year = int.Parse(dateInfo[2]);


            }

            string relationInfo = Console.ReadLine();
            while (relationInfo != "End")
            {
                if (relationInfo.Contains("-"))
                {
                    var splittedInput = Console.ReadLine().Split('-').ToArray();
                    string parentArgument = splittedInput[0];
                    string childArgument = splittedInput[1];

                    Person parent = new Person(parentArgument);
                    Person child = new Person(childArgument);

                    Relation relation = new Relation(parent, child);
                    relations.Add(relation);

                }
                else
                {
                    var splittedInput = Console.ReadLine().Split(' ').ToArray();
                    string name = $"{splittedInput[0]} {splittedInput[1]}";
                    string birthdate = splittedInput[2];

                    Person person = new Person(name, birthdate);
                    peopleInfo.Add(person);
                }

                relationInfo = Console.ReadLine();
            }

            Person mainPerson = peopleInfo.FirstOrDefault(x => x.Birthdate == input || x.Name == input);

            var filteredRelations = relations.Where(x => x.Parent.Birthdate == mainPerson.Birthdate 
            || x.Child.Birthdate == mainPerson.Birthdate
            || x.Parent.Name == mainPerson.Name
            || x.Child.Name == mainPerson.Name)
            .ToList();

            Result result = new Result();

            result.MainPerson = mainPerson;

            foreach (var relation in filteredRelations)
            {

            }
        }
    }
}
