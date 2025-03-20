using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcCovering : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcCovering(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
