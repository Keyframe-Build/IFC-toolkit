using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcStair : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcStair(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
