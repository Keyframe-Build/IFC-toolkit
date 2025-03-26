using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcPoint : IfcNode
{
    public IfcPoint(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
