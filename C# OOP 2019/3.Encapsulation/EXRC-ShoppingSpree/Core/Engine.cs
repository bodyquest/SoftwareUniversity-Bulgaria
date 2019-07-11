namespace EXRC_ShoppingSpree.Core
{
    using System;
    using System.Text;
    using System.Linq;

    using EXRC_ShoppingSpree.Models;
    using System.Collections.Generic;

    public class Engine
    {
        private List<Person> people;
        private List<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                ReadPeopleInput();
                ReadProductInput();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] commandTokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string personName = commandTokens[0];
                    string productName = commandTokens[1];

                    Person person = this.people.FirstOrDefault(p => p.Name == personName);
                    Product product = this.products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        person.BuyProduct(product);

                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(Environment.NewLine, this.people));
        }

        private void ReadProductInput()
        {
            var productTokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var item in productTokens)
            {
                string[] productInfo = item
                    .Split("=")
                    .ToArray();

                string name = productInfo[0];
                decimal cost = decimal.Parse(productInfo[1]);

                Product product = new Product(name, cost);
                this.products.Add(product);
            }
        }

        private void ReadPeopleInput()
        {
            var personTokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var item in personTokens)
            {
                string[] personInfo = item
                    .Split("=")
                    .ToArray();

                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                Person person = new Person(name, money);
                this.people.Add(person);
            }
        }
    }
}
