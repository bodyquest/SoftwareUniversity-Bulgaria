namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.IO;
    using System.Xml.Serialization;
    using System.Text;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Linq;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            //1. Call the serializer
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportProjectDto[]),
                new XmlRootAttribute("Projects"));

            //2. Deserialize
            var projectDtos = (ImportProjectDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();

            List<Project> projects = new List<Project>();

            CultureInfo ci = CultureInfo.InvariantCulture;

            //3. Go through each DTO object
            foreach (var dto in projectDtos)
            {
                //4. Validate each purchaseDTO
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // Create the Project object
                var project = new Project
                {
                    Name = dto.Name,
                    OpenDate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", ci),
                    //Nullable Date
                    DueDate = string.IsNullOrEmpty(dto.DueDate) ? (DateTime?)null : DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", ci),
                };

                foreach (var task in dto.Tasks)
                {
                    bool isValidTask = IsValid(task);
                    if (!isValidTask)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate = DateTime.ParseExact(task.OpenDate, "dd/MM/yyyy", ci);
                    DateTime taskDueDate = DateTime.ParseExact(task.DueDate, "dd/MM/yyyy", ci);
                    DateTime projectOpenDate = project.OpenDate;
                    DateTime? projectDueDate = project.DueDate;

                    bool IsValidExecType = Enum.IsDefined(typeof(ExecutionType), task.ExecutionType);
                    bool IsValidLabelType = Enum.IsDefined(typeof(LabelType), task.LabelType);

                    if (IsValidExecType == false || IsValidLabelType == false)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ExecutionType execType = (ExecutionType)Enum.ToObject(typeof(ExecutionType), task.ExecutionType);
                    LabelType labelType = (LabelType)Enum.ToObject(typeof(LabelType), task.LabelType);

                    if (taskOpenDate < projectOpenDate || taskDueDate > projectDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task taskObj = new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = execType,
                        LabelType = labelType,
                    };

                    project.Tasks.Add(taskObj);
                }

                // Add to the collection
                projects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            // Add the collection of Projects in the Database
            context.Projects.AddRange(projects);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            //1. Deserialize to DTO
            var employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var sb = new StringBuilder();
            var validEmployees = new List<Employee>();

            //2. Validation check
            foreach (var dto in employeeDtos)
            {
                bool isValidEmployee = IsValid(dto);
                if (isValidEmployee == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Phone = dto.Phone
                };

                List<int> uniqueTasks = dto.Tasks.Distinct().ToList();
                HashSet<int> validTasks = context.Tasks.Select(x => x.Id).ToHashSet<int>();

                foreach (var taskId in uniqueTasks)
                {
                    if (validTasks.Contains(taskId))
                    {
                        employee.EmployeesTasks.Add(new EmployeeTask
                        {
                            TaskId = taskId
                        });
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }

                validEmployees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            // Add To DB
            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}