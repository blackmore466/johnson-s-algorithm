using System.Collections.Generic;

namespace Johnson.Algorithm.Model
{
    public class Graph
    {
        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
        }

        public List<Node> Nodes { get; set; }

        public List<Edge> Edges { get; set; }
    }
}
