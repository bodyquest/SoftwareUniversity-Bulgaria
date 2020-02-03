namespace SULS.App.ViewModels.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProblemSubmissionsViewModel
    {
        public ProblemSubmissionsViewModel()
        {
            this.Submissions = new List<ProblemDetailsViewModel>();
        }

        public string Name { get; set; }

        public List<ProblemDetailsViewModel> Submissions { get; set; }
    }
}
