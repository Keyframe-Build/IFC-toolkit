using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRelDefinesByType : IfcRelationship
{
    public StepList RelatedObjects => this[4] as StepList;
    public StepId RelatingType => this[5] as StepId;

    public IfcRelDefinesByType(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData)
    {
        // Add the relationship to the graph
        graph.AddRelation(this);
    }

    // Implement the From property
    public override StepId From => RelatingType;

    // Implement the To property
    public override StepList To => RelatedObjects;
}
