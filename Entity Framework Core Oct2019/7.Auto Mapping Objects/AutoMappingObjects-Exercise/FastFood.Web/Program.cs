namespace FastFood.Web
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            bool PISHTOV = true;
            while (PISHTOV)
            {
                //1.Get into Controller Class

                //2. GET Method (Register/ Create etc)
                // It shoudl return a view (corresponding to the Model). Say Employees Register returns view form for registration
                //The Employee View has Register view file. It expects from the top, to get a RegisterEmployeeViewModel. This RegisterEmployeeViewModel needs PositionId, which we get from Position model.
                //2.1 returns this.View()
                //2.2 We get to the FastFoodProfile to add mapper, Mapping form Position to registerEmployeeViewModel on Id
                //this.CreateMap<Position, RegisterEmployeeViewModel>().ForMember(x => x.PositionId, y => y.Mapfrom(x => x.Id));
                //2.3 We map all positions to give them to the view in the return statement.
                // var positions = this.context
                //.Positions
                //.ProjectTo<RegisterEmployeeViewModel>(this.mapper.ConfigurationProvider)
                //.ToList();
                //2.4 We pass the positions to the view
                // return this.View(positions);

                //3. POST method IActionResult Register
                //3.1 Check if the model state is valid, redirect to Error method of Home controller
                //3.2 WE HAVE OT MAP THEM in FastFoodProfile
                //this.CreateMap<RegisterEmployeeInputModel, Employee>();
                //3.3 Map employee to model
                // var employee = mapper.Map<Employee>(model);
                //3.4 Add him to the database
                // this.context.Employees.Add(employee);
                // Save changes
                //Return to All/Employees

                //4. WE GO TO ViewModels.Employees.EmployeesAllViewModel
                //It requires mapping from employee to EmployeesAllViewModel
                // this.CreateMap<Employee, EmployeesAllViewModel>()
                //.ForMember(x => x.Position, y => y.MapFrom(x => x.Position.Name));
                //4.1 We get in the IActionResult All() method all employees by mapping them to EmployeesAllViewModel
                //var employees = this.context
                //.Employees
                //.ProjectTo<EmployeesAllViewModel>(this.mapper.ConfigurationProvider)
                //.ToList();
                //Return the view with the list of employees as parameter

            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
