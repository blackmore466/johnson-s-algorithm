using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Johnson.Algorithm.Model;

namespace Johnson.Algorithm.SearchEngine
{
    public static class JohnsonAlgorithm
    {
        private static int GraphNodesCount = 0;

        public static int[][] FindShortestPaths(Graph graph)
        {
            GraphNodesCount = graph.Nodes.Count;

            graph.AddFakeNode();
            
            var shortestPathsFromFakeNode = 
                    BellmanFordAlgorithm.FindShortestPath(graph, graph.Nodes.First(f => f.Id == GraphNodesCount + 1));

            graph.Reweighting(shortestPathsFromFakeNode);

             int[][] shortestPaths = new int[GraphNodesCount][];

            foreach (var node in graph.Nodes)
            {
                if (node.Id != GraphNodesCount + 1)
                {
                    shortestPaths[node.Id - 1] = DijkstraAlgorithm.FindShortestPath(graph, node);
                    for (var i = 0; i < shortestPaths[node.Id - 1].Length; i++)
                    {
                        shortestPaths[node.Id - 1][i] = shortestPaths[node.Id - 1][i]
                                                        + shortestPathsFromFakeNode[i] -
                                                        shortestPathsFromFakeNode[node.Id];
                    }
                }
            }

            return shortestPaths;
        }

        private static void AddFakeNode(this Graph graph)
        {
            graph.Nodes.Add(new Node{Id = GraphNodesCount + 1});

            foreach (var node in graph.Nodes)
            {
                if (node.Id != GraphNodesCount + 1)
                {
                    graph.Edges.Add(new Edge
                    {
                        SourceNode = GraphNodesCount + 1,
                        DestinationNode = node.Id,
                        Weight = 0
                    });
                }
            }
        }

        private static void Reweighting(this Graph graph, int[] shortestPaths)
        {
            foreach (var edge in graph.Edges)
            {
                edge.Weight = edge.Weight + shortestPaths[edge.SourceNode - 1] - shortestPaths[edge.DestinationNode - 1];
            }
        }
    }
}
