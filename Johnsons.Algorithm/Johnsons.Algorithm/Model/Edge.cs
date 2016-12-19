namespace Johnson.Algorithm.Model
{
    public class Edge
    {
        public Edge(bool isDirection = false)
        {
            IsDirection = isDirection;
        }

        public int DestinationNode { get; set; }

        public int SourceNode { get; set; }

        public virtual bool IsDirection { get; private set; }

    }
}
