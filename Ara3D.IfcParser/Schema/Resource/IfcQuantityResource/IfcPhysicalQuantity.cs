using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcPhysicalQuantity : IfcNode
{
    public string Name => (this[0] as StepString).Value.ToString();
    public string? Description => (this[1] as StepString)?.Value.ToString();

    public IfcPhysicalQuantity(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcPhysicalSimpleQuantity : IfcPhysicalQuantity
{
    public string? Unit => (this[2] as StepString)?.Value.ToString();

    public IfcPhysicalSimpleQuantity(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcQuantityLength : IfcPhysicalSimpleQuantity
{
    public double LengthValue => (this[3] as StepNumber).Value;
    public string? Formula => (this[3] as StepString)?.Value.ToString();

    public IfcQuantityLength(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcQuantityArea : IfcPhysicalSimpleQuantity
{
    public double AreaValue => (this[3] as StepNumber).Value;
    public string? Formula => (this[3] as StepString)?.Value.ToString();

    public IfcQuantityArea(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
