using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcChimney : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcChimney(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
