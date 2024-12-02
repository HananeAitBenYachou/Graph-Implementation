# Graph Implementation in C#

This repository contains a C# implementation of graph data structures using both **Adjacency Matrix** and **Adjacency List** representations. 

The implementation is designed to support directed and undirected graphs, and it provides various methods for manipulating and querying the graph.

## Table of Contents

- [Features](#features)
- [Graph Representations](#graph-representations)
  - [Abstract Graph Class](#abstract-graph-class)
  - [Adjacency Matrix](#adjacency-matrix)
  - [Adjacency List](#adjacency-list)
- [Usage](#usage)
- [Methods](#methods)

## Features

- Add and remove edges between vertices.
- Display the graph structure in a readable format.
- Get the in-degree and out-degree of a vertex.
- Check if an edge exists between two vertices.

## Graph Representations

### Abstract Graph Class

The `Graph` class serves as an abstract base class for the graph implementations. It defines common properties and methods that both `AdjacencyMatrixGraph` and `AdjacencyListGraph` must implement:

- **Properties:**
  - `GraphDirectionType`: Indicates whether the graph is directed or undirected.
  - `NumberOfVertices`: The total number of vertices in the graph.
  - `VerticesDictionary`: A dictionary mapping vertex names to their indices.

- **Abstract Methods:**
  - `AddEdge`: Adds an edge between two vertices.
  - `RemoveEdge`: Removes an edge between two vertices.
  - `DisplayGraph`: Displays the graph in a human-readable format.
  - `GetVertexInDegree`: Returns the in-degree of a specified vertex.
  - `GetVertexOutDegree`: Returns the out-degree of a specified vertex.
  - `IsEdge`: Checks if an edge exists between two vertices.

### Adjacency Matrix

The `AdjacencyMatrixGraph` class implements the graph using a 2D array (matrix) to represent edges. The value at row `i` and column `j` represents the weight of the edge from vertex `i` to vertex `j`. If no edge exists, the value is 0.

### Adjacency List

The `AdjacencyListGraph` class implements the graph using a dictionary of lists. Each vertex maps to a list of tuples, where each tuple represents a destination vertex and the weight of the edge.

## Usage
You can create instances of either AdjacencyMatrixGraph or AdjacencyListGraph by providing a list of vertices and the graph direction type:

```c#
using Graph_Implementation;

var vertices = new List<string> { "A", "B", "C" };
var graph = new AdjacencyMatrixGraph(vertices, EnGraphDirectionType.Directed);
graph.AddEdge("A", "B", 5);
graph.DisplayGraph("Graph Representation");
```

## Methods

- `AddEdge(string source, string destination, int weight = 1)` :
Adds an edge from source to destination with the specified weight.

- `RemoveEdge(string source, string destination)` :
Removes the edge from source to destination.

- `DisplayGraph(string message)` :
Displays the graph with a custom message.

- `GetVertexInDegree(string vertex)` : 
Returns the in-degree of the specified vertex. The in-degree is the number of edges directed into the vertex.

- `GetVertexOutDegree(string vertex)` :
Returns the out-degree of the specified vertex. The out-degree is the number of edges directed out of the vertex.

- `IsEdge(string source, string destination)` :
Checks whether there is an edge from source to destination.
