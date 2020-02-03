namespace SULS.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using SULS.Models;

    public interface IProblemService
    {
        string CreateProblem(string name, int points);

        IQueryable<Problem> GetAllProblems();

        Problem GetProblemById(string problemId);
    }
}
