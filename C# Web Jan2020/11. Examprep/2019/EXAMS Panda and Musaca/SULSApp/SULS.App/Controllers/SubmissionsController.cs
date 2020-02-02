namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using SULS.App.ViewModels.Submissions;
    using SULS.Services;

    public class SubmissionsController : Controller
    {
        private readonly ISubmissionService submissionService;
        private readonly IProblemService problemService;

        public SubmissionsController(ISubmissionService submissionService, IProblemService problemService)
        {
            this.submissionService = submissionService;
            this.problemService = problemService;
        }

        [Authorize]
        public IActionResult Create(string problemId)
        {
            var problem = this.problemService.GetProblemById(problemId);

            var viewModel = new SubmissionCreateViewModel()
            {
                Name = problem.Name,
                ProblemId = problemId
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(SubmissionCreateInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"/Sbmissions/Create");
            }

            this.submissionService.CreateSubmission(inputModel.Code, this.User.Id, inputModel.ProblemId);

            return this.Redirect("/");
        }

        public IActionResult Delete(string submissionId)
        {
            if (submissionId == null)
            {
                return this.Redirect("/");

            }

            this.submissionService.DeleteSubmissionById(submissionId);

            return this.Redirect("/");
        }
    }
}
