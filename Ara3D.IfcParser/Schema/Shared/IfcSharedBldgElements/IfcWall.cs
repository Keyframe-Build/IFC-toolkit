using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcWall : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcWall(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
