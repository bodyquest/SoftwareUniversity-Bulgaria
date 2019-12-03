namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;

    using Data;
    using Cinema.DataProcessor.ExportDto;

    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using System.Text;
    using System.Xml;
    using System.IO;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count > 0))
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = m.Rating.ToString("F2"),
                    TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                    Customers = m.Projections
                        .SelectMany(p => p.Tickets)
                        .Select(t => new ExportCustomerDto
                        {
                            FirstName = t.Customer.FirstName,
                            LastName = t.Customer.LastName,
                            Balance = t.Customer.Balance.ToString("F2")
                        })
                        .OrderByDescending(t => t.Balance)
                        .ThenBy(t => t.FirstName)
                        .ThenBy(t => t.LastName)
                        .ToArray()
                })
                .Take(10)
                .ToArray();

            var jsonSerialized = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            return jsonSerialized;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(c => c.Age >= age)
                .OrderByDescending(c => c.Tickets.Sum(t => t.Price))
                .Select(c => new ExportTopCustomerDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = c.Tickets.Sum(t => t.Price).ToString("F2"),
                    SpentTime = TimeSpan.FromSeconds(c.Tickets.Sum(t => t.Projection.Movie.Duration.TotalSeconds))
                    .ToString(@"hh\:mm\:ss")
                })
                .Take(10)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportTopCustomerDto[]), new XmlRootAttribute("Customers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}