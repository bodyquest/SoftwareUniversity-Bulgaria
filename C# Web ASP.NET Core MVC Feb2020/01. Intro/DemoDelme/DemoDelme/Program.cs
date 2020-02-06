using System;

namespace DemoDelme
{
    class Program
    {
        private const string embedLink = "https%3A%2F%2Fwww.youtube.com%2Fembed%2F";

        public static void Main(string[] args)
        {
            string link = Console.ReadLine();
            int linkIdStart = link.IndexOf("=");

            string videoEmbedLink = String.Concat(embedLink, link.Substring(link.IndexOf("%3D") + 3));
            Console.WriteLine(new string('=',7));
            Console.WriteLine(videoEmbedLink);
        }
    }
}
