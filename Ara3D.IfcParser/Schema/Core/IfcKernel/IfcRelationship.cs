using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public abstract class IfcRelationship : IfcNode
{
    public abstract StepId? From { get; }
    public abstract StepList To { get; }

    public IfcRelationship(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }

    public IEnumerable<uint> GetRelatedIds() => To.Values.Select(v => v.AsId());

    public IEnumerable<IfcNode> GetRelatedNodes() => Graph.GetNodes(GetRelatedIds());
}
