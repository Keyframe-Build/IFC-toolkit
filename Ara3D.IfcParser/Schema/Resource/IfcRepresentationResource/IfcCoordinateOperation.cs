using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcCoordinateOperation : IfcNode
{
    public StepId? SourceCRS => this[0] as StepId;
    public IfcCoordinateReferenceSystem TargetCRS
    {
        get
        {
            var targetCRS = this[1] as StepId;
            return targetCRS == null ? null : Graph[targetCRS] as IfcCoordinateReferenceSystem;
        }
    }

    public IfcCoordinateOperation(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
