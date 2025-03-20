using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcTrackElement : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcTrackElement(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
