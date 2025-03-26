using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public abstract class IfcCoordinateOperation : IfcNode
{
    public IfcNode SourceCRS
    {
        get
        {
            if (this[0] is StepId sourceCRS)
            {
                var node = Graph.GetNode(sourceCRS);
                return node switch
                {
                    IfcGeographicCRS geographicCRS => geographicCRS,
                    IfcProjectedCRS projectedCRS => projectedCRS,
                    IfcGeometricRepresentationContext context => context,
                    _ => null,
                };
            }
            return null;
        }
    }
    public IfcCoordinateReferenceSystem TargetCRS
    {
        get
        {
            if (this[1] is StepId targetCRS)
            {
                return Graph.GetNode(targetCRS) as IfcCoordinateReferenceSystem;
            }
            return null;
        }
    }

    public IfcCoordinateOperation(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
