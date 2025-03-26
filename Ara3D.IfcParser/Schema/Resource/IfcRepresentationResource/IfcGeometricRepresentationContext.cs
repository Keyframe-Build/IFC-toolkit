using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcGeometricRepresentationContext : IfcRepresentationContext
{
    public int? CoordinateSpaceDimension => (this[2] as StepInteger)?.Value;
    public double? Precision => (this[3] as StepNumber)?.Value;
    public IfcAxis2Placement WorldCoordinateSystem
    {
        get
        {
            var stepId = this[4] as StepId;
            return stepId != null ? Graph.GetNode(stepId) as IfcAxis2Placement : null;
        }
    }
    public IfcDirection? TrueNorth
    {
        get
        {
            var stepId = this[5] as StepId;
            return stepId != null ? Graph.GetNode(stepId) as IfcDirection : null;
        }
    }

    public IEnumerable<IfcCoordinateOperation> HasCoordinateOperation
    {
        get
        {
            if (Graph.CoordinateOperations.TryGetValue(Id, out var stepIds))
            {
                return stepIds
                    .Select(id => Graph.GetNode(id) as IfcCoordinateOperation)
                    .Where(op => op != null);
            }
            return Enumerable.Empty<IfcCoordinateOperation>();
        }
    }

    public IfcGeometricRepresentationContext(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
