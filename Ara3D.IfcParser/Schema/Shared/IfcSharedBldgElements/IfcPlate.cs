using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcPlate : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcPlate(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
