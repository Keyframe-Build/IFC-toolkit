using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcBuildingElementPart : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcBuildingElementPart(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
