using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcFastener : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcFastener(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
