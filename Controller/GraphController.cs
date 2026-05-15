using Actividad2Grafos.Model;
using Actividad2Grafos.View;
using System;

namespace Actividad2Grafos.Controller
{
    public class GraphController
    {
        private Graph graph;
        private GraphView view;

        public GraphController()
        {
            graph = new Graph();
            view = new GraphView();
        }

        public void Run()
        {
            view.Message("====================================");
            view.Message("SISTEMA CAMPUSNET");
            view.Message("RED SOCIAL ACADEMICA");
            view.Message("====================================");

            CreateUsers();
            CreateRelations();

            view.ShowGraph(graph);

            ExecuteBFS();
            ExecuteDFS();

            ExecuteQueries();

            ExecuteCRUD();
        }

        private void CreateUsers()
        {
            graph.AddVertex(new Vertex("U1", "Ana", "Estudiante"));
            graph.AddVertex(new Vertex("U2", "Luis", "Profesor"));
            graph.AddVertex(new Vertex("U3", "Carlos", "Egresado"));
            graph.AddVertex(new Vertex("U4", "Maria", "Estudiante"));
            graph.AddVertex(new Vertex("U5", "Laura", "Profesor"));
            graph.AddVertex(new Vertex("U6", "Pedro", "Egresado"));
            graph.AddVertex(new Vertex("U7", "Camila", "Estudiante"));
            graph.AddVertex(new Vertex("U8", "Sofia", "Profesor"));
            graph.AddVertex(new Vertex("U9", "Mateo", "Egresado"));
            graph.AddVertex(new Vertex("U10", "Valeria", "Estudiante"));
            graph.AddVertex(new Vertex("U11", "Andres", "Profesor"));
            graph.AddVertex(new Vertex("U12", "Julian", "Egresado"));
        }

        private void CreateRelations()
        {
            graph.AddEdge("U1", "U2");
            graph.AddEdge("U1", "U3");
            graph.AddEdge("U1", "U4");
            graph.AddEdge("U1", "U5");

            graph.AddEdge("U2", "U3");
            graph.AddEdge("U2", "U6");
            graph.AddEdge("U2", "U7");
            graph.AddEdge("U2", "U8");

            graph.AddEdge("U3", "U1");

            graph.AddEdge("U4", "U5");
            graph.AddEdge("U4", "U6");

            graph.AddEdge("U5", "U7");
            graph.AddEdge("U5", "U8");

            graph.AddEdge("U6", "U9");
            graph.AddEdge("U6", "U10");

            graph.AddEdge("U7", "U10");
            graph.AddEdge("U7", "U9");

            graph.AddEdge("U10", "U2");
        }

        private void ExecuteBFS()
        {
            var bfs1 = graph.BFS("U1");

            view.Message("\n====================================");
            view.Message("RECORRIDO BFS DESDE U1");
            view.Message("====================================");

            view.ShowList("Orden de visita:", bfs1);

            view.Message("Cantidad de vertices alcanzados: " + bfs1.Count);



            var bfs2 = graph.BFS("U5");

            view.Message("\n====================================");
            view.Message("RECORRIDO BFS DESDE U5");
            view.Message("====================================");

            view.ShowList("Orden de visita:", bfs2);

            view.Message("Cantidad de vertices alcanzados: " + bfs2.Count);



            var bfs3 = graph.BFS("U8");

            view.Message("\n====================================");
            view.Message("RECORRIDO BFS DESDE U8");
            view.Message("====================================");

            view.ShowList("Orden de visita:", bfs3);

            view.Message("Cantidad de vertices alcanzados: " + bfs3.Count);
        }

        private void ExecuteDFS()
        {
            var dfs = graph.DFS();

            view.Message("\n====================================");
            view.Message("RECORRIDO DFS COMPLETO");
            view.Message("====================================");

            view.ShowList("Orden de descubrimiento:", dfs);

            view.Message("\nVerificacion de ciclos en el grafo:");

            if (graph.HasCycle())
            {
                view.Message("Resultado: Se detectaron ciclos dirigidos.");
            }
            else
            {
                view.Message("Resultado: No se detectaron ciclos.");
            }
        }

        private void ExecuteQueries()
        {
            view.Message("\n====================================");
            view.Message("CONSULTAS SOCIALES");
            view.Message("====================================");

            view.ShowUsers(
                "\nUsuarios sin seguidores (grado de entrada 0):",
                graph.UsersWithoutFollowers());

            view.ShowUsers(
                "\nUsuarios mas influyentes (mayor cantidad de seguidores):",
                graph.MostInfluentialUsers());

            view.ShowUsers(
                "\nUsuarios mas activos (siguen a mas usuarios):",
                graph.MostActiveUsers());

            bool reachable = graph.CanReach("U1", "U11");

            view.Message("\nVerificacion de alcanzabilidad:");

            if (reachable)
            {
                view.Message("SI existe un camino entre U1 y U11.");
            }
            else
            {
                view.Message("NO existe un camino entre U1 y U11.");
            }
        }

        private void ExecuteCRUD()
        {
            view.Message("\n====================================");
            view.Message("OPERACIONES CRUD");
            view.Message("====================================");



            // AGREGAR USUARIO

            view.Message("\n1. Agregando nuevo usuario...");

            graph.AddVertex(new Vertex("U13", "Daniel", "Estudiante"));

            view.Message("Usuario agregado correctamente.");

            view.ShowGraph(graph);



            // AGREGAR RELACION

            view.Message("\n2. Agregando relacion dirigida U13 -> U1 ...");

            graph.AddEdge("U13", "U1");

            view.Message("Relacion agregada correctamente.");

            view.ShowGraph(graph);



            // ACTUALIZAR USUARIO

            view.Message("\n3. Actualizando informacion del usuario U13 ...");

            graph.UpdateVertex("U13", "Daniel Torres", "Egresado");

            view.Message("Usuario actualizado correctamente.");

            view.ShowGraph(graph);



            // ELIMINAR RELACION

            view.Message("\n4. Eliminando relacion U13 -> U1 ...");

            graph.RemoveEdge("U13", "U1");

            view.Message("Relacion eliminada correctamente.");

            view.ShowGraph(graph);



            // ELIMINAR USUARIO

            view.Message("\n5. Eliminando usuario U13 ...");

            graph.RemoveVertex("U13");

            view.Message("Usuario eliminado correctamente.");

            view.ShowGraph(graph);
        }
    }
}