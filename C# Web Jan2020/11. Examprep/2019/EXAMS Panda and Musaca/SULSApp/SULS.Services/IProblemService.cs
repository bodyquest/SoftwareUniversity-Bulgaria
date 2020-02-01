namespace SULS.Services
{
    using SULS.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IProblemService
    {
        string CreateProblem(string name, int points);

        IEnumerable<Problem> GetAllProblems();

        Problem GetProblemById(string problemId);
    }
}
