using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcPropertyAbstraction : IfcNode
{
    public IfcPropertyAbstraction(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcProperty : IfcPropertyAbstraction
{
    public new string Name => (this[0] as StepString).Value.ToString();
    public string? Specification => (this[1] as StepString)?.Value.ToString();

    public IfcProperty(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcExtendedProperties : IfcPropertyAbstraction
{
    public new string? Name => (this[0] as StepString)?.Value.ToString();
    public new string? Description => (this[1] as StepString)?.Value.ToString();
    public IEnumerable<IfcProperty> Properties
    {
        get
        {
            var properties = this[2] as StepList;
            return properties
                    ?.Values?.OfType<StepId>()
                    .Select(x => Graph.GetNode(x.Id))
                    .OfType<IfcProperty>() ?? Enumerable.Empty<IfcProperty>();
        }
    }

    public IfcExtendedProperties(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcPropertySingleValue : IfcProperty
{
    // IFCPROPERTYSINGLEVALUE('Cutout',$,IFCLABEL('Flange_notch'),$);
    public string? NominalValue => (this[2] as StepString)?.Value.ToString();
    public string? Unit => (this[3] as StepString)?.Value.ToString();

    public IfcPropertySingleValue(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
