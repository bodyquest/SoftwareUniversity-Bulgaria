namespace MusicHub.DataProcessor
{
    using System.IO;
    using System.Xml;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Data;

    using Newtonsoft.Json;
    using MusicHub.DataProcessor.ExportDtos;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("F2"),
                        Writer = s.Writer.Name
                    })
                    .OrderByDescending(x => x.SongName)
                    .ThenBy(x => x.Writer)
                    .ToArray(),
                    AlbumPrice = a.Songs.Sum(x => x.Price).ToString("F2")
                })
                .OrderByDescending(x => decimal.Parse(x.AlbumPrice))
                .ToArray();

            var jsonSerialized = JsonConvert.SerializeObject(albums, Newtonsoft.Json.Formatting.Indented);

            return jsonSerialized;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExportSongDto[]), new XmlRootAttribute("Songs"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            var songs = context.Songs
                .Where(s => s.Duration.TotalSeconds >= duration)
                .Select(s => new ExportSongDto
                {
                    Name = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers.Select(x => $"{x.Performer.FirstName} {x.Performer.LastName}").FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Writer)
                .ThenBy(x => x.Performer)
                .ToArray();

            serializer.Serialize(new StringWriter(sb), songs, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}