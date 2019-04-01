using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisement_Message
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{GetPhrse()} {GetEvents()} {GetAuthors()} - {GetCities()}");
            }
        }

        private static string GetPhrse()
        {
            string phrase = string.Empty;
            List<string> collection = new List<string>
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."

            };
            return phrase = collection[rnd.Next(0, collection.Count)];
        }

        private static string GetEvents()
        {
            string events = string.Empty;
            List<string> collection = new List<string>
            {
               "Now I feel good.",
               "I have succeeded with this product.",
               "Makes miracles. I am happy of the results!",
               "I cannot believe but now I feel awesome.",
               "Try it yourself, I am very satisfied.",
               "I feel great!"

            };
            return events = collection[rnd.Next(0, collection.Count)];
        }

        private static string GetAuthors()
        {
            string author = string.Empty;
            List<string> collection = new List<string>
            {
               "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"

            };
            return author = collection[rnd.Next(0, collection.Count)];
        }

        private static string GetCities()
        {
            string city = string.Empty;
            List<string> collection = new List<string>
            {
               "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"

            };
            return city = collection[rnd.Next(0, collection.Count)];
        }
    }
}
