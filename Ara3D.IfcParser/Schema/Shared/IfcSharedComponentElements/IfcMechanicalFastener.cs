using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcMechanicalFastener : IfcElement
{
    public double? NominalDiameter => (this[8] as StepNumber)?.Value;
    public double? NominalLength => (this[9] as StepNumber)?.Value;
    public StepSymbol? PredefinedType => this[10] as StepSymbol;

    public IfcMechanicalFastener(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
