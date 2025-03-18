using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRelAggregates : IfcNode
{
    public StepId RelatingObject => this[4] as StepId;
    public StepList RelatedObjects => this[5] as StepList;

    public IfcRelAggregates(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData)
    {
        // Add the relationship to the graph
        graph.AddRelation(
            new IfcRelationAggregate(graph, lineData, RelatingObject, RelatedObjects)
        );
    }
}
