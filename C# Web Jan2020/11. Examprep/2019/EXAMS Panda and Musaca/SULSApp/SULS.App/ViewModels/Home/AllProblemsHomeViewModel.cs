namespace SULS.App.ViewModels.Home
{
    using SIS.MvcFramework.Attributes.Validation;
    using System.Collections.Generic;

    public class AllProblemsHomeViewModel
    {
        private const string NameErrorMessage = "Invalid username length! Must be between 5 and 20 symbols!";

        public string Id { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, NameErrorMessage)]
        public string Name { get; set; }

        public int SubmissionCount { get; set; }
    }
}
