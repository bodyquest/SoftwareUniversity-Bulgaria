using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles_2._0
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> final = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(", ");
                Article article = new Article();
                article.Title = command[0];
                article.Content = command[1];
                article.Author = command[2];
                final.Add(article);

            }
            string finalCommand = Console.ReadLine();
            if (finalCommand == "content")
            {
                final.Sort((x, y) => x.Content.CompareTo(y.Content));
                Console.WriteLine(string.Join("\r\n", final));
            }
            else if (finalCommand == "title")
            {
                final.Sort((x, y) => x.Title.CompareTo(y.Title));
                Console.WriteLine(string.Join("\r\n", final));
            }
            else if (finalCommand == "author")
            {
                final.Sort((x, y) => x.Author.CompareTo(y.Author));
                Console.WriteLine(string.Join("\r\n", final));
            }
        }
    }
}
