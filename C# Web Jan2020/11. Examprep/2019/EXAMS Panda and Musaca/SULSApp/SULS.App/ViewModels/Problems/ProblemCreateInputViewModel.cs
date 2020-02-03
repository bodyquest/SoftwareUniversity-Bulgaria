namespace SULS.App.ViewModels.Problems
{
    using SIS.MvcFramework.Attributes.Validation;

    public class ProblemCreateInputViewModel
    {
        private const string NameErrorMessage = "Invalid name length! Must be between 5 and 20 symbols!";

        private const string TotalPointsErrorMessage = "Problem totla points should be between 50 and 300!";

        [RequiredSis]
        [StringLengthSis(5, 20, NameErrorMessage)]
        public string Name { get; set; }


        [RequiredSis]
        [RangeSis(50, 300, TotalPointsErrorMessage)]
        public int Points { get; set; }
    }
}
