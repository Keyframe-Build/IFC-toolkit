using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcSlab : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcSlab(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
