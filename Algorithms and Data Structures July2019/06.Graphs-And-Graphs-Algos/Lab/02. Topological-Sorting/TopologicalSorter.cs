using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        List<string> result = new List<string>();
        
        while (graph.Count > 0)
        {
            bool hasCycle = true;
            foreach (var node in graph.ToList())
            {
                if (!graph.Values.SelectMany(n => n).Contains(node.Key))
                {
                    result.Add(node.Key);
                    graph.Remove(node.Key);
                    hasCycle = false;
                }

            }

            if (hasCycle)
            {
                throw new InvalidOperationException();
            }
        }
       
        return result;
    }
}
