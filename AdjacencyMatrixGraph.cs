using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph_Implementation
{
    public class AdjacencyMatrixGraph : Graph
    {
        private int[,] AdjacencyMatrix { get; set; }

        public AdjacencyMatrixGraph(List<string> vertices, EnGraphDirectionType graphDirectionType)
            : base(vertices, graphDirectionType)
        {
            AdjacencyMatrix = new int[NumberOfVertices, NumberOfVertices];
        }

        public override void AddEdge(string source, string destination, int weight = 1)
        {
            if (!VerticesDictionary.ContainsKey(source) || !VerticesDictionary.ContainsKey(destination))
            {
                Console.WriteLine($"Error : invalid vertices {source} ==> {destination}\n\n");
                return;
            }

            if (AdjacencyMatrix[VerticesDictionary[source], VerticesDictionary[destination]] > 0)
            {
                Console.WriteLine($"Error : an edge already exists between the vertices {source} and {destination}\n\n");
                return;
            }

            if (weight <= 0)
            {
                Console.WriteLine($"Error : invalid weight (weight should be greater than zero)\n\n");
                return;
            }

            AdjacencyMatrix[VerticesDictionary[source], VerticesDictionary[destination]] = weight;

            if (GraphDirectionType == EnGraphDirectionType.Undirected)
                AdjacencyMatrix[VerticesDictionary[destination], VerticesDictionary[source]] = weight;
        }

        public override void RemoveEdge(string source, string destination)
        {
            if (!VerticesDictionary.ContainsKey(source) || !VerticesDictionary.ContainsKey(destination))
            {
                Console.WriteLine($"Error : invalid vertices {source} ==> {destination}\n\n");
                return;
            }

            if (AdjacencyMatrix[VerticesDictionary[source], VerticesDictionary[destination]] == 0)
            {
                Console.WriteLine($"Error : no edge between the vertices {source} and {destination}\n\n");
                return;
            }

            AdjacencyMatrix[VerticesDictionary[source], VerticesDictionary[destination]] = 0;

            if (GraphDirectionType == EnGraphDirectionType.Undirected)
                AdjacencyMatrix[VerticesDictionary[destination], VerticesDictionary[source]] = 0;
        }

        public override void DisplayGraph(string message)
        {
            Console.WriteLine($"\n{message}\n");

            Console.Write("  ");

            List<string> vertices = VerticesDictionary.Keys.ToList();

            vertices.ForEach(v => Console.Write(v.PadLeft(2) + " "));

            Console.WriteLine();

            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
            {
                //Console.Write(_verticesDictionary.First(kvp => kvp.Value == i).Key + " ");

                Console.WriteLine(vertices[i] + " ");

                for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
                {
                    Console.Write(AdjacencyMatrix[i, j].ToString().PadLeft(2) + " ");
                }

                Console.WriteLine();
            }
        }

        public override int GetVertexInDegree(string vertex)
        {
            if (!VerticesDictionary.ContainsKey(vertex))
            {
                Console.WriteLine($"Error : invalid vertex {vertex}\n\n");
                return -1;
            }

            int sum = 0;

            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
            {
                if (AdjacencyMatrix[i, VerticesDictionary[vertex]] > 0)
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

            int sum = 0;

            for (int i = 0; i < AdjacencyMatrix.GetLength(1); i++)
            {
                if (AdjacencyMatrix[VerticesDictionary[vertex], i] > 0)
                    sum++;
            }

            return sum;
        }

        public override bool IsEdge(string source, string destination)
        {
            if (!VerticesDictionary.ContainsKey(source) || !VerticesDictionary.ContainsKey(destination))
                return false;

            return AdjacencyMatrix[VerticesDictionary[source], VerticesDictionary[destination]] > 0;
        }

    }

}
