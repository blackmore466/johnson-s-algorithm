using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Johnsons.Algorithm
{
    public class PriorityQueue
    {
        private static int Count = 0;
        private List<NodeWithPriority> Nodes;

        public PriorityQueue()
        {
            Nodes = new List<NodeWithPriority>();
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public int Size
        {
            get { return Count; }
        }

        public void AddNode(Node node, int priority)
        {
            Nodes.Add(new NodeWithPriority(node, priority));
            ++Count;
        }

        public Node ExtractNode(int priority)
        {
            var currentNode = Nodes.FirstOrDefault(f => f.Priority == priority);
            Count--;
            Nodes.Remove(currentNode);
            return currentNode.Node;   
        }

        public void ChangePriority(int nodeId, int newPriority)
        {
            var node = Nodes.First(f => f.Node.Id == nodeId);
            node.Priority = newPriority;
        }
    }

    /// <summary>
    /// класс-обертка, инкапсулирующий в себе вершину графа с её номером
    /// в очереди
    /// </summary>
    class NodeWithPriority
    {
        public Node Node;
        public int Priority { get; set; }

        public NodeWithPriority(Node node, int priority)
        {
            Node = node;
            Priority = priority;
        }
    }
}
