using System;
using System.Linq;
using Johnson.Algorithm.Model;

namespace Johnson.Algorithm.SearchEngine
{
    /// <summary>
    /// Реализация алгоритма Бэллмана-Форда
    /// </summary>
    public static class BellmanFordAlgorithm
    {
        private static int PositiveInfinity = int.MaxValue;
        private static int[] _distances;

        /// <summary>
        /// Алгоритм в отличие от алгоритма Дэйкстры позволяет искать кратчайшие пути в графе с отрицательными весами ребёр,
        /// потому что может исследовать уже исследованные вершины. Временная сложность тоже значительно выше.
        /// Также позволяет распознавать отрицательные циклы в графе
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="node"></param>
        /// <returns></returns>
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
                    try
                    {
                        if (_distances[edge.DestinationNode - 1] >
                            checked(_distances[edge.SourceNode - 1] + edge.Weight))
                        {
                            _distances[edge.DestinationNode - 1] =
                                _distances[edge.SourceNode - 1] + edge.Weight;
                        }
                    }
                    catch (OverflowException) //решение проблемы хранения бесконечностей в памяти компьютера
                    {
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

    /// <summary>
    ///  Исключение выбрасывается, если алгоритм обнаружил в графе отрицательные циклы.
    /// Ловится оно в основном методе Main()
    /// </summary>
    public class NegativeCycleException : Exception
    {
        public NegativeCycleException()
            :base("Присутствуют отрицательные циклы")
        {
            
        }
    }

}
