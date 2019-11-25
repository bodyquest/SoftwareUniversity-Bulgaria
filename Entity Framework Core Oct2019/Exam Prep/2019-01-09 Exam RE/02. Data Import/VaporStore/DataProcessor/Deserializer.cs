namespace VaporStore.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

	using Data;
    using VaporStore.Data.Enums;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.ImportDtos;

    using Newtonsoft.Json;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var gamesDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var sb = new StringBuilder();
            var games = new List<Game>();
            //var validTags = new HashSet<string>(
            //    context.Tags
            //    .Select(p => p.Name));

            foreach (var gameDto in gamesDtos)
            {
                if (!IsValid(gameDto) || gameDto.Tags.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                };

                var developer = GetDeveloper(context, gameDto.Developer);
                var genre = GetGenre(context, gameDto.Genre);

                game.Developer = developer;
                game.Genre = genre;

                foreach (var tag in gameDto.Tags)
                {
                    var currentTag = GetTag(context, tag);

                    game.GameTags.Add(new GameTag
                    {
                        Game = game,
                        Tag = currentTag
                    });
                }

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count()} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
		}


        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var usersDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var sb = new StringBuilder();
            var users = new List<User>();

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isValidEnum = true;

                foreach (var cardDto in userDto.Cards)
                {
                    var cardType = Enum.TryParse<CardType>(cardDto.Type, out CardType test);

                    if (!cardType)
                    {
                        isValidEnum = false;
                        break;
                    }
                }

                if (!isValidEnum)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                };

                foreach (var cardDto in userDto.Cards)
                {
                    user.Cards.Add(new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = Enum.Parse<CardType>(cardDto.Type)
                    });
                }

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count()} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            //1. Call the serializer
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportPurchaseDto[]),
                new XmlRootAttribute("Purchases"));

            //2. Deserialize
            var purchaseDtos = (ImportPurchaseDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var purchases = new List<Purchase>();

            //3. Go through each DTO object
            foreach (var purchaseDto in purchaseDtos)
            {
                //4. Validate each purchaseDTO
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //5. Validate enum
                var isValidEnum = Enum.TryParse<PurchaseType>(purchaseDto.Type, out PurchaseType purchaseType);

                if (!isValidEnum)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //6. Get game
                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);
                //7. Get card
                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

                //8. Validate game and card
                if (game == null || card == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //9. Create the Purchase object
                var purchase = new Purchase
                {
                    Type = purchaseType,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Game = game,
                    Card = card,
                    ProductKey = purchaseDto.Key
                };

                //10. Add to the collection
                purchases.Add(purchase);
                sb.AppendLine($"Inported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            //11. Add the collection of Purchases in the Database
            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }

        private static Tag GetTag(VaporStoreDbContext context, string tag)
        {
            var validTag = context.Tags.FirstOrDefault(x => x.Name == tag);

            if (validTag == null)
            {
                validTag = new Tag()
                {
                    Name = tag,
                };

                context.Tags.Add(validTag);
                context.SaveChanges();
            }

            return validTag;
        }

        private static Genre GetGenre(VaporStoreDbContext context, string gameDtoGenre)
        {
            var genre = context.Genres.FirstOrDefault(d => d.Name == gameDtoGenre);

            if (genre == null)
            {
                genre = new Genre
                {
                    Name = gameDtoGenre
                };

                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return genre;
        }

        private static Developer GetDeveloper(VaporStoreDbContext context, string gameDtoDeveloper)
        {
            var developer = context.Developers.FirstOrDefault(d => d.Name == gameDtoDeveloper);

            if (developer == null)
            {
                developer = new Developer
                {
                    Name = gameDtoDeveloper
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            return developer;
        }
	}
}