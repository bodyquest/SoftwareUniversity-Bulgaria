namespace PetClinic.DataProcessor
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Linq;
    using System.Xml.Serialization;
    using Microsoft.EntityFrameworkCore;
    using PetClinic.Data;

    using Newtonsoft.Json;
    using System.Text;
    using PetClinic.ExportDto;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals
                .Where(a => a.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(a => new
                    {
                        OwnerName = a.Passport.OwnerName,
                        AnimalName = a.Name,
                        Age = a.Age,
                        SerialNumber = a.PassportSerialNumber,
                        RegisteredOn = a.Passport.RegistrationDate.ToString("dd-MM-yyyy")
                })
                    .OrderBy(x => x.Age)
                    .ThenBy(x => x.SerialNumber)
                    .ToArray();

            var jsonSerialized = JsonConvert.SerializeObject(animals, Newtonsoft.Json.Formatting.Indented);

            return jsonSerialized;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                .Select(x => new ExportprocedureDto
                {
                    Passport = x.Animal.PassportSerialNumber,
                    OwnerNumber = x.Animal.Passport.OwnerPhoneNumber,
                    DateTime = x.DateTime.ToString("dd-MM-yyyy"),
                    AnimalAids = x.ProcedureAnimalAids.Select(y => new AnimalAidDto
                    {
                        Name = y.AnimalAid.Name,
                        Price = y.AnimalAid.Price.ToString("F2")
                    })
                    .ToArray(),
                    TotalPrice = x.ProcedureAnimalAids.Sum(y => y.AnimalAid.Price).ToString("F2")
                })
                .OrderBy(x => DateTime.ParseExact(x.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .ThenBy(x => x.Passport)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportprocedureDto[]), new XmlRootAttribute("Procedures"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), procedures, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
