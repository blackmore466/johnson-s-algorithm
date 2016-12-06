using System.Collections.Generic;
using System.Linq;

namespace Johnson.Algorithm.Model
{
    /// <summary>
    /// Очередь обработки вершин графа
    /// </summary>
    public class PriorityQueue
    {
        private static int _count;
        private List<NodeWithPriority> _nodes;

        public PriorityQueue()
        {
            _count = 0;
            _nodes = new List<NodeWithPriority>();
        }

        public bool IsEmpty
        {
            get { return _count == 0; }
        }

        public int Size
        {
            get { return _count; }
        }

        public void AddNode(Node node, int priority)
        {
            _nodes.Add(new NodeWithPriority(node, priority));
            ++_count;
        }

        public Node ExtractNode(int priority)
        {
            var currentNode = _nodes.FirstOrDefault(f => f.Priority == priority);
            _count--;
            _nodes.Remove(currentNode);
            return currentNode.Node;   
        }

        public void ChangePriority(int nodeId, int newPriority)
        {
            var node = _nodes.First(f => f.Node.Id == nodeId);
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
