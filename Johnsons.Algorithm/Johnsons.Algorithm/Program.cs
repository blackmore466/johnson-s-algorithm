using System;
using System.Collections.Generic;
using Johnson.Algorithm.Model;
using Johnson.Algorithm.SearchEngine;

namespace Johnson.Algorithm
{
    class Program
    {
        private static string _errorMessage = "";

        static void Main()
        {
            #region Init graph

            Graph graph = new Graph
            {
                Nodes = new List<Node>
                {
                    new Node {Id = 1},
                    new Node {Id = 2},
                    new Node {Id = 3},
                    new Node {Id = 4},
                    new Node {Id = 5},
                    new Node {Id = 6},
                    new Node {Id = 7},
                    new Node {Id = 8}
                },
                Edges = new List<Edge>
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
                }
            };


            #endregion

            //граф с отрицательными весами ребёр
            #region Init graph2

            Graph graph2 = new Graph
            {
                Nodes = new List<Node>
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
                },
                Edges = new List<Edge>
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
                }
            };




            #endregion

            //граф с отрицательными весами ребёр
            #region Init graph3

            Graph graph3 = new Graph
            {
                Nodes = new List<Node>
                {
                    new Node {Id = 1},
                    new Node {Id = 2},
                    new Node {Id = 3},
                    new Node {Id = 4}
                },
                Edges = new List<Edge>
                {
                    new Edge
                    {
                        SourceNode = 1,
                        DestinationNode = 2,
                        Weight = 1
                    },
                    new Edge
                    {
                        SourceNode = 1,
                        DestinationNode = 4,
                        Weight = 99
                    },
                    new Edge
                    {
                        SourceNode = 1,
                        DestinationNode = 3,
                        Weight = 0
                    },
                    new Edge
                    {
                        SourceNode = 2,
                        DestinationNode = 3,
                        Weight = 1
                    },
                    new Edge
                    {
                        SourceNode = 4,
                        DestinationNode = 2,
                        Weight = -300
                    },
                }
            };



            #endregion

            //граф с отрицательными весами ребёр
            #region Init graph4
            Graph graph4 = new Graph();
            graph4.Nodes = new List<Node>
            {
                new Node {Id = 1},
                new Node {Id = 2},
                new Node {Id = 3},
                new Node {Id = 4},
                new Node {Id = 5}
            };
            graph4.Edges = new List<Edge>
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
                    Weight = 8
                },
                new Edge
                {
                    SourceNode = 1,
                    DestinationNode = 5,
                    Weight = -4
                },
                new Edge
                {
                    SourceNode = 2,
                    DestinationNode = 4,
                    Weight = 1
                },
                new Edge
                {
                    SourceNode = 2,
                    DestinationNode = 5,
                    Weight = 7
                },
                new Edge
                {
                    SourceNode = 3,
                    DestinationNode = 2,
                    Weight = 4
                },
                new Edge
                {
                    SourceNode = 4,
                    DestinationNode = 3,
                    Weight = -5
                },
                new Edge
                {
                    SourceNode = 4,
                    DestinationNode = 1,
                    Weight = 2
                },
                new Edge
                {
                    SourceNode = 5,
                    DestinationNode = 4,
                    Weight = 6
                },

            };

            #endregion

            //граф с отрицательным циклом
            #region Init graph5
            Graph graph5 = new Graph();
            graph5.Nodes = new List<Node>
            {
                new Node {Id = 1},
                new Node {Id = 2},
                new Node {Id = 3},
                new Node {Id = 4},
                new Node {Id = 5}
            };
            graph5.Edges = new List<Edge>
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
                    Weight = 8
                },
                new Edge
                {
                    SourceNode = 1,
                    DestinationNode = 5,
                    Weight = -4
                },
                new Edge
                {
                    SourceNode = 2,
                    DestinationNode = 4,
                    Weight = 1
                },
                new Edge
                {
                    SourceNode = 2,
                    DestinationNode = 5,
                    Weight = 7
                },
                new Edge
                {
                    SourceNode = 3,
                    DestinationNode = 2,
                    Weight = 4
                },
                new Edge
                {
                    SourceNode = 4,
                    DestinationNode = 3,
                    Weight = -5
                },
                new Edge
                {
                    SourceNode = 4,
                    DestinationNode = 1,
                    Weight = -22
                },
                new Edge
                {
                    SourceNode = 5,
                    DestinationNode = 4,
                    Weight = 6
                },

            };

            #endregion


            try
            {
                var shortestDistances = JohnsonAlgorithm.FindShortestPaths(graph5);

                Console.WriteLine("Кратчайшие пути:");
                for (var i = 0; i < shortestDistances.Length; i++)
                {
                    Console.WriteLine("Для вершины {0}:", i+1);
                    for (int j = 0; j < shortestDistances[i].Length; j++)
                    {
                        Console.WriteLine("\t - кратчайшее расстояние до вершины {0} равно {1}", j+1, shortestDistances[i][j]);
                    }
                }
                Console.WriteLine("Для выхода нажмите любую клавишу");
                Console.ReadKey();
            }
            catch (NegativeCycleException e)
            {
                _errorMessage = e.Message;
                Console.WriteLine(_errorMessage);
                Console.WriteLine("Для выхода нажмите любую клавишу");
                Console.ReadKey();
            }
        }
    }
}

