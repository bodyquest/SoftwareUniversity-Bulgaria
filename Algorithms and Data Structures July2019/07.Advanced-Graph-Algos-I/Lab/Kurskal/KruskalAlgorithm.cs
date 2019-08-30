using System.Linq;

using System;
using System.Collections.Generic;

public class KruskalAlgorithm
{
    public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
    {
        int[] parent = new int[numberOfVertices];
        for (int i = 0; i < numberOfVertices; i++)
        {
            parent[i] = i;
        }

        edges = edges.OrderBy(e => e.Weight).ToList();

        List<Edge> result = new List<Edge>();
        foreach (var edge in edges)
        {
            int firstNode = edge.StartNode;
            int secondNode = edge.EndNode;

            int firstNodeRoot = FindRoot(firstNode, parent);
            int secondNodeRoot = FindRoot(secondNode, parent);

            if (firstNodeRoot != secondNodeRoot)
            {
                result.Add(edge);
                parent[secondNodeRoot] = firstNodeRoot;
            }
        }

        return result;
    }

    public static int FindRoot(int node, int[] parent)
    {
        while (parent[node] != node)
        {
            node = parent[node];
        }

        return node;
    }
}
