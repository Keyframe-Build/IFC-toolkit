using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcBuildingElementProxy : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcBuildingElementProxy(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
