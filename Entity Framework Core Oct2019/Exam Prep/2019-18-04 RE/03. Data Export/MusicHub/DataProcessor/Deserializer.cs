namespace MusicHub.DataProcessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;

    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            //1. Deserialize to DTO
            var writerDtos = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            var sb = new StringBuilder();
            var validWriters = new List<Writer>();

            //2. Validation check
            foreach (var dto in writerDtos)
            {
                if (IsValid(dto))
                {
                    var writer = new Writer
                    {
                        Name = dto.Name,
                        Pseudonym = dto.Pseudonym,
                    };

                    validWriters.Add(writer);
                    sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            // Add To DB
            context.Writers.AddRange(validWriters);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            //1. Deserialize to DTO
            var producerDtos = JsonConvert.DeserializeObject<ImportProducersAlbums[]>(jsonString);

            var sb = new StringBuilder();
            var validProducers = new List<Producer>();

            //2. Validation check
            foreach (var dto in producerDtos)
            {
                if (IsValid(dto) && dto.Albums.All(IsValid))
                {
                    var producer = new Producer
                    {
                        Name = dto.Name,
                        Pseudonym = dto.Pseudonym,
                        PhoneNumber = dto.PhoneNumber,
                        Albums = dto.Albums.Select(a => new Album
                        {
                            Name = a.Name,
                            ReleaseDate = DateTime.ParseExact(a.ReleaseDate,"dd/MM/yyyy", CultureInfo.InvariantCulture),
                        })
                        .ToArray()
                    };

                    validProducers.Add(producer);

                    if (!String.IsNullOrEmpty(producer.PhoneNumber))
                    {
                        sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count));
                    }
                    else
                    {
                        sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));
                    }
                    
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            // Add To DB
            context.Producers.AddRange(validProducers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            //1. Call the serializer
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportSongDto[]),
                new XmlRootAttribute("Songs"));

            //2. Deserialize
            var songDtos = (ImportSongDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<Song> songs = new List<Song>();

            HashSet<int> albumIds = context.Albums.Select(x => x.Id).ToHashSet();
            HashSet<int> writerIds = context.Writers.Select(x => x.Id).ToHashSet();

            //3. Go through each DTO object
            foreach (var dto in songDtos)
            {
                //4. Validate each songDTO
                //5. Validate enum
                //6. Validate albums
                //7. Validate writers

                bool isValidDto = IsValid(dto);
                bool isValidEnum = Enum.TryParse<Genre>(dto.Genre, out Genre validGenreEnum);
                bool isValidAlbum = albumIds.Any(x => x == dto.AlbumId);
                bool isValidWriter = writerIds.Any(x => x == dto.WriterId);

                if (!IsValid(dto) 
                    || !isValidEnum
                    || !isValidAlbum
                    || !isValidWriter)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //9. Create the Song object
                var song = new Song
                {
                    Name = dto.Name,
                    Duration = TimeSpan.Parse(dto.Duration),
                    CreatedOn = DateTime.ParseExact(dto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = validGenreEnum,
                    AlbumId = dto?.AlbumId,
                    WriterId = dto.WriterId,
                    Price = dto.Price
                };

                //10. Add to the collection
                songs.Add(song);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre.ToString(), song.Duration.ToString()));
            }

            //11. Add the collection of Purchases in the Database
            context.Songs.AddRange(songs);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            //1. Call the serializer
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportSongPerformer[]),
                new XmlRootAttribute("Performers"));

            //2. Deserialize
            var performerDtos = (ImportSongPerformer[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var performers = new List<Performer>();

            HashSet<int> validSongs = context.Songs.Select(x => x.Id).ToHashSet();

            //3. Go through each DTO object
            foreach (var dto in performerDtos)
            {
                //4. Validate each performerDTO
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool allSongsExist = dto.PerformersSongs
                    .Select(s => s.Id)
                    .All(x => validSongs.Contains(x));

                if (!allSongsExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //9. Create the Performer object
                var performer = new Performer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    NetWorth = dto.NetWorth,
                    PerformerSongs = dto.PerformersSongs.Select(x => new SongPerformer 
                    {
                        SongId = x.Id
                    })
                    .ToArray()
                };

                //10. Add to the collection
                performers.Add(performer);
                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Count));
            }

            //11. Add the collection of Purchases in the Database
            context.Performers.AddRange(performers);
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
    }
}