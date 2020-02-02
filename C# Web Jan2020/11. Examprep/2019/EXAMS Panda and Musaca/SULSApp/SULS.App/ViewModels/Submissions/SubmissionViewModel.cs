namespace SULS.App.ViewModels.Submissions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SubmissionViewModel
    {
        public string SubmissionId { get; set; }

        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public string CreatedOn { get; set; }
    }
}
