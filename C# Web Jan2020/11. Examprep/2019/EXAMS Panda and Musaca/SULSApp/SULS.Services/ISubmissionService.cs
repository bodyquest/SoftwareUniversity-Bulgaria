namespace SULS.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISubmissionService
    {
        string CreateSubmission(string code, string userId, string problemId);

        bool DeleteSubmissionById(string submissionId);
    }
}
