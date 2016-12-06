using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Johnsons.Algorithm.SearchEngine
{
    public static class DijkstraAlgorithm
    {
        private static int PositiveInfinity = int.MaxValue;
        private static int[] Distances;
        private static PriorityQueue PriorityQueue;

        /// <summary>
        /// Реализация алгоритма. 
        /// На начальном этапе в массиве Distances значения расстояний от node до всех вершин принимаются как бесконечность,
        /// и все вершины заносятся в очередь.
        /// Затем пока в очереди имеется хотя бы один элемент, происходит их извлечение из очереди в порядке возрастания расстояний до вершин
        /// (первым извлечется исходная вершина, т.к. расстояний до самого себя равно нулю)
        /// Для извлеченного элемента находятся все соседи, и если ребро между ними имеет вес меньше, чем записан в массиве Distances, 
        /// то значение массива перезаписывается
        /// </summary>
        /// <param name="graph">Граф, с которым проводятся операции </param>
        /// <param name="node">Вершина графа, для которой производится поиск кратчайших путей для всех остальных вершин графа </param>
        public static int[] FindShortestPath(Graph graph, Node node)
        {
            Distances = new int[graph.Nodes.Count];
            PriorityQueue = new PriorityQueue();

            Distances[node.Id] = 0;

            graph.Nodes.All(f =>
            {
                if (f.Id != node.Id)
                {
                    Distances[f.Id] = PositiveInfinity;
                }
                PriorityQueue.AddNode(f, Distances[f.Id]);
                return true;
            });

            while (!PriorityQueue.IsEmpty)
            {
                int minimalDistance = Distances.Min();
                Node nodeWithMinimalDistance = PriorityQueue.ExtractNode(minimalDistance);

                var relatedEdges = graph.Edges.Where(f => f.SourceNode == nodeWithMinimalDistance.Id); // Исходящие ребра из nodeWithMinimalDistance
                foreach (var edge in relatedEdges)
                {
                    int alternativeDistance = minimalDistance + edge.Weight;
                    if (alternativeDistance < Distances[edge.DestinationNode])
                    {
                        Distances[edge.DestinationNode] = alternativeDistance; //для каждой смежной вершины переопределяем расстояние
                    }
                }
            }

            return Distances;
        }
    }
}
