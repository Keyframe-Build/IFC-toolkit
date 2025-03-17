using Ara3D.IfcParser;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcProjectedCRS : IfcCoordinateReferenceSystem
{
    public string? VerticalDatum => (this[3] as StepString)?.Value.ToString();
    public string? MapProjection => (this[4] as StepString)?.Value.ToString();
    public string? MapZone => (this[5] as StepString)?.Value.ToString();
    public IfcNamedUnit? MapUnit
    {
        get
        {
            var unit = this[6] as StepId;
            return unit == null ? null : Graph.GetNode(unit) as IfcNamedUnit;
        }
    }

    public IfcProjectedCRS(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
