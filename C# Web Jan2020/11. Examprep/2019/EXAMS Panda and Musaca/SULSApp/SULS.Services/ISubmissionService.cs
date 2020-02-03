namespace SULS.Services
{
    using SULS.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ISubmissionService
    {
        string CreateSubmission(string code, string userId, string problemId);

        IQueryable<Submission> GetAllSubmissions(string id);

        bool DeleteSubmissionById(string submissionId);
    }
}
