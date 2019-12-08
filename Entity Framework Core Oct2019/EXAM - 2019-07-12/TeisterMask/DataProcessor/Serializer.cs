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
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            //throw new NotImplementedException();
            var projects = context.Projects
                .Where(p => p.Tasks.Count >= 1)
                .Select(p => new ExportProjectWithTheirTasks
                {
                    TaskCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new ExportProjectTask
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

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProjectWithTheirTasks[]), new XmlRootAttribute("Projects"));

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
            //throw new NotImplementedException();

            var employees = context.Employees
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .OrderByDescending(x => x.EmployeesTasks.Count(t => t.Task.OpenDate >= date))
                .ThenBy(e => e.Username)
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                            .Where(t => t.Task.OpenDate >= date)
                            .Select(x => new
                            {
                                TaskName = x.Task.Name,
                                OpenDate = x.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                DueDate = x.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                LabelType = x.Task.LabelType.ToString(),
                                ExecutionType = x.Task.LabelType.ToString()
                            })
                    .OrderByDescending(x => DateTime.ParseExact(x.DueDate, "d", CultureInfo.InvariantCulture))
                    .ThenBy(x => x.TaskName)
                    .ToArray()
                })
                .Take(10)
                .ToArray();

            var jsonSerialized = JsonConvert.SerializeObject(employees, Newtonsoft.Json.Formatting.Indented);

            return jsonSerialized;
        }
    }
}