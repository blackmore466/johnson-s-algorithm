using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Johnson_s_Algorithm
{
    public class PriorityQueue
    {
        private static int Count = 0;
        private List<NodeWithPriority> Nodes;

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public int Size
        {
            get { return Count; }
        }

        public void AddNode(Node node)
        {
            Nodes.Add(new NodeWithPriority(node, ++Count));
        }

        public Node ExtractNode()
        {
            var currentNode = Nodes.FirstOrDefault(f => f.Priority == Count);
            Count--;
            return currentNode.Node;
        }
    }

    /// <summary>
    /// класс-обертка, инкапсулирующий в себе вершину графа с её номером
    /// в очереди
    /// </summary>
    class NodeWithPriority
    {
        public Node Node;
        public int Priority;

        public NodeWithPriority(Node node, int priority)
        {
            Node = node;
            Priority = priority;
        }
    }
}
