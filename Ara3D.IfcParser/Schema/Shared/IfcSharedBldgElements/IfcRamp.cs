using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRamp : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcRamp(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
