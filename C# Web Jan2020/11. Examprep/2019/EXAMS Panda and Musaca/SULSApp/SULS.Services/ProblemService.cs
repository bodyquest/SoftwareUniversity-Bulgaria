namespace SULS.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using SULS.Data;
    using SULS.Models;

    public class ProblemService : IProblemService
    {
        private readonly SulsAppDbContext context;

        public ProblemService(SulsAppDbContext context)
        {
            this.context = context;
        }

        public string CreateProblem(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points
            };

            this.context.Problems.Add(problem);
            this.context.SaveChanges();

            return problem.Id;
        }

        public IEnumerable<Problem> GetAllProblems()
        {
            List<Problem> problems = this.context.Problems
                .Include(x => x.Submissions).ToList();

                return problems;
        }

        public Problem GetProblemById(string problemId)
        {
            Problem problem = this.context.Problems
                .Include(p => p.Submissions)
                .ThenInclude(x => x.User)
                .SingleOrDefault(p => p.Id == problemId);

            return problem;
        }
    }
}
