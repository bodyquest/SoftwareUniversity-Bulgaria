using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueue<T> where T : IComparable<T>
{
    private readonly List<T> heap;

    public PriorityQueue()
    {
        this.heap = new List<T>();
    }

    public int Count => this.heap.Count;

    public T ExtractMin()
    {
        var min = this.heap[0];
        this.heap[0] = this.heap[this.heap.Count - 1];
        this.heap.RemoveAt(this.heap.Count - 1);
        if (this.heap.Count > 0)
        {
            this.HeapifyDown(0);
        }

        return min;
    }

    public T PeekMin()
    {
        return this.heap[0];
    }

    public void Enqueue(T element)
    {
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
            this.heap[i] = this.heap[parent];
            this.heap[parent] = old;

            i = parent;
            parent = (i - 1) / 2;
        }
    }
}


public class Edge : IComparable<Edge>
{

    
    public Edge(int from, int to, int weight)
    {
        this.From = from;
        this.To = to;
        this.Weight = weight;
    }

    public int From { get; private set; }
    public int To { get; private set; }
    public int Weight { get; private set; }
    public int CompareTo(Edge other)
    {
        return this.Weight.CompareTo(other.Weight);
    }

    public override string ToString()
    {
        return $"({this.From} {this.To}) -> {this.Weight}";
    }
}
public class Program
{
    public static void Main()
    {
        int nodesCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();
        int edgesCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();

        var queue = new PriorityQueue<Edge>();
        for (int i = 0; i < edgesCount; i++)
        {
            int[] edgeArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var edge = new Edge(edgeArgs[0], edgeArgs[1], edgeArgs[2]);
            queue.Enqueue(edge);
        }

        var nodes = new int[nodesCount];
        for (int i = 1; i < nodesCount; i++)
        {
            nodes[i] = i;
        }

        var resultMst = new List<Edge>();
        int mstWeight = 0;
        while (queue.Count > 0)
        {
            var minEdge = queue.ExtractMin();
            int from = minEdge.From;
            int to = minEdge.To;
            int weight = minEdge.Weight;
            int fromRoot = FindRoot(from, nodes);
            int toRoot = FindRoot(to, nodes);
            if (fromRoot != toRoot)
            {
                resultMst.Add(minEdge);
                MergeTrees(fromRoot, to, nodes);
                mstWeight += weight;
            }
        }

        Console.WriteLine("Minimum spanning forest weight: " + mstWeight);
    }

    private static void MergeTrees(int fromRoot, int to, int[] nodes)
    {
        int currentRoot = nodes[to];
        while (currentRoot != fromRoot)
        {
            int oldRoot = nodes[currentRoot];
            nodes[currentRoot] = fromRoot;
            currentRoot = oldRoot;
        }
    }

    private static int FindRoot(int from, int[] nodes)
    {
        int root = nodes[from];
        while (root != nodes[root])
        {
            root = nodes[root];
        }

        return root;
    }
}
