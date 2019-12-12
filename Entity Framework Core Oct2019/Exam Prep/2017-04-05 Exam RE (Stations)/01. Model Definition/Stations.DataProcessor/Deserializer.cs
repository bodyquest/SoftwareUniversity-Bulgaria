using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Stations.Data;
using Stations.DataProcessor.Dto.ImportDto;
using Stations.Models;

namespace Stations.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportStations(StationsDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportClasses(StationsDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportTrains(StationsDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportCards(StationsDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            throw new NotImplementedException();
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