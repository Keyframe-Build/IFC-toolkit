using Ara3D.StepParser;

namespace Ara3D.IfcParser
{
    public class IfcNode : IfcEntity
    {
        public bool Published { get; set; } = false;

        public IfcNode(IfcGraph graph, StepInstance lineData)
            : base(graph, lineData)
        {
        }
    }
}