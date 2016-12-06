using System;
using System.Linq;
using Johnson.Algorithm.Model;

namespace Johnson.Algorithm.SearchEngine
{
    /// <summary>
    /// Реализация алгоритма бэллмана-Форда
    /// </summary>
    public static class BellmanFordAlgorithm
    {
        private static int PositiveInfinity = int.MaxValue;
        private static int[] _distances;

        public static int[] FindShortestPath(Graph graph, Node node)
        {
            _distances = new int[graph.Nodes.Count];

            _distances[node.Id - 1] = 0;

            graph.Nodes.All(f =>
            {
                if (f.Id != node.Id)
                {
                    _distances[f.Id - 1]= PositiveInfinity;
                }
                return true;
            });

            for (int i = 1; i < graph.Nodes.Count; i++)
            {
                foreach (var edge in graph.Edges)
                {
                    if (_distances[edge.DestinationNode - 1] >
                        _distances[edge.SourceNode - 1] + edge.Weight)
                    {
                        _distances[edge.DestinationNode - 1] =
                            _distances[edge.SourceNode - 1] + edge.Weight;
                    }
                }
            }

            foreach (var edge in graph.Edges)
            {
                if (_distances[edge.DestinationNode - 1] >
                    _distances[edge.SourceNode - 1] + edge.Weight)
                {
                    throw new NegativeCycleException();
                }
            }

            return _distances;
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
