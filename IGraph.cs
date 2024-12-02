using System.Collections.Generic;


namespace Graph_Implementation
{
    public interface IGraph
    {
        EnGraphDirectionType GraphDirectionType { get; }
        int NumberOfVertices { get; }
        Dictionary<string, int> VerticesDictionary { get; }

        void AddEdge(string source, string destination, int weight = 1);
        void RemoveEdge(string source, string destination);
        void DisplayGraph(string message);
        int GetVertexInDegree(string vertex);
        int GetVertexOutDegree(string vertex);
        bool IsEdge(string source, string destination);

    }
}
