using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcDoor : IfcElement
{
    public double? OverallHeight => (this[8] as StepNumber)?.Value;
    public double? OverallWidth => (this[9] as StepNumber)?.Value;
    public StepSymbol? PredefinedType => this[10] as StepSymbol;
    public StepSymbol? OperationType => this[11] as StepSymbol;
    public string? UserDefinedOperationType => (this[12] as StepString)?.Value.ToString();

    public IfcDoor(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
