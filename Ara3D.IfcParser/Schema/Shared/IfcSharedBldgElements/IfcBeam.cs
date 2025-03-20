using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcBeam : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcBeam(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
