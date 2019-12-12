namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(p => p.Tasks.Count > 0)
                .Select(p => new ExportProjectDto
                {
                    TaskCount = p.Tasks.Count(),
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null 
                    ? "No"
                    : "Yes",
                    Tasks = p.Tasks.Select(t => new ExportTaskDto 
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TaskCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;

            var employees = context.Employees
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .OrderByDescending(e => e.EmployeesTasks.Count(t => t.Task.OpenDate >= date))
                .ThenBy(e => e.Username)
                .Select(e => new ExportEmployeeDto
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(et => et.Task.OpenDate >= date)
                    .Select(et => new ExportEmployeeTaskDto 
                    { 
                        TaskName = et.Task.Name,
                        OpenDate = et.Task.OpenDate.ToString("MM/dd/yyyy"),
                        DueDate = et.Task.DueDate.ToString("MM/dd/yyyy"),
                        LabelType = et.Task.LabelType.ToString(),
                        ExecutionType = et.Task.ExecutionType.ToString()
                    })
                    .OrderByDescending(t => DateTime.ParseExact(t.DueDate, "MM/dd/yyyy", ci))
                    .ThenBy(t => t.TaskName)
                    .ToList()
                })
                .Take(10)
                .ToList();

            var jsonSerialized = JsonConvert.SerializeObject(employees, Newtonsoft.Json.Formatting.Indented);

            return jsonSerialized;
        }
    }
}