using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcKerb : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcKerb(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
