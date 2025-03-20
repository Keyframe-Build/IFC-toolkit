using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRampFlight : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcRampFlight(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
