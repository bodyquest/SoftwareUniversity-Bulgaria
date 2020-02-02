namespace SULS.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using SULS.App.ViewModels.Problems;
    using SULS.App.ViewModels.Submissions;
    using SULS.Services;

    public class ProblemsController : Controller
    {
        private readonly IUserService userService;
        private readonly IProblemService problemService;

        public ProblemsController(IUserService userService, IProblemService problemService)
        {
            this.userService = userService;
            this.problemService = problemService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ProblemCreateInputViewModel problemCreateInputViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemService.CreateProblem(problemCreateInputViewModel.Name, problemCreateInputViewModel.TotalPoints);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var problem = this.problemService.GetProblemById(id);

            var viewModel = new ProblemDetailsViewModel
            {
                Name = problem.Name,
                MaxPoints = problem.Points,
                Submissions = problem.Submissions.Select(s => new SubmissionViewModel
                {
                    Username = s.User.Username,
                    AchievedResult = s.AchievedResult,
                    CreatedOn = s.CreatedOn.ToString("dd/MM/yyyy"),
                    SubmissionId = s.Id
                })
            };

            return this.View(viewModel);
        }
    }
}
