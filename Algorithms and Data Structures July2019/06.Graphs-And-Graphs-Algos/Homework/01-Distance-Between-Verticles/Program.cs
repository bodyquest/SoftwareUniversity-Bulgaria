using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
    static Dictionary<int, bool> visited = new Dictionary<int, bool>();
    public static void Main()
    {
        int vertices = int.Parse(Console.ReadLine());
        int pairsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < vertices; i++)
        {
            string line = Console.ReadLine();
            string[] relations = line.Split(':').ToArray();
            int parent = int.Parse(relations[0]);

            if (relations[1] == "")
            {
                graph.Add(parent, new List<int>());
            }
            else
            {
                int[] children = relations[1].Split().Select(int.Parse).ToArray();
                graph.Add(parent, children.ToList());
            }
        }

        for (int i = 0; i < pairsCount; i++)
        {
            int[] nodes = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
            int firstNode = nodes[0];
            int secondNode = nodes[1];

            visited = new Dictionary<int, bool>();
            foreach (var vertex in graph.Keys)
            {
                visited[vertex] = false;
            }

            int distance = CalculateShortestDistance(firstNode, secondNode);

            Console.WriteLine($"{{{firstNode}, {secondNode}}} -> {distance}");
        }


    }

    private static int CalculateShortestDistance(int source, int destination)
    {
        Queue<int> vertices = new Queue<int>();
        vertices.Enqueue(source);
        List<int> children;
        int distance = 1;

        while (vertices.Count > 0)
        {
            children = new List<int>();

            while (vertices.Count > 0)
            {
                var current = vertices.Dequeue();

                foreach (var child in graph[current])
                {
                    if (!visited[child])
                    {
                        if (child == destination)
                        {
                            return distance;
                        }
                        visited[child] = true;
                        children.Add(child);
                    }
                }
            }

            vertices = new Queue<int>(children);
            distance++;
        }

        return -1;
    }
}
