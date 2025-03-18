using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRelContainedInSpatialStructure : IfcNode
{
    public StepList RelatedElements => this[4] as StepList;
    public StepId RelatingStructure => this[5] as StepId;

    public IfcRelContainedInSpatialStructure(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData)
    {
        // Add the spatial relationship to the graph
        graph.AddRelation(
            new IfcRelationSpatial(graph, lineData, RelatingStructure, RelatedElements)
        );
    }
}
