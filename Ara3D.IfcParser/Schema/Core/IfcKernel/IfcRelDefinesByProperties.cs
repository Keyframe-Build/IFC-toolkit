using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRelDefinesByProperties : IfcRelationship
{
    public IEnumerable<IfcObjectDefinition> RelatedObjects
    {
        get
        {
            var list = this[4] as StepList;
            return list?.Values?.OfType<StepId>()
                    .Select(x => Graph.GetNode(x.Id))
                    .OfType<IfcObjectDefinition>() ?? Enumerable.Empty<IfcObjectDefinition>();
        }
    }
    public IfcPropertySetDefinition RelatingPropertyDefinition
    {
        get
        {
            var propertySetDefinition = this[5] as StepId;
            return propertySetDefinition == null
                ? null
                : Graph.GetNode(propertySetDefinition) as IfcPropertySetDefinition;
        }
    }

    public IfcRelDefinesByProperties(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData)
    {
        // Add the relationship to the graph
        graph.AddRelation(this);
    }

    // Implement the From property
    public override StepId From => this[5] as StepId;

    // Implement the To property
    public override StepList? To => this[4] as StepList;
}
