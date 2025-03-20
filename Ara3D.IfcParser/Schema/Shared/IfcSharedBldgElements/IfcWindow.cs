using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcWindow : IfcElement
{
    public double? OverallHeight => (this[8] as StepNumber)?.Value;
    public double? OverallWidth => (this[9] as StepNumber)?.Value;
    public StepSymbol? PredefinedType => this[10] as StepSymbol;
    public StepSymbol? PartitioningType => this[11] as StepSymbol;
    public string? UserDefinedPartitioningType => (this[12] as StepString)?.Value.ToString();

    public IfcWindow(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
