using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public class Task
    {
        public int Number { get; set; }
        public double Value { get; set; }
        public double Deadline { get; set; }
        public bool IsCompleted { get; set; }

        public Task(int number, double value, double deadline)
        {
            Number = number;
            Value = value;
            Deadline = deadline;
            IsCompleted = false;
        }
    }

    public static void Main()
    {
        List<Task> tasks = new List<Task>();

        int tasksCount = int.Parse(Console.ReadLine().Split().ToArray()[1]);

        for (int i = 0; i < tasksCount; i++)
        {
            string[] taskInfo = Console.ReadLine().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Task task = new Task(i + 1, double.Parse(taskInfo[0]), double.Parse(taskInfo[1]));
            tasks.Add(task);
        }

        double maxDeadline = tasks.Select(x => x.Deadline).Max();
        int currentTick = 0;

        List<Task> finished = new List<Task>();
        while (currentTick != maxDeadline)
        {

            var mostValuableTasks = tasks.Where(t => !t.IsCompleted && t.Deadline > currentTick)
                .OrderByDescending(t => t.Value / (t.Deadline - currentTick)).ToList();

            var currentTask = mostValuableTasks.First();
            
            currentTask.IsCompleted = true;
            finished.Add(currentTask);

            currentTick++;
        }

        Console.WriteLine("Optimal schedule: " + string.Join(" -> ", finished.Select(t => t.Number)));
        Console.WriteLine("Total value: " + finished.Sum(t => t.Value));
    }
}
