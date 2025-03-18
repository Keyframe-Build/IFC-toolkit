using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRelDefinesByType : IfcNode
{
    public StepList RelatedObjects => this[4] as StepList;
    public StepId RelatingType => this[5] as StepId;

    public IfcRelDefinesByType(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData)
    {
        // Add the relationship to the graph
        graph.AddRelation(new IfcRelationType(graph, lineData, RelatingType, RelatedObjects));
    }
}
