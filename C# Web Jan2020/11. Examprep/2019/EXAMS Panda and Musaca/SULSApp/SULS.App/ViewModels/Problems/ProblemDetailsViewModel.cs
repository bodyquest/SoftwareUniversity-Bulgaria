namespace SULS.App.ViewModels.Problems
{
    using System;
    using System.Collections.Generic;

    using SULS.App.ViewModels.Submissions;

    public class ProblemDetailsViewModel
    {
        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public int MaxPoints { get; set; }

        public DateTime CreatedOn { get; set; }

        public string SubmissionId { get; set; }
    }
}
