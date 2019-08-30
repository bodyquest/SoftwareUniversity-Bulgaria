using System;
using System.Collections.Generic;
using System.Linq;

public class Edge : IComparable<Edge>
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private Dictionary<T, int> searchCollection;
        private List<T> heap;

        public PriorityQueue()
        {
            this.heap = new List<T>();
            this.searchCollection = new Dictionary<T, int>();
        }

        public int Count {
            get {
                return this.heap.Count;
            }
        }

        public T ExtractMin()
        {
            var min = this.heap[0];
            this.heap[0] = this.heap[this.heap.Count - 1];
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                this.HeapifyDown(0);
            }

            this.searchCollection.Remove(min);

            return min;
        }

        public T PeekMin()
        {
            return this.heap[0];
        }

        public void Enqueue(T element)
        {
            this.searchCollection.Add(element, this.heap.Count);
            this.heap.Add(element);
            this.HeapifyUp(this.heap.Count - 1);
        }

        private void HeapifyDown(int i)
        {
            var left = (2 * i) + 1;
            var right = (2 * i) + 2;
            var smallest = i;

            if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = left;
            }

            if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = right;
            }

            if (smallest != i)
            {
                T old = this.heap[i];
                this.searchCollection[old] = smallest;
                this.searchCollection[this.heap[smallest]] = i;
                this.heap[i] = this.heap[smallest];
                this.heap[smallest] = old;
                this.HeapifyDown(smallest);
            }
        }

        private void HeapifyUp(int i)
        {
            var parent = (i - 1) / 2;
            while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
            {
                T old = this.heap[i];
                this.searchCollection[old] = parent;
                this.searchCollection[this.heap[parent]] = i;
                this.heap[i] = this.heap[parent];
                this.heap[parent] = old;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public void DecreaseKey(T element)
        {
            int index = this.searchCollection[element];
            this.HeapifyUp(index);
        }
    }

    public Edge(int to, double weight)
    {
        this.To = to;
        this.Weight = weight;
    }

    public int To { get; private set; }

    public double Weight { get; private set; }

    public int CompareTo(Edge other)
    {
        return this.Weight.CompareTo(other.Weight);
    }
}
public class Vertex : IComparable<Vertex>
{
    public Vertex(int index)
    {
        this.Index = index;
        this.DijkstraDistance = 0;
        this.Neighbors = new List<Vertex>();
        this.Edges = new List<Edge>();
        this.From = index;
    }

    public int Index { get; private set; }

    public int From { get; set; }

    public double DijkstraDistance { get; set; }

    public List<Vertex> Neighbors { get; private set; }

    public List<Edge> Edges { get; private set; }

    public int CompareTo(Vertex other)
    {
        return (100 - this.DijkstraDistance).CompareTo(100 - other.DijkstraDistance);
    }
}
class Program
{
    public static void Main()
    {
        int vertexCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();
        int[] startEndPoints = Console.ReadLine().Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
        int edgesCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();

        var graph = new Vertex[vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            graph[i] = new Vertex(i);
        }

        for (int i = 0; i < edgesCount; i++)
        {
            int[] edgesArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int from = edgesArgs[0];
            int to = edgesArgs[1];
            int weight = edgesArgs[2];
            graph[from].Neighbors.Add(graph[to]);
            graph[to].Neighbors.Add(graph[from]);
            graph[from].Edges.Add(new Edge(to, weight));
            graph[to].Edges.Add(new Edge(from, weight));
        }

        int sourceVertex = startEndPoints[0];
        int destinationVertex = startEndPoints[1];
        graph[sourceVertex].DijkstraDistance = 100;
        var visitedVertex = new bool[vertexCount];
        visitedVertex[sourceVertex] = true;
        var queue = new Edge.PriorityQueue<Vertex>();
        queue.Enqueue(graph[sourceVertex]);

        while (queue.Count > 0)
        {
            var curentVertex = queue.ExtractMin();

            foreach (var edge in graph[curentVertex.Index].Edges)
            {
                if (graph[edge.To].DijkstraDistance < curentVertex.DijkstraDistance * edge.Weight / 100)
                {
                    graph[edge.To].DijkstraDistance = curentVertex.DijkstraDistance * edge.Weight / 100;
                    graph[edge.To].From = curentVertex.Index;
                }
            }

            foreach (var neighbor in graph[curentVertex.Index].Neighbors)
            {
                if (!visitedVertex[neighbor.Index])
                {
                    visitedVertex[neighbor.Index] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        Console.WriteLine("Most reliable path reliability: {0:F2}%", graph[destinationVertex].DijkstraDistance);
        var pathVertex = new Stack<int>();
        pathVertex.Push(destinationVertex);
        while (graph[destinationVertex].Index != graph[destinationVertex].From)
        {
            destinationVertex = graph[destinationVertex].From;
            pathVertex.Push(destinationVertex);
        }

        Console.WriteLine(string.Join(" -> ", pathVertex));
    }
}

