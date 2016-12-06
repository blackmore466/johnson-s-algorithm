using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Johnsons.Algorithm.SearchEngine;
using Johnsons.Algorithm;

namespace Johnson_s_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Init graph

            Graph graph = new Graph();

            graph.Nodes = new List<Node>
            {
                new Node {Id = 1},
                new Node {Id = 2},
                new Node {Id = 3},
                new Node {Id = 4},
                new Node {Id = 5},
                new Node {Id = 6},
                new Node {Id = 7},
                new Node {Id = 8}
            };

            graph.Edges = new List<Edge>
            {
                new Edge
                {
                    SourceNode = 1,
                    DestinationNode = 2,
                    Weight = 3
                },
                new Edge
                {
                    SourceNode = 1,
                    DestinationNode = 3,
                    Weight = 2
                },
                new Edge
                {
                    SourceNode = 1,
                    DestinationNode = 4,
                    Weight = 5
                },
                new Edge
                {
                    SourceNode = 2,
                    DestinationNode = 5,
                    Weight = 3
                },
                new Edge
                {
                    SourceNode = 3,
                    DestinationNode = 5,
                    Weight = 1
                },
                new Edge
                {
                    SourceNode = 3,
                    DestinationNode = 6,
                    Weight = 6
                },
                new Edge
                {
                    SourceNode = 4,
                    DestinationNode = 6,
                    Weight = 2
                },
                new Edge
                {
                    SourceNode = 5,
                    DestinationNode = 7,
                    Weight = 4
                },
                new Edge
                {
                    SourceNode = 6,
                    DestinationNode = 7,
                    Weight = 1
                },
                new Edge
                {
                    SourceNode = 6,
                    DestinationNode = 8,
                    Weight = 4
                },
                new Edge
                {
                    SourceNode = 7,
                    DestinationNode = 8,
                    Weight = 2
                }
            };
            #endregion

            //граф с отрицательными весами ребёр
            #region Init graph2

            Graph graph2 = new Graph();

            graph2.Nodes = new List<Node>
            {
                new Node {Id = 1},
                new Node {Id = 2},
                new Node {Id = 3},
                new Node {Id = 4},
                new Node {Id = 5},
                new Node {Id = 6},
                new Node {Id = 7},
                new Node {Id = 8},
                new Node {Id = 9},
                new Node {Id = 10},
                new Node {Id = 11},
                new Node {Id = 12},
            };

            graph2.Edges = new List<Edge>
            {
                new Edge
                {
                    SourceNode = 1,
                    DestinationNode = 2,
                    Weight = -5
                },
                new Edge
                {
                    SourceNode = 1,
                    DestinationNode = 3,
                    Weight = 5
                },
                new Edge
                {
                    SourceNode = 1,
                    DestinationNode = 4,
                    Weight = 9
                },                
                new Edge
                {
                    SourceNode = 2,
                    DestinationNode = 5,
                    Weight = 3
                },
                new Edge
                {
                    SourceNode = 3,
                    DestinationNode = 6,
                    Weight = -5
                },
                new Edge
                {
                    SourceNode = 3,
                    DestinationNode = 10,
                    Weight = 20
                },
                new Edge
                {
                    SourceNode = 4,
                    DestinationNode = 6,
                    Weight = 2
                },
                new Edge
                {
                    SourceNode = 5,
                    DestinationNode = 7,
                    Weight = 1
                },
                new Edge
                {
                    SourceNode = 6,
                    DestinationNode = 10,
                    Weight = 12
                },
                new Edge
                {
                    SourceNode = 6,
                    DestinationNode = 8,
                    Weight = -7
                },
                new Edge
                {
                    SourceNode = 7,
                    DestinationNode = 9,
                    Weight = -2
                },
                new Edge
                {
                    SourceNode = 7,
                    DestinationNode = 12,
                    Weight = 9
                },
                new Edge
                {
                    SourceNode = 7,
                    DestinationNode = 11,
                    Weight = -5
                },
                new Edge
                {
                    SourceNode = 8,
                    DestinationNode = 11,
                    Weight = 8
                },
                new Edge
                {
                    SourceNode = 9,
                    DestinationNode = 12,
                    Weight = 4
                },
                new Edge
                {
                    SourceNode = 10,
                    DestinationNode = 12,
                    Weight = 6
                },
                new Edge
                {
                    SourceNode = 11,
                    DestinationNode = 12,
                    Weight = 11
                }
            };

            
            #endregion


            var shortestDistances = DijkstraAlgorithm.FindShortestPath(graph2, graph2.Nodes.First(f => f.Id == 1));

            var shortestDistances1 = Bellman_FordAlgorithm.FindShortestPath(graph2, graph2.Nodes.First(f => f.Id == 1));
        }
    }
}

