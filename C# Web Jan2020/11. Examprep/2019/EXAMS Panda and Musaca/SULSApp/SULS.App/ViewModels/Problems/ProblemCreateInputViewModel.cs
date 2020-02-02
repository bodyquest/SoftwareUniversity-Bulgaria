namespace SULS.App.ViewModels.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SIS.MvcFramework.Attributes.Validation;

    public class ProblemCreateInputViewModel
    {
        private const string NameErrorMessage = "Invalid name length! Must be between 5 and 20 symbols!";

        [RequiredSis]
        [StringLengthSis(5, 20, NameErrorMessage)]
        public string Name { get; set; }

        public int TotalPoints { get; set; }
    }
}
