using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRailing : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcRailing(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
