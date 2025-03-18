using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcPropertyDefinition : IfcNode
{
    public IfcPropertyDefinition(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcPropertySetDefinition : IfcPropertyDefinition
{
    public IfcPropertySetDefinition(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcPropertySet : IfcPropertySetDefinition
{
    public IfcPropertySet(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcQuantitySet : IfcPropertySetDefinition
{
    public IfcQuantitySet(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
