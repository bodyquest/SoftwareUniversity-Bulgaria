namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;

    using Data;
    using Cinema.DataProcessor.ExportDto;

    using Newtonsoft.Json;

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

            var jsonSerialized = JsonConvert.SerializeObject(movies, Formatting.Indented);

            return jsonSerialized;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            throw new NotImplementedException();
        }
    }
}