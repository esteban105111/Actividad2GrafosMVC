using Actividad2Grafos.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Actividad2Grafos.Model
{
    public class Graph
    {
        public Dictionary<string, Vertex> Vertices { get; set; }
        public Dictionary<string, List<string>> AdjacencyList { get; set; }

        public Graph()
        {
            Vertices = new Dictionary<string, Vertex>();
            AdjacencyList = new Dictionary<string, List<string>>();
        }

        // CRUD VERTICES

        public bool AddVertex(Vertex vertex)
        {
            if (Vertices.ContainsKey(vertex.Id))
                return false;

            Vertices.Add(vertex.Id, vertex);
            AdjacencyList.Add(vertex.Id, new List<string>());

            return true;
        }

        public bool RemoveVertex(string id)
        {
            if (!Vertices.ContainsKey(id))
                return false;

            Vertices.Remove(id);
            AdjacencyList.Remove(id);

            foreach (var list in AdjacencyList.Values)
            {
                list.Remove(id);
            }

            return true;
        }

        public bool UpdateVertex(string id, string nombre, string rol)
        {
            if (!Vertices.ContainsKey(id))
                return false;

            Vertices[id].Nombre = nombre;
            Vertices[id].Rol = rol;

            return true;
        }

        // CRUD ARISTAS

        public bool AddEdge(string from, string to)
        {
            if (!Vertices.ContainsKey(from) || !Vertices.ContainsKey(to))
                return false;

            if (AdjacencyList[from].Contains(to))
                return false;

            AdjacencyList[from].Add(to);

            return true;
        }

        public bool RemoveEdge(string from, string to)
        {
            if (!AdjacencyList.ContainsKey(from))
                return false;

            return AdjacencyList[from].Remove(to);
        }

        // MOSTRAR GRAFO

        public Dictionary<string, List<string>> GetAdjacencyList()
        {
            return AdjacencyList;
        }

        // BFS

        public List<string> BFS(string start)
        {
            List<string> visited = new List<string>();
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();

                foreach (var neighbor in AdjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return visited;
        }

        // DFS

        public List<string> DFS()
        {
            List<string> visited = new List<string>();

            foreach (var vertex in Vertices.Keys)
            {
                if (!visited.Contains(vertex))
                {
                    DFSRecursive(vertex, visited);
                }
            }

            return visited;
        }

        private void DFSRecursive(string vertex, List<string> visited)
        {
            visited.Add(vertex);

            foreach (var neighbor in AdjacencyList[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    DFSRecursive(neighbor, visited);
                }
            }
        }

        // CICLOS

        public bool HasCycle()
        {
            HashSet<string> visited = new HashSet<string>();
            HashSet<string> recursion = new HashSet<string>();

            foreach (var vertex in Vertices.Keys)
            {
                if (DetectCycle(vertex, visited, recursion))
                    return true;
            }

            return false;
        }

        private bool DetectCycle(string vertex,
            HashSet<string> visited,
            HashSet<string> recursion)
        {
            if (recursion.Contains(vertex))
                return true;

            if (visited.Contains(vertex))
                return false;

            visited.Add(vertex);
            recursion.Add(vertex);

            foreach (var neighbor in AdjacencyList[vertex])
            {
                if (DetectCycle(neighbor, visited, recursion))
                    return true;
            }

            recursion.Remove(vertex);

            return false;
        }

        // CONSULTAS

        public List<Vertex> UsersWithoutFollowers()
        {
            Dictionary<string, int> indegree = Vertices.Keys
                .ToDictionary(v => v, v => 0);

            foreach (var node in AdjacencyList)
            {
                foreach (var neighbor in node.Value)
                {
                    indegree[neighbor]++;
                }
            }

            return indegree
                .Where(x => x.Value == 0)
                .Select(x => Vertices[x.Key])
                .ToList();
        }

        public List<Vertex> MostInfluentialUsers()
        {
            Dictionary<string, int> indegree = Vertices.Keys
                .ToDictionary(v => v, v => 0);

            foreach (var node in AdjacencyList)
            {
                foreach (var neighbor in node.Value)
                {
                    indegree[neighbor]++;
                }
            }

            int max = indegree.Values.Max();

            return indegree
                .Where(x => x.Value == max)
                .Select(x => Vertices[x.Key])
                .ToList();
        }

        public List<Vertex> MostActiveUsers()
        {
            int max = AdjacencyList.Values.Max(x => x.Count);

            return AdjacencyList
                .Where(x => x.Value.Count == max)
                .Select(x => Vertices[x.Key])
                .ToList();
        }

        public bool CanReach(string from, string to)
        {
            return BFS(from).Contains(to);
        }
    }
}