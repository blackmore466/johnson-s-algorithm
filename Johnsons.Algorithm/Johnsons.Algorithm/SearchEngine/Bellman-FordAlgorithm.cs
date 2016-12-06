using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Johnsons.Algorithm.SearchEngine
{
    /// <summary>
    /// Реализация алгоритма бэллмана-Форда
    /// </summary>
    public static class Bellman_FordAlgorithm
    {
        private static int Iterator = 1;
        private static int PositiveInfinity = int.MaxValue;
        private static DistancesAndChain[] DistancesAdnChains;
        private static PriorityQueue PriorityQueue;

        public static DistancesAndChain[] FindShortestPath(Graph graph, Node node)
        {
            DistancesAdnChains = new DistancesAndChain[graph.Nodes.Count];

            DistancesAdnChains[node.Id - 1] = new DistancesAndChain();

            DistancesAdnChains[node.Id - 1].Distance = 0;
            DistancesAdnChains[node.Id - 1].Predecessor = null;

            graph.Nodes.All(f =>
            {
                if (f.Id != node.Id)
                {
                    DistancesAdnChains[f.Id - 1] = new DistancesAndChain();
                    DistancesAdnChains[f.Id - 1].Distance = PositiveInfinity;
                    DistancesAdnChains[f.Id - 1].Predecessor = null;
                }
                //PriorityQueue.AddNode(f, DistancesAdnChains[f.Id - 1]);
                return true;
            });

            for (int i = 1; i < graph.Nodes.Count; i++)
            {
                foreach (var edge in graph.Edges)
                {
                    if (DistancesAdnChains[edge.DestinationNode - 1].Distance >
                        DistancesAdnChains[edge.SourceNode - 1].Distance + edge.Weight)
                    {
                        DistancesAdnChains[edge.DestinationNode - 1].Distance =
                            DistancesAdnChains[edge.SourceNode - 1].Distance + edge.Weight;
                        DistancesAdnChains[edge.DestinationNode - 1].Predecessor = edge.SourceNode;
                    }
                }
            }

            foreach (var edge in graph.Edges)
            {
                if (DistancesAdnChains[edge.DestinationNode - 1].Distance >
                    DistancesAdnChains[edge.SourceNode - 1].Distance + edge.Weight)
                {
                    throw new NegativeCycleException();
                }
            }

            return DistancesAdnChains;
        }
    }

    /// <summary>
    /// Класс-обёртка, инкапсулирующий в себе расстояние до каждой вершины 
    /// и вершину, предшествующую данной на кратчайшем пути
    /// </summary>
    public class DistancesAndChain
    {
        public int Distance { get; set; }
        public int? Predecessor { get; set; }

    }

    public class NegativeCycleException : Exception
    {
        public NegativeCycleException()
            :base("Присутствуют отрицательные циклы")
        {
            
        }
    }

}
