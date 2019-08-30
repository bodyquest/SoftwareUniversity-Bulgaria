//namespace Dijkstra
//{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
        {
            bool[] visited = new bool[graph.Count];
            int?[] previous = new int?[graph.Count];
            PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

            foreach (var kvp in graph)
            {
                kvp.Key.DistanceFromStart = Double.PositiveInfinity;
            }

            sourceNode.DistanceFromStart = 0;
            priorityQueue.Enqueue(sourceNode);

            while (priorityQueue.Count > 0)
            {
                Node minNode = priorityQueue.ExtractMin();

                if (minNode == destinationNode)
                {
                    break;
                }

                foreach (var kvp in graph[minNode])
                {
                    if (!visited[kvp.Key.Id])
                    {
                        priorityQueue.Enqueue(kvp.Key);
                        visited[kvp.Key.Id] = true;
                    }

                    double distance = minNode.DistanceFromStart + kvp.Value;

                    if (distance < kvp.Key.DistanceFromStart)
                    {
                        kvp.Key.DistanceFromStart = distance;
                        previous[kvp.Key.Id] = minNode.Id;
                        priorityQueue.DecreaseKey(kvp.Key);
                    }
                }
            }

            if (double.IsInfinity(destinationNode.DistanceFromStart))
            {
                return null;
            }

            List<int> path = new List<int>();
            int? current = destinationNode.Id;

            while (current != null)
            {
                path.Add(current.Value);
                current = previous[current.Value];
            }

            path.Reverse();

            return path;
        }
    }
//}
