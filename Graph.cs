using System.Collections.Generic;
using System.Linq;

namespace Graph_Implementation
{
    public abstract class Graph : IGraph
    {
        public EnGraphDirectionType GraphDirectionType { get; }
        public int NumberOfVertices { get; }
        public Dictionary<string, int> VerticesDictionary { get; }

        protected Graph(List<string> vertices, EnGraphDirectionType graphDirectionType)
        {
            VerticesDictionary = vertices.Select((v, i) => (v, i)).ToDictionary(tuple => tuple.v, tuple => tuple.i);
            NumberOfVertices = vertices.Count;
            GraphDirectionType = graphDirectionType;
        }

        public abstract void AddEdge(string source, string destination, int weight = 1);

        public abstract void DisplayGraph(string message);

        public abstract int GetVertexInDegree(string vertex);

        public abstract int GetVertexOutDegree(string vertex);

        public abstract bool IsEdge(string source, string destination);

        public abstract void RemoveEdge(string source, string destination);

    }
}
