namespace VaporStore.DataProcessor
{
	using System;
    using System.IO;
    using System.Xml;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;

    using Newtonsoft.Json;
    using VaporStore.DataProcessor.ExportDtos;
    using VaporStore.Data.Enums;
    using System.Globalization;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var genres = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                    .Where(p => p.Purchases.Any())
                    .Select(gm => new
                    {
                        Id = gm.Id,
                        Title = gm.Name,
                        Developer = gm.Developer.Name,
                        Tags = string.Join(", ", gm.GameTags.Select(t => t.Tag.Name)),
                        Players = gm.Purchases.Count
                    })
                        .OrderByDescending(x => x.Players)
                        .ThenBy(x => x.Id)
                        .ToArray(),
                    TotalPlayers = g.Games.Sum(x => x.Purchases.Count)
                })
                .OrderByDescending(t => t.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            var jsonSerialized = JsonConvert.SerializeObject(genres, Newtonsoft.Json.Formatting.Indented);

            return jsonSerialized;

        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            var purchaseType = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                .Select( x => new ExportUserDto 
                {
                    Username = x.Username,
                    Purchases = x.Cards
                       .SelectMany(p => p.Purchases)
                       .Where(t => t.Type == purchaseType)
                       .Select(p => new ExportPurchaseDto 
                       {
                           Card = p.Card.Number,
                           Cvc = p.Card.Cvc,
                           Date = p.Date.ToString("yyyy-MM-dd   H H:mm",CultureInfo.InvariantCulture),
                           Game = new ExportGameDto
                           {
                               Title = p.Game.Name,
                               Genre = p.Game.Genre.Name,
                               Price = p.Game.Price
                           }
                       })
                       .OrderBy(d => d.Date)
                       .ToArray(),
                    TotalSpent = x.Cards.SelectMany(p => p.Purchases)
                    .Where(t => t.Type == purchaseType)
                    .Sum(p => p.Game.Price)
                })
                .Where(p => p.Purchases.Any())
                .OrderByDescending(t => t.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();


            XmlSerializer serializer = new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), users, namespaces);

            
            return sb.ToString().TrimEnd();
        }
	}
}