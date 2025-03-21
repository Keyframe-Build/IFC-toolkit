using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcFooting : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcFooting(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
