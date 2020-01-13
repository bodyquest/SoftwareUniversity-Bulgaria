namespace SIS.MvcFramework.Extensions
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public static class ObjectExtensions
    {
        public static string ToXml(this object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());

                serializer.Serialize(stringWriter, obj);

                return stringWriter.ToString();
            }
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings 
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
    }
}
