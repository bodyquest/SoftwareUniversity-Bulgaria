namespace SULS.App.Controllers
{
    using System.Linq;

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
        private readonly ISubmissionService submissionService;

        public ProblemsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
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

            this.problemService.CreateProblem(problemCreateInputViewModel.Name, problemCreateInputViewModel.Points);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var name = this.problemService.GetProblemById(id).Name;

            var submission = this.submissionService.GetAllSubmissions(id)
                .Select(x => new ProblemDetailsViewModel()
                {
                    SubmissionId = x.Id,
                    AchievedResult = x.AchievedResult,
                    MaxPoints = x.Problem.Points,
                    CreatedOn = x.CreatedOn,
                    Username = x.User.Username
                }).ToList();

            var allSubmissions = new ProblemSubmissionsViewModel() { Name = name, Submissions = submission };


            return this.View(allSubmissions);
        }
    }
}
