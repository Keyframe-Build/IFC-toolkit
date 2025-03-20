using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRoof : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcRoof(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
