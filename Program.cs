using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Implementation
{
    public enum EnGraphDirectionType { Directed, Undirected };
    internal class Program
    {
        static void Main()
        {
            List<string> vertices = new List<string> { "A", "B", "C", "D", "E" };

            // Example 1 : Undirected Graph
            Graph graph1 = new AdjacencyListGraph(vertices, EnGraphDirectionType.Undirected);

            graph1.AddEdge("A", "B");
            graph1.AddEdge("A", "C");
            graph1.AddEdge("B", "D");
            graph1.AddEdge("C", "D");
            graph1.AddEdge("B", "E");
            graph1.AddEdge("D", "E");

            // Display the adjacency list to visualize the graph
            graph1.DisplayGraph("Adjacency List for graph1 1 (Undirected Graph):");

            Console.WriteLine("\n------------------------------\n");

            // Example 2 : Directed Graph
            Graph graph2 = new AdjacencyListGraph(vertices, EnGraphDirectionType.Undirected);

            graph2.AddEdge("A", "A", 1);
            graph2.AddEdge("A", "B", 1);
            graph2.AddEdge("A", "C", 1);
            graph2.AddEdge("B", "E", 1);
            graph2.AddEdge("D", "B", 1);
            graph2.AddEdge("D", "C", 1);
            graph2.AddEdge("D", "E", 1);

            // Display the adjacency list to visualize the graph
            graph2.DisplayGraph("Adjacency List for graph2 (Directed Graph):");

            // Get and display the indegree and outdegree of vertex 'D'
            Console.WriteLine("\nInDegree of vertex D: " + graph2.GetVertexInDegree("D"));
            Console.WriteLine("\nOutDegree of vertex D: " + graph2.GetVertexOutDegree("D"));

            Console.WriteLine("\n------------------------------\n");

            // Example 3 : Weighted Graph
            Graph graph3 = new AdjacencyListGraph(vertices, EnGraphDirectionType.Undirected);

            graph3.AddEdge("A", "B", 5);
            graph3.AddEdge("A", "C", 3);
            graph3.AddEdge("B", "D", 12);
            graph3.AddEdge("C", "D", 10);
            graph3.AddEdge("B", "E", 2);
            graph3.AddEdge("D", "E", 7);

            graph3.DisplayGraph("Adjacency List for graph3 (Weighted Graph):");

            // Check if there is an edge between 'E' and 'D' and display the result
            Console.WriteLine("\nIs there an edge between E and D in graph3 ? " + graph3.IsEdge("E", "D"));

            // Remove the edge between 'E' and 'D'
            graph3.RemoveEdge("E", "D");

            // Display the updated adjacency list after removing the edge
            graph3.DisplayGraph("After removing the edge between E and D:");

            Console.WriteLine("\nIs there an edge between E and D in graph3 ? " + graph3.IsEdge("E", "D"));

            Console.ReadKey();
        }
    }
}
