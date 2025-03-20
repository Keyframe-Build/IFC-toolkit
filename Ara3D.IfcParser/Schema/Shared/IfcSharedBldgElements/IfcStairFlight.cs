using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcStairFlight : IfcElement
{
    public int? NumberOfRisers => (this[8] as StepInteger)?.Value;
    public int? NumberOfTreads => (this[9] as StepInteger)?.Value;
    public double? RiserHeight => (this[10] as StepNumber)?.Value;
    public double? TreadLength => (this[11] as StepNumber)?.Value;
    public StepSymbol? PredefinedType => this[12] as StepSymbol;

    public IfcStairFlight(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
