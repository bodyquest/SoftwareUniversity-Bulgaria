namespace SoftJail.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Data;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System.Globalization;
    using System.Xml.Serialization;
    using SoftJail.Data.Models.Enums;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString) 
        {
            Department[] allDepartments = JsonConvert.DeserializeObject<Department[]>(jsonString);

            var validDepartments = new List<Department>();
            var sb = new StringBuilder();

            foreach (var dept in allDepartments)
            {
                var isValid = IsValid(dept) && dept.Cells.All(IsValid);

                if (isValid)
                {
                    // Add Department to valid Departments
                    validDepartments.Add(dept);
                    sb.AppendLine($"Imported {dept.Name} with {dept.Cells.Count} cells");
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }


        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDtos = JsonConvert.DeserializeObject<ImportPrisonersMailsDto[]>(jsonString);

            var sb = new StringBuilder();
            var validPrisoners = new List<Prisoner>();

            //2. Validation check
            foreach (var dto in prisonersDtos)
            {
                var isValid = IsValid(dto) &&
                    dto.FullName != null &&
                    dto.Mails.All(IsValid);

                if (isValid)
                {
                    var prisoner = new Prisoner
                    {
                        FullName = dto.FullName,
                        Nickname = dto.Nickname,
                        Age = dto.Age,
                        IncarcerationDate = DateTime.ParseExact(dto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ReleaseDate = dto.ReleaseDate == null
                            ? new DateTime?()
                            : DateTime.ParseExact(dto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Bail = dto.Bail,
                        CellId = dto.CellId,
                        Mails = dto.Mails.Select(m => new Mail
                        {
                            Description = m.Description,
                            Sender = m.Sender,
                            Address = m.Address
                        })
                        .ToArray()
                    };

                    validPrisoners.Add(prisoner);
                    sb.AppendLine($"Imported {dto.FullName} {dto.Age} years old");
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportOfficersPrisoners[]),
                new XmlRootAttribute("Officers"));

            var officersPrisonersDtos = (ImportOfficersPrisoners[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var officersPrisoners = new List<Officer>();

            foreach (var officerPrisonerDto in officersPrisonersDtos)
            {
                if (!IsValid(officerPrisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidEnumPosition = Enum.TryParse<Position>(officerPrisonerDto.Position, out Position officerPosition);

                var isValidEnumWeapon = Enum.TryParse<Weapon>(officerPrisonerDto.Weapon, out Weapon officerWeapon);

                if (!isValidEnumPosition)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                if (!isValidEnumWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officerPrisoner = new Officer
                {
                    FullName = officerPrisonerDto.Position,
                    Salary = officerPrisonerDto.Money,
                    Position = officerPosition,
                    Weapon = officerWeapon,
                    DepartmentId = officerPrisonerDto.DepartmentId,
                    OfficerPrisoners = officerPrisonerDto.Prisoners.Select(x => new OfficerPrisoner 
                    {
                        PrisonerId = x.Id
                    })
                    .ToArray()
                };

                officersPrisoners.Add(officerPrisoner);
                sb.AppendLine($"Imported {officerPrisonerDto.Name} ({officerPrisonerDto.Prisoners.Count()} prisoners)");
            }

            context.Officers.AddRange(officersPrisoners);
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