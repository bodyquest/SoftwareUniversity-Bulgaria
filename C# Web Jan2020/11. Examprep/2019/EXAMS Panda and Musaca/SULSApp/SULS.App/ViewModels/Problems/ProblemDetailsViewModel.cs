namespace SULS.App.ViewModels.Problems
{
    using System.Collections.Generic;

    using SULS.App.ViewModels.Submissions;

    public class ProblemDetailsViewModel
    {
        public string Name { get; set; }

        public int MaxPoints { get; set; }

        public IEnumerable<SubmissionViewModel> Submissions { get; set; }
    }
}
