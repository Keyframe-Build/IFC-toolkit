using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRepresentationContext : IfcNode
{
    public string? ContextIdentifier => (this[0] as StepString)?.Value.ToString();
    public string? ContextType => (this[1] as StepString)?.Value.ToString();

    public IfcRepresentationContext(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
