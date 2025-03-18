using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRelDefinesByProperties : IfcNode
{
    public StepList? RelatedObjects => this[4] as StepList;
    public StepId RelatingPropertyDefinition => this[5] as StepId;

    public IfcRelDefinesByProperties(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData)
    {
        // Add the relationship to the graph
        graph.AddRelation(
            new IfcPropSetRelation(graph, lineData, RelatingPropertyDefinition, RelatedObjects)
        );
    }
}
