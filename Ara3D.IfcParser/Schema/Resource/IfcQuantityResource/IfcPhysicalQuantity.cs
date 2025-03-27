using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public abstract class IfcPhysicalQuantity : IfcNode
{
    public new string Name => (this[0] as StepString).Value.ToString();
    public new string? Description => (this[1] as StepString)?.Value.ToString();

    public IfcPhysicalQuantity(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public abstract class IfcPhysicalSimpleQuantity : IfcPhysicalQuantity
{
    public string? Unit => (this[2] as StepString)?.Value.ToString();

    public IfcPhysicalSimpleQuantity(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcQuantityArea : IfcPhysicalSimpleQuantity
{
    public double AreaValue => (this[3] as StepNumber).Value;
    public string? Formula => (this[3] as StepString)?.Value.ToString();

    public IfcQuantityArea(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcQuantityCount : IfcPhysicalSimpleQuantity
{
    public int CountValue => (this[3] as StepNumber).IntValue;
    public string? Formula => (this[3] as StepString)?.Value.ToString();

    public IfcQuantityCount(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcQuantityLength : IfcPhysicalSimpleQuantity
{
    public double LengthValue => (this[3] as StepNumber).Value;
    public string? Formula => (this[3] as StepString)?.Value.ToString();

    public IfcQuantityLength(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcQuantityNumber : IfcPhysicalSimpleQuantity
{
    public double NumberValue => (this[3] as StepNumber).Value;
    public string? Formula => (this[3] as StepString)?.Value.ToString();

    public IfcQuantityNumber(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcQuantityTime : IfcPhysicalSimpleQuantity
{
    public double TimeValue => (this[3] as StepNumber).Value;
    public string? Formula => (this[3] as StepString)?.Value.ToString();

    public IfcQuantityTime(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcQuantityVolume : IfcPhysicalSimpleQuantity
{
    public double VolumeValue => (this[3] as StepNumber).Value;
    public string? Formula => (this[3] as StepString)?.Value.ToString();

    public IfcQuantityVolume(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcQuantityWeight : IfcPhysicalSimpleQuantity
{
    public double WeightValue => (this[3] as StepNumber).Value;
    public string? Formula => (this[3] as StepString)?.Value.ToString();

    public IfcQuantityWeight(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcPhysicalComplexQuantity : IfcPhysicalQuantity
{
    public IEnumerable<IfcPhysicalQuantity> HasQuantities
    {
        get
        {
            return (this[3] as StepList)
                    ?.Values?.OfType<StepId>()
                    .Select(x => Graph.GetNode(x.Id))
                    .OfType<IfcPhysicalQuantity>() ?? Enumerable.Empty<IfcPhysicalQuantity>();
        }
    }
    public string Discrimination => (this[4] as StepString).Value.ToString();
    public string? Quality => (this[5] as StepString)?.Value.ToString();
    public string? Usage => (this[6] as StepString)?.Value.ToString();

    public IfcPhysicalComplexQuantity(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
