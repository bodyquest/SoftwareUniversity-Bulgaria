namespace CommandPattern.Core.Commands
{
    using System.Linq;

    using CommandPattern.Core.Contracts;

    public class SumCommand : ICommand
    {
        public string Execute(string[] args)
        {
            var array = args
                .Select(int.Parse)
                .ToArray();

            long sum = array
                .Sum(n => n);

            return $"Current Sum: {sum}";
        }
    }
}
