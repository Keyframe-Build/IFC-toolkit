using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcMember : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcMember(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
