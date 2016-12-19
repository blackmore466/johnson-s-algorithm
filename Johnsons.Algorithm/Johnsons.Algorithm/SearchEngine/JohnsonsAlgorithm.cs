using System.Data.Odbc;
using System.Linq;
using Johnson.Algorithm.Model;

namespace Johnson.Algorithm.SearchEngine
{
    /// <summary>
    /// Алгоритм Джонсона
    /// </summary>
    public static class JohnsonAlgorithm
    {
        private static int GraphNodesCount = 0;

        /// <summary>
        /// В алгоритме сначала в граф добавляется дополнительная вершина.
        /// Затем для неё выполняется алгоритм Бэллмана-Форда.
        /// Исходя из тех кратчайших путей, которые выдал алгоритм, происходит перевзвешивание ребёр(чтобы не было отрицательных).
        /// Затем дополнительная вершина удаляется.
        /// Для каждой вершины графа запускается алгоритм Дэйкстры и возвращаются старые веса.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static int[][] FindShortestPaths(Graph graph)
        {
            GraphNodesCount = graph.Nodes.Count;

            graph.AddFakeNode();
            
            var shortestPathsFromFakeNode =
                    BellmanFordAlgorithm.FindShortestPath(graph, graph.Nodes.First(f => f.Id == GraphNodesCount + 1));

            graph.Reweighting(shortestPathsFromFakeNode);

             int[][] shortestPaths = new int[GraphNodesCount][];

            graph.RemoveFakeNode(GraphNodesCount + 1);

            foreach (var node in graph.Nodes)
            {
                shortestPaths[node.Id - 1] = DijkstraAlgorithm.FindShortestPath(graph, node);
                for (var i = 0; i < shortestPaths[node.Id - 1].Length; i++)
                {
                    if (shortestPaths[node.Id - 1][i] != int.MaxValue)
                    {
                        shortestPaths[node.Id - 1][i] = shortestPaths[node.Id - 1][i]
                                                        + shortestPathsFromFakeNode[i] -
                                                        shortestPathsFromFakeNode[node.Id - 1];
                    }
                }
            }

            return shortestPaths;
        }

        /// <summary>
        /// Добавление дополнительной вершины в граф
        /// </summary>
        /// <param name="graph"></param>
        private static void AddFakeNode(this Graph graph)
        {
            graph.Nodes.Add(new Node{Id = GraphNodesCount + 1});

            foreach (var node in graph.Nodes)
            {
                if (node.Id != GraphNodesCount + 1)
                {
                    graph.Edges.Add(new OrientedAndWeightedEdge
                    {
                        SourceNode = GraphNodesCount + 1,
                        DestinationNode = node.Id,
                        Weight = 0
                    });
                }
            }
        }

        /// <summary>
        /// Удаление дополнительной вершины из графа
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="id"></param>
        private static void RemoveFakeNode(this Graph graph, int id)
        {
            graph.Nodes.Remove(graph.Nodes.First(f => f.Id == id));
            graph.Edges.RemoveAll(f => f.SourceNode == id);
        }

        /// <summary>
        /// Перевзвешивание ребёр исходя из результатов работы алгоритма Бэллмана-Форда
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="shortestPaths"></param>
        private static void Reweighting(this Graph graph, int[] shortestPaths)
        {
            foreach (var edge in graph.Edges)
            {
                edge.Weight = edge.Weight + shortestPaths[edge.SourceNode - 1] - shortestPaths[edge.DestinationNode - 1];
            }
        }
    }
}
