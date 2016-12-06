using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Johnson.Algorithm.SearchEngine
{
    /// <summary>
    /// Реализация алгоритма бэллмана-Форда
    /// </summary>
    public static class Bellman_FordAlgorithm
    {
        private static int Iterator = 1;
        private static int PositiveInfinity = int.MaxValue;
        private static int[] Distances;
        private static PriorityQueue PriorityQueue;

        public static int[] FindShortestPath(Graph graph, Node node)
        {
            Distances = new int[graph.Nodes.Count];

            Distances[node.Id - 1] = 0;

            graph.Nodes.All(f =>
            {
                if (f.Id != node.Id)
                {
                    Distances[f.Id - 1]= PositiveInfinity;
                }
                return true;
            });

            for (int i = 1; i < graph.Nodes.Count; i++)
            {
                foreach (var edge in graph.Edges)
                {
                    if (Distances[edge.DestinationNode - 1] >
                        Distances[edge.SourceNode - 1] + edge.Weight)
                    {
                        Distances[edge.DestinationNode - 1] =
                            Distances[edge.SourceNode - 1] + edge.Weight;
                    }
                }
            }

            foreach (var edge in graph.Edges)
            {
                if (Distances[edge.DestinationNode - 1] >
                    Distances[edge.SourceNode - 1] + edge.Weight)
                {
                    throw new NegativeCycleException();
                }
            }

            return Distances;
        }
    }

    public class NegativeCycleException : Exception
    {
        public NegativeCycleException()
            :base("Присутствуют отрицательные циклы")
        {
            
        }
    }

}
