using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcAxis2Placement : IfcPlacement
{
    public IfcAxis2Placement(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcAxis2Placement2D : IfcAxis2Placement
{
    public IfcDirection? RefDirection
    {
        get
        {
            var direction = this[1] as StepId;
            return direction == null ? null : Graph.GetNode(direction) as IfcDirection;
        }
    }

    public IfcAxis2Placement2D(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcAxis2Placement3D : IfcAxis2Placement
{
    public IfcDirection? Axis
    {
        get
        {
            var direction = this[1] as StepId;
            return direction == null ? null : Graph.GetNode(direction) as IfcDirection;
        }
    }
    public IfcDirection? RefDirection
    {
        get
        {
            var direction = this[2] as StepId;
            return direction == null ? null : Graph.GetNode(direction) as IfcDirection;
        }
    }

    public IfcAxis2Placement3D(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
