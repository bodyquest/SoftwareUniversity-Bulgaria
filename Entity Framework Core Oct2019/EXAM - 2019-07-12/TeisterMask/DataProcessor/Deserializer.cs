namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using Newtonsoft.Json;
    using System.Text;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Linq;
    using System.Xml.Serialization;
    using System.IO;
    using TeisterMask.Data.Models.Enums;
    using System.Globalization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            //throw new NotImplementedException();

            //1. Call the serializer
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportProjectDto[]),
                new XmlRootAttribute("Projects"));

            //2. Deserialize
            var projectDtos = (ImportProjectDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var validProjects = new List<Project>();

            //3. Go through each DTO object
            foreach (var dto in projectDtos)
            {
                //4. Validate each projectDTO
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var project = new Project
                {
                    Name = dto.Name,
                    OpenDate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //Nullable Date
                    DueDate = string.IsNullOrEmpty(dto.DueDate) ? (DateTime?)null : DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                };

                // TASKS VALIDATION
                foreach (var task in dto.Tasks)
                {
                    bool isValidTask = IsValid(task);
                    bool isValidExecutionType = Enum.IsDefined(typeof(ExecutionType), task.ExecutionType);
                    bool isValidLabelType = Enum.IsDefined(typeof(LabelType), task.LabelType);

                    if (isValidTask == false ||
                        isValidExecutionType == false ||
                        isValidLabelType == false)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate = DateTime.ParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime projectOpenDate = project.OpenDate;
                    DateTime taskDueDate = DateTime.ParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime? projectDueDate = project.DueDate;

                    if (taskOpenDate < projectOpenDate || taskDueDate > projectDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validType = Enum.ToObject(typeof(ExecutionType), task.ExecutionType);
                    var validLabel = Enum.ToObject(typeof(LabelType), task.LabelType);

                    Task taskObj = new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)validType,
                        LabelType = (LabelType)validLabel,
                        Project = project
                    };

                    project.Tasks.Add(taskObj);
                }

                //10. Add to the collection
                validProjects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            //throw new NotImplementedException();

            //1. Deserialize to DTO
            var employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var sb = new StringBuilder();
            var validEmployees = new List<Employee>();

            //2. Validation check
            foreach (var dto in employeeDtos)
            {
                if (IsValid(dto))
                {
                    var employee = new Employee
                    {
                        Username = dto.Username,
                        Email = dto.Email,
                        Phone = dto.Phone,
                    };

                    foreach (var taskId in dto.Tasks.Distinct())
                    {
                        if (context.Tasks.Find(taskId) == null)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        EmployeeTask employeeTask = new EmployeeTask
                        {
                            TaskId = taskId
                        };

                        employee.EmployeesTasks.Add(employeeTask);
                    }

                    validEmployees.Add(employee);
                    sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count)); // TODO Check if CORRECT
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
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