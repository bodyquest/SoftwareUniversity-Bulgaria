﻿namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ExportCategoryDto
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "count")]
        public int Count { get; set; }

        [XmlElement(ElementName = "averagePrice")]
        public decimal AveragePrice { get; set; }

        [XmlElement(ElementName = "totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
