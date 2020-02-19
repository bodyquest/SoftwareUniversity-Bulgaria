using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _02.DemoCoreMVCApp.Models;
using _02.DemoCoreMVCApp.Data;
using _02.DemoCoreMVCApp.Models.Home;
using _02.DemoCoreMVCApp.Services;

namespace _02.DemoCoreMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersService usersService;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, IUsersService usersService)
        {
            _logger = logger;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            var usernames = this.usersService.GetUsernames();
            var viewModel = new IndexViewModel {Usernames = usernames };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
