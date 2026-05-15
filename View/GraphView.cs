using Actividad2Grafos.Model;

using System;
using System.Collections.Generic;

namespace Actividad2Grafos.View
{
    public class GraphView
    {
        public void ShowGraph(Graph graph)
        {
            Console.WriteLine("\n====================================");
            Console.WriteLine("ESTRUCTURA DEL GRAFO");
            Console.WriteLine("LISTA DE ADYACENCIA");
            Console.WriteLine("====================================");

            foreach (var node in graph.AdjacencyList)
            {
                var user = graph.Vertices[node.Key];

                Console.Write($"{user.Id} ({user.Nombre}) -> ");

                if (node.Value.Count == 0)
                {
                    Console.Write("Sin conexiones");
                }
                else
                {
                    foreach (var neighbor in node.Value)
                    {
                        var neighborUser = graph.Vertices[neighbor];

                        Console.Write(
                            $"{neighborUser.Id} ({neighborUser.Nombre}) ");
                    }
                }

                Console.WriteLine();
            }
        }

        public void ShowList(string title, List<string> data)
        {
            Console.WriteLine(title);

            int contador = 1;

            foreach (var item in data)
            {
                Console.WriteLine(contador + ". " + item);
                contador++;
            }
        }

        public void ShowUsers(string title, List<Vertex> users)
        {
            Console.WriteLine(title);

            foreach (var user in users)
            {
                Console.WriteLine(
                    $"ID: {user.Id} | Nombre: {user.Nombre} | Rol: {user.Rol}");
            }
        }

        public void Message(string text)
        {
            Console.WriteLine(text);
        }
    }
}