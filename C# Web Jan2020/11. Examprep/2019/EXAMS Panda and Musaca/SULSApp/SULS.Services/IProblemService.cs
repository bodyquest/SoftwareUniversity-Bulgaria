namespace SULS.Services
{
    using System.Collections.Generic;

    using SULS.Models;

    public interface IProblemService
    {
        string CreateProblem(string name, int points);

        IEnumerable<Problem> GetAllProblems();

        Problem GetProblemById(string problemId);
    }
}
