using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRelContainedInSpatialStructure : IfcRelationship
{
    public StepList RelatedElements => this[4] as StepList;
    public StepId RelatingStructure => this[5] as StepId;

    public IfcRelContainedInSpatialStructure(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData)
    {
        // Add the spatial relationship to the graph
        graph.AddRelation(
            this
        //new IfcRelationSpatial(graph, lineData, RelatingStructure, RelatedElements)
        );
    }

    // Implement the From property
    public override StepId From => RelatingStructure;

    // Implement the To property
    public override StepList To => RelatedElements;
}
