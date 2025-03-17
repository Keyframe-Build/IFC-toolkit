using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcGeometricRepresentationContext : IfcRepresentationContext
{
    public int? CoordinateSpaceDimension => (this[2] as StepInteger)?.Value;
    public double? Precision => (this[3] as StepNumber)?.Value;
    public IfcAxis2Placement WorldCoordinateSystem
    {
        get
        {
            var wcs = this[4] as StepId;
            return wcs == null ? null : Graph.GetNode(wcs) as IfcAxis2Placement;
        }
    }
    public IfcDirection? TrueNorth
    {
        get
        {
            var trueNorth = this[5] as StepId;
            return trueNorth == null ? null : Graph.GetNode(trueNorth) as IfcDirection;
        }
    }

    public IfcGeometricRepresentationContext(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
