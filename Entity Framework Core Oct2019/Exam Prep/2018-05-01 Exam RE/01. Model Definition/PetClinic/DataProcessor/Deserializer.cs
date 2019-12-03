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
            throw new NotImplementedException();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new DataValidation.ValidationContext(obj);
            var validationResults = new List<DataValidation.ValidationResult>();

            return DataValidation.Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }

        //private static bool IsPassportValid(PassportDto passport)
        //{
        //    if (!IsValid(passport))
        //        return false;

        //    var ownerPhoneNumber = passport.OwnerPhoneNumber;

        //    return IsPhoneNumberValid(ownerPhoneNumber);
        //}

        //private static bool IsPhoneNumberValid(string phoneNumber)
        //{
        //    var regexFirstPattern = @"(\+359)[0-9]{9}";
        //    var regexSecondPattern = @"(0)[0-9]{9}";

        //    bool firstTypePhoneNumber = Regex.IsMatch(phoneNumber, regexFirstPattern);
        //    bool secondTypePhoneNumber = Regex.IsMatch(phoneNumber, regexSecondPattern);

        //    return firstTypePhoneNumber || secondTypePhoneNumber;
        //}
    }
}
