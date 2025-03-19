using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRelAggregates : IfcRelationship
{
    public StepId RelatingObject => this[4] as StepId;
    public StepList RelatedObjects => this[5] as StepList;

    public IfcRelAggregates(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData)
    {
        // Add the relationship to the graph
        graph.AddRelation(this);
    }

    // Implement the From property
    public override StepId From => RelatingObject;

    // Implement the To property
    public override StepList To => RelatedObjects;
}
