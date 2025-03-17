using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcAxis2Placement : IfcPlacement
{
    public IfcAxis2Placement(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcAxis2Placement2D : IfcAxis2Placement
{
    public StepId? P => this[0] as StepId;
    public StepId? Dir => this[1] as StepId;

    public IfcAxis2Placement2D(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcAxis2Placement3D : IfcAxis2Placement
{
    public StepId? Location => this[0] as StepId;
    public StepId? Axis => this[1] as StepId;
    public StepId? RefDirection => this[2] as StepId;

    public IfcAxis2Placement3D(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
