using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcNamedUnit : IfcNode
{
    public IfcDimensionalExponents? Dimensions
    {
        get
        {
            var dimensions = this[0] as StepId;
            return dimensions == null ? null : Graph.GetNode(dimensions) as IfcDimensionalExponents;
        }
    }
    public StepSymbol UnitType => this[1] as StepSymbol;

    public IfcNamedUnit(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcSIUnit : IfcNamedUnit
{
    public StepSymbol? Prefix => this[2] as StepSymbol;
    public StepSymbol Name => this[3] as StepSymbol;

    public IfcSIUnit(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcContextDependentUnit : IfcNamedUnit
{
    public new string? Name => (this[2] as StepString)?.Value.ToString();

    public IfcContextDependentUnit(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcConversionBasedUnit : IfcNamedUnit
{
    public new string? Name => (this[2] as StepString)?.Value.ToString();
    public StepId ConversionFactor => this[3] as StepId;

    public IfcConversionBasedUnit(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
