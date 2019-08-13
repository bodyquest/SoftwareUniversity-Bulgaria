using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public class Lecture
    {
        public string Name { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }

        public Lecture(string name, int start, int finish)
        {
            Name = name;
            Start = start;
            Finish = finish;
        }

        public override string ToString()
        {
            return $"{Start}-{Finish} -> {Name}";
        }
    }

    public static void Main()
    {
        List<Lecture> lectures = new List<Lecture>();
        int lecturesCount = int.Parse(Console.ReadLine().Split().ToArray()[1]);

        for (int i = 0; i < lecturesCount; i++)
        {
            string[] lectureInfo = Console.ReadLine().Split().ToArray();
            string name = lectureInfo[0].Replace(":", "");
            int start = int.Parse(lectureInfo[1]);
            int finish = int.Parse(lectureInfo[3]);

            Lecture lecture = new Lecture(name, start, finish);
            lectures.Add(lecture);
        }
        
        List<Lecture> result = new List<Lecture>();

        while (lectures.Count != 0)
        {
            var currentLecture = lectures.OrderBy(l => l.Finish).First();
            result.Add(currentLecture);
            lectures = lectures.Where(l => l.Start >= currentLecture.Finish).ToList();
        }

        Console.WriteLine($"Lectures ({result.Count}):");
        foreach (var lecture in result)
        {
            Console.WriteLine(lecture);
        }
    }
}
