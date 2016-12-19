using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Johnson.Algorithm.Model
{
    public class OrientedAndWeightedEdge : Edge
    {
        public override bool IsDirection
        {
            get { return true; }
        }

        public int Weight { get; set; }
    }
}
