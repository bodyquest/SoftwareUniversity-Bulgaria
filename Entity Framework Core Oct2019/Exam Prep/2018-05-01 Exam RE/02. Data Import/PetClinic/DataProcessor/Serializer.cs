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

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            throw new NotImplementedException();
        }
    }
}
