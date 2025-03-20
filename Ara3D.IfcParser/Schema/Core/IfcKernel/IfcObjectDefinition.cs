using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public abstract class IfcObjectDefinition : IfcNode
{
    public IfcObjectDefinition(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
