using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

public class GraphConnectedComponents
{
    static List<int>[] graph;
    private static bool[] visited;
    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }
        return graph;
    }

    private static void FindGraphConnectedComponents()
    {
       visited = new bool[graph.Length];

       for (int i = 0; i < graph.Length; i++)
       {
           if (!visited[i])
           {
               Console.Write("Connected component:");
               DFS(i);
               Console.WriteLine();
           }
       }
    }

    private static void DFS(int node)
    {
        if (visited[node])
        {
            return;
        }

        visited[node] = true;

        foreach (var child in graph[node])
        {
            DFS(child);
            
        }

        Console.Write(" " + node);

    }
}
