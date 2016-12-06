using System.Linq;
using Johnson.Algorithm.Model;

namespace Johnson.Algorithm.SearchEngine
{
    /// <summary>
    /// Реализация алгоритма Дэйкстра
    /// </summary>
    public static class DijkstraAlgorithm
    {
        private static int _iterator = 1;
        private static int PositiveInfinity = int.MaxValue;
        private static int[] _distances;
        private static PriorityQueue _priorityQueue;

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
            _distances = new int[graph.Nodes.Count];
            _priorityQueue = new PriorityQueue();

            _distances[node.Id - 1] = 0;

            graph.Nodes.All(f =>
            {
                if (f.Id != node.Id)
                {
                    _distances[f.Id - 1] = PositiveInfinity;
                }
                _priorityQueue.AddNode(f, _distances[f.Id - 1]);
                return true;
            });

            while (!_priorityQueue.IsEmpty)
            {
                _distances.OrderBy(f => f);
                int minimalDistance = _distances[_iterator - 1];
                _iterator++;
                Node nodeWithMinimalDistance = _priorityQueue.ExtractNode(minimalDistance);

                var relatedEdges = graph.Edges.Where(f => f.SourceNode == nodeWithMinimalDistance.Id); // Исходящие ребра из nodeWithMinimalDistance
                foreach (var edge in relatedEdges)
                {
                    int alternativeDistance = minimalDistance + edge.Weight;
                    if (alternativeDistance < _distances[edge.DestinationNode - 1])
                    {
                        _distances[edge.DestinationNode - 1] = alternativeDistance; //для каждой смежной вершины переопределяем расстояние
                        _priorityQueue.ChangePriority(edge.DestinationNode, alternativeDistance);
                    }
                }
            }

            return _distances;
        }
    }
}
