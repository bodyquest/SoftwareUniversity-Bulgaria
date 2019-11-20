namespace CarDealer.DTO
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PartCarDto
    {
        [JsonProperty(propertyName: "car")]
        public CarDto Car { get; set; }

        [JsonProperty(propertyName: "parts")]
        public ICollection<PartDto> Parts { get; set; }
    }
}
