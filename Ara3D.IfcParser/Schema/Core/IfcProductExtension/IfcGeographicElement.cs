using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcGeographicElement : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcGeographicElement(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
