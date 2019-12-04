namespace PetClinic.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using PetClinic.Data;
    using PetClinic.Models;
    using DataValidation = System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;
    using PetClinic.ImportDto;

    public class Deserializer
    {
        public const string Failure_Message = "Error: Invalid data.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            //1. Deserialize to DTO
            var animalAidsDtos = JsonConvert.DeserializeObject<ImportAnimalAidDto[]>(jsonString);

            var sb = new StringBuilder();
            var validAnimalAids = new List<AnimalAid>();

            //2. Validation check
            foreach (var dto in animalAidsDtos)
            {
                bool validAnimalAid = validAnimalAids.Any(ai => ai.Name == dto.Name);

                if (validAnimalAid == true)
                {
                    continue;
                }

                if (IsValid(dto))
                {
                    var animalAid = new AnimalAid
                    {
                        Name = dto.Name,
                        Price = dto.Price,
                    };

                    validAnimalAids.Add(animalAid);
                    sb.AppendLine($"Record {dto.Name} successfully imported.");
                }
                else
                {
                    sb.AppendLine(Failure_Message);
                }
            }

            // Add To DB
            context.AnimalAids.AddRange(validAnimalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            //1. Deserialize to DTO
            var animalDtos = JsonConvert.DeserializeObject<ImportAnimalDto[]>(jsonString);

            var sb = new StringBuilder();
            var validAnimals = new List<Animal>();
            var validPassports = new List<Passport>();

            //2. Validation check
            foreach (var dto in animalDtos)
            {
                bool passportExists = validAnimals
                    .Select(x => x.Passport)
                    .Any(x => x.SerialNumber == dto.Passport.SerialNumber);

                if (IsValid(dto) && IsValid(dto.Passport) && !passportExists)
                {
                    var animal = new Animal
                    {
                        Name = dto.Name,
                        Type = dto.Type,
                        Age = dto.Age,
                        Passport = new Passport
                        {
                            SerialNumber = dto.Passport.SerialNumber,
                            OwnerName = dto.Passport.OwnerName,
                            OwnerPhoneNumber = dto.Passport.OwnerPhoneNumber,
                            RegistrationDate = DateTime.ParseExact(dto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                        }
                    };

                    validAnimals.Add(animal);
                    sb.AppendLine($"Record {dto.Name} Passport #: {dto.Passport.SerialNumber} successfully imported.");
                }
                else
                {
                    sb.AppendLine(Failure_Message);
                }
            }

            // Add To DB
            context.Animals.AddRange(validAnimals);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            //1. Call the serializer
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportVetDto[]),
                new XmlRootAttribute("Vets"));

            //2. Deserialize
            var vetDtos = (ImportVetDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var validVets = new List<Vet>();

            //3. Go through each DTO object
            foreach (var dto in vetDtos)
            {
                bool vetPhoneExists = validVets.Any(x => x.PhoneNumber == dto.PhoneNumber);

                if (vetPhoneExists)
                {
                    continue;
                }

                //4. Validate each purchaseDTO
                if (!IsValid(dto))
                {
                    sb.AppendLine(Failure_Message);
                    continue;
                }

                //9. Create the Purchase object
                var vet = new Vet
                {
                    Name = dto.Name,
                    Profession = dto.Profession,
                    Age = dto.Age,
                    PhoneNumber = dto.PhoneNumber
                };

                //10. Add to the collection
                validVets.Add(vet);
                sb.AppendLine($"Record {dto.Name} successfully imported.");
            }

            //11. Add the collection of Purchases in the Database
            context.Vets.AddRange(validVets);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            //1. Call the serializer
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportProcedureDto[]),
                new XmlRootAttribute("Procedures"));

            //2. Deserialize
            var procedureDtos = (ImportProcedureDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var procedures = new List<Procedure>();
            var aids = new List<AnimalAid>();
            var procedureAnimalAids = new List<ProcedureAnimalAid>();

            var allVetsFromDb = context.Vets.ToHashSet();
            var allAnimalsFromDb = context.Animals.ToHashSet();
            var allAnimalAidsFromDb = context.AnimalAids.ToHashSet();

            //3. Go through each DTO object
            foreach (var dto in procedureDtos)
            {
                //4. Validate each procedureDto
                if (!IsValid(dto))
                {
                    sb.AppendLine(Failure_Message);
                    continue;
                }

                //4.1 Check if All Aids in Dto Exist in DB
                var animalAids = dto.AnimalAids;
                bool repeatedAid = false;
                bool allAidsExist = context.AnimalAids.Any(a => animalAids.Any(aa => aa.Name == a.Name));

                aids = new List<AnimalAid>();
                procedureAnimalAids = new List<ProcedureAnimalAid>();

                //4.2 Validate Vet, Animal and AllAids' Exisitance
                var validVet = allVetsFromDb.SingleOrDefault(x => x.Name == dto.VetName);
                var validAnimal = allAnimalsFromDb.SingleOrDefault(x => x.PassportSerialNumber == dto.AnimalSerial);

                if (validVet == null || validAnimal == null || !allAidsExist)
                {
                    sb.AppendLine(Failure_Message);
                    continue;
                }

                //4.3 Check for repeated AnimalAids in current DTO AnimalAids
                foreach (var aid in animalAids) //dto.AnimalAids
                {
                    var aidToAdd = allAnimalAidsFromDb.SingleOrDefault(x => x.Name == aid.Name);

                    if (aids.Contains(aidToAdd))
                    {
                        repeatedAid = true;
                        break;
                    }

                    aids.Add(aidToAdd);
                }

                if (repeatedAid)
                {
                    sb.AppendLine(Failure_Message);
                    continue;
                }

                //*****************************//
                //5. Create the Procedure object
                var procedure = new Procedure
                {
                    Vet = validVet,
                    Animal = validAnimal,
                    DateTime = DateTime.ParseExact(dto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                };

                foreach (var aid in aids)
                {
                    procedureAnimalAids.Add(new ProcedureAnimalAid
                    {
                        AnimalAid = aid,
                        Procedure = procedure
                    });
                }

                procedure.ProcedureAnimalAids = procedureAnimalAids;

                //6.Add to the collection
                procedures.Add(procedure);
                sb.AppendLine($"Record successfully imported.");
            }

            //7. Add the collection of Procedures in the Database
            context.Procedures.AddRange(procedures);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new DataValidation.ValidationContext(obj);
            var validationResults = new List<DataValidation.ValidationResult>();

            return DataValidation.Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
