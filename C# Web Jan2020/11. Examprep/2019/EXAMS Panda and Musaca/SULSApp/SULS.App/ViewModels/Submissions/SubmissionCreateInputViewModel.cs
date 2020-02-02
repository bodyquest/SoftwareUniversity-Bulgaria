namespace SULS.App.ViewModels.Submissions
{
    using SIS.MvcFramework.Attributes.Validation;

    public class SubmissionCreateInputViewModel
    {
        private const string CodeErrorMessage = "Codebase should be between 30, 800 symbols!";

        [RequiredSis]
        [StringLengthSis(30, 800, CodeErrorMessage)]
        public string Code { get; set; }

        public string ProblemId { get; set; }
    }
}
