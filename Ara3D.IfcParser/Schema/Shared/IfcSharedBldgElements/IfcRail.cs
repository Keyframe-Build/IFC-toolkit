using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRail : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcRail(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
