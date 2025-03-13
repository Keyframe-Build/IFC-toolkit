using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcPlacement : IfcNode
{
    public IfcPoint Location
    {
        get
        {
            var location = this[0] as StepId;
            return location == null ? null : Graph.GetNode(location) as IfcPoint;
        }
    }

    public IfcPlacement(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
