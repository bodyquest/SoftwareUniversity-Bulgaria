namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;

    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using System.IO;
    using System.Globalization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            //1. Deserialize to DTO
            var moviesDtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            var sb = new StringBuilder();
            var validMovies = new List<Movie>();

            //2. Validation check
            foreach (var dto in moviesDtos)
            {
                var isValidEnum = Enum.TryParse<Genre>(dto.Genre, out Genre genreEnum);

                if (IsValid(dto))
                {
                    var movie = new Movie
                    {
                        Title = dto.Title,
                        Genre = genreEnum,
                        Rating = dto.Rating,
                        Director = dto.Director,
                        Duration = dto.Duration
                    };

                    validMovies.Add(movie);
                    sb.AppendLine(string.Format(SuccessfulImportMovie, dto.Title, dto.Genre, dto.Rating.ToString("F2")));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            // Add To DB
            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            //1. Deserialize to DTO
            var hallsSeatsDtos = JsonConvert.DeserializeObject<ImportHallsSeatsDto[]>(jsonString);

            var sb = new StringBuilder();
            var validHalls = new List<Hall>();

            //2. Validation check
            foreach (var dto in hallsSeatsDtos)
            {
                if (IsValid(dto))
                {
                    var hall = new Hall
                    {
                        Name = dto.Name,
                        Is4Dx = dto.Is4Dx,
                        Is3D = dto.Is3D,
                    };

                    for (int i = 0; i < dto.Seats; i++)
                    {
                        hall.Seats.Add(new Seat());
                    }

                    var projectionType = GetProjectionType(hall);

                    validHalls.Add(hall);

                    sb.AppendLine(string.Format(SuccessfulImportHallSeat, dto.Name, projectionType, dto.Seats.ToString()));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            // Add To DB
            context.Halls.AddRange(validHalls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            //1. Call the serializer
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportProjectionDto[]),
                new XmlRootAttribute("Projections"));

            //2. Deserialize
            var projectionDtos = (ImportProjectionDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var projections = new List<Projection>();

            //3. Go through each DTO object
            foreach (var dto in projectionDtos)
            {
                //4. Validate each purchaseDTO
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //5. Validate enum
                // NaN

                //6. Get Movie
                var movie = context.Movies.Find(dto.MovieId);

                //7. Get Hall
                var hall = context.Halls.Find(dto.HallId);

                //8. Validate movie and hall
                if (movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //9. Create the Projection object
                var date = DateTime.ParseExact(dto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                var projection = new Projection
                {
                    MovieId = dto.MovieId,
                    HallId = dto.HallId,
                    DateTime = date,
                };

                //10. Add to the collection
                projections.Add(projection);
                sb.AppendLine(string.Format(SuccessfulImportProjection, movie.Title, date.ToString("MM/dd/yyyy")));
            }

            //11. Add the collection of Purchases in the Database
            context.Projections.AddRange(projections);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            //1. Call the serializer
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportCustomersTicketsDto[]),
                new XmlRootAttribute("Customers"));

            //2. Deserialize
            var customersDtos = (ImportCustomersTicketsDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var customers = new List<Customer>();

            //3. Go through each DTO object
            foreach (var dto in customersDtos)
            {
                //4. Validate each DTO
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //5. Validate Projections in the Tickets List
                var projectionIds = context.Projections.Select(p => p.Id).ToList();

                bool projectionExists = dto.Tickets
                    .Select(t => t.ProjectionId)
                    .All(x => projectionIds.Contains(x));

                if (!projectionExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //6. Validate Tickets
                bool HasValidTickets = dto.Tickets.Any(t => IsValid(t));

                if (!HasValidTickets)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //4. Create the Customer object
                var customer = new Customer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    Balance = dto.Balance,
                    Tickets = dto.Tickets.Select(t => new Ticket 
                    {
                        ProjectionId = t.ProjectionId,
                        Price = t.Price
                    })
                    .ToArray()
                };

                //5. Add to the collection
                customers.Add(customer);

                var name = $"{dto.FirstName} {dto.LastName}";

                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, 
                    dto.FirstName, 
                    dto.LastName,
                    customer.Tickets.Count()));
            }

            //6. Add the collection of Purchases in the Database
            context.Customers.AddRange(customers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static string GetProjectionType(Hall hall)
        {
            var result = "Normal";
            if (hall.Is4Dx && hall.Is3D)
            {
                result = "4Dx/3D";
            }
            else if (hall.Is3D)
            {
                result = "3D";
            }
            else if (hall.Is4Dx)
            {
                result = "4Dx";
            }

            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}