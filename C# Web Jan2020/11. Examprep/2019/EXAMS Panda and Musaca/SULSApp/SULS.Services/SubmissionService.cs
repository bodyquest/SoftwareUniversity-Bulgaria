namespace SULS.Services
{
    using System;
    using System.Linq;
    using SULS.Data;
    using SULS.Models;

    public class SubmissionService : ISubmissionService
    {
        private readonly SulsAppDbContext context;
        private readonly IProblemService problemService;

        public SubmissionService(SulsAppDbContext context, IProblemService problemService)
        {
            this.context = context;
            this.problemService = problemService;
        }

        private Submission GetSubmissionById(string submissionId)
        {
            Submission submission= this.context.Submissions.Find(submissionId);

            return submission;
        }

        public string CreateSubmission(string code, string userId, string problemId)
        {
            int problemPoints = this.problemService.GetProblemById(problemId).Points;
            Random random = new Random();
            int achievedResult = random.Next(0, problemPoints);

            var submission = new Submission
            {
                Code = code,
                CreatedOn = DateTime.UtcNow,
                ProblemId = problemId,
                UserId = userId,
                AchievedResult = achievedResult
            };

            this.context.Submissions.Add(submission);
            this.context.SaveChanges();

            return submission.Id;
        }

        public bool DeleteSubmissionById(string submissionId)
        {
            Submission submissionToDelete = this.GetSubmissionById(submissionId);

            this.context.Submissions.Remove(submissionToDelete);

            int deleteResult = this.context.SaveChanges();

            if (deleteResult != 0)
            {
                return true;
            }

            return false;
        }

        public IQueryable<Submission> GetAllSubmissions(string id)
        {
            var submissions = this.context.Submissions.Where(x => x.ProblemId == id);

            return submissions;
        }
    }
}
