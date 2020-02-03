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
        public IActionResult Create(string Id)
        {
            var problem = this.problemService.GetProblemById(Id);

            if (problem == null)
            {
                this.Redirect("/");
            }

            var viewModel = new SubmissionCreateViewModel()
            {
                Name = problem.Name,
                ProblemId = problem.Id
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(SubmissionCreateInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"/Submissions/Create?id={inputModel.ProblemId}");
            }

            var problem = this.problemService.GetProblemById(inputModel.ProblemId);
            if (problem == null)
            {
                return this.Redirect("/Submissions/Create");
            }

            this.submissionService.CreateSubmission(inputModel.Code, this.User.Id, inputModel.ProblemId);

            return this.Redirect("/");
        }

        [Authorize]
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
