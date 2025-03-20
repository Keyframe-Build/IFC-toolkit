using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcPavement : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcPavement(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
