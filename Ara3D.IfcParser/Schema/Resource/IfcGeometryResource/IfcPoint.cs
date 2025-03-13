using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcPoint : IfcNode
{
    public IfcPoint(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcCartesianPoint : IfcPoint
{
    public double? X
    {
        get
        {
            var point = this[0] as StepList;
            return (point.Values[0] as StepNumber).Value;
        }
    }

    public double? Y
    {
        get
        {
            var point = this[0] as StepList;
            return (point.Values[1] as StepNumber).Value;
        }
    }

    public double? Z
    {
        get
        {
            var point = this[0] as StepList;
            return (point.Values[2] as StepNumber).Value;
        }
    }

    public IfcCartesianPoint(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
