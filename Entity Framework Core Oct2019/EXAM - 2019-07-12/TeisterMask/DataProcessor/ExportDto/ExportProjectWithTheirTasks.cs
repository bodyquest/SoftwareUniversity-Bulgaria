﻿namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ExportProjectWithTheirTasks
    {
        [XmlAttribute("TaskCount")]
        public int TaskCount { get; set; }

        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public ExportProjectTask[] Tasks { get; set; }
    }

    [XmlType("Task")]
    public class ExportProjectTask
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Label")]
        public string Label { get; set; }
    }
}
