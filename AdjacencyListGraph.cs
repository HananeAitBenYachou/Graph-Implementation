using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph_Implementation
{
    public class AdjacencyListGraph : Graph
    {
        private Dictionary<string, List<(string, int)>> AdjacencyList { get; set; }

        public AdjacencyListGraph(List<string> vertices, EnGraphDirectionType graphDirectionType)
            : base(vertices, graphDirectionType)
        {

            AdjacencyList = new Dictionary<string, List<(string, int)>>();

            foreach (var vertex in vertices)
            {
                AdjacencyList[vertex] = new List<(string, int)>();
            }
        }

        public override void AddEdge(string source, string destination, int weight = 1)
        {
            if (!VerticesDictionary.ContainsKey(source) || !VerticesDictionary.ContainsKey(destination))
            {
                Console.WriteLine($"Error : invalid vertices {source} ==> {destination}\n\n");
                return;
            }

            if (weight <= 0)
            {
                Console.WriteLine($"Error : invalid weight (weight should be greater than zero)\n\n");
                return;
            }

            AdjacencyList[source].Add((destination, weight));

            if (GraphDirectionType == EnGraphDirectionType.Undirected)
                AdjacencyList[destination].Add((source, weight));
        }

        public override void RemoveEdge(string source, string destination)
        {
            if (!VerticesDictionary.ContainsKey(source) || !VerticesDictionary.ContainsKey(destination))
            {
                Console.WriteLine($"Error : invalid vertices {source} ==> {destination}\n\n");
                return;
            }

            if (!AdjacencyList[source].Any(t => t.Item1 == destination))
            {
                Console.WriteLine($"Error : no edge between the vertices {source} and {destination}\n\n");
                return;
            }

            AdjacencyList[source].RemoveAll(t => t.Item1 == destination);

            if (GraphDirectionType == EnGraphDirectionType.Undirected)
                AdjacencyList[destination].RemoveAll(t => t.Item1 == source);
        }

        public override void DisplayGraph(string message)
        {
            Console.WriteLine($"\n{message}\n");

            foreach (var vertex in AdjacencyList.Keys)
            {
                Console.Write(vertex + " ==> ");

                foreach (var edge in AdjacencyList[vertex])
                    Console.Write($"{edge.Item1}({edge.Item2}) ");

                Console.WriteLine();
            }
        }

        public override int GetVertexInDegree(string vertex)
        {
            int sum = 0;

            foreach (var tuplesList in AdjacencyList.Values)
            {
                if (tuplesList.Any(t => t.Item1 == vertex))
                    sum++;
            }

            return sum;
        }

        public override int GetVertexOutDegree(string vertex)
        {
            if (!VerticesDictionary.ContainsKey(vertex))
            {
                Console.WriteLine($"Error : invalid vertex {vertex}\n\n");
                return -1;
            }

            return AdjacencyList[vertex].Count;
        }

        public override bool IsEdge(string source, string destination)
        {
            if (!VerticesDictionary.ContainsKey(source) || !VerticesDictionary.ContainsKey(destination))
                return false;

            return AdjacencyList[source].Any(t => t.Item1 == destination);
        }
    }
}
