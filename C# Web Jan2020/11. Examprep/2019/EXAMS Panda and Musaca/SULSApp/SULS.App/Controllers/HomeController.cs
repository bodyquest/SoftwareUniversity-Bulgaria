namespace SULS.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;
    using SULS.App.ViewModels.Home;
    using SULS.Services;

    public class HomeController : Controller
    {
        private readonly IProblemService problemService;

        public HomeController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {

            if (this.IsLoggedIn())
            {
                var allProblemsViewModel = new List<AllProblemsHomeViewModel>();

                allProblemsViewModel = this.problemService
                    .GetAllProblems()
                    .Select(x => new AllProblemsHomeViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        SubmissionCount = x.Submissions.Count
                    }).ToList();

                return this.View(allProblemsViewModel, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}
