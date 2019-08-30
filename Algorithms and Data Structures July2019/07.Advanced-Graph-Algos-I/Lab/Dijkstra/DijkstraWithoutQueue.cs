//namespace Dijkstra
//{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            int[] distances = new int[graph.GetLength(0)];

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = Int32.MaxValue;
            }

            distances[sourceNode] = 0;

            bool[] visited = new bool[graph.Length];
            int?[] previous = new int?[graph.Length];

            while (true)
            {
                int minDistance = Int32.MaxValue;
                int minNode = 0;
                for (int node = 0; node < graph.GetLength(0); node++)
                {
                    if (!visited[node] && distances[node] < minDistance)
                    {
                        minDistance = distances[node];
                        minNode = node;
                    }
                }

                if (minDistance == Int32.MaxValue)
                {
                    break;
                }

                visited[minNode] = true;

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int newDistance = minDistance + graph[minNode, i];
                        if (newDistance < distances[i])
                        {
                            distances[i] = newDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            if (distances[destinationNode] == int.MaxValue)
            {
                return null;
            }

            var path = new List<int>();
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }

            path.Reverse();

            return path;
        }
    }
//}
