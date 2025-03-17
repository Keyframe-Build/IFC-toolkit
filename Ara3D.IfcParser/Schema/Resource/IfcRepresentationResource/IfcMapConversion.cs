using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcMapConversion : IfcCoordinateOperation
{
    public double? Eastings => (this[2] as StepNumber)?.Value;
    public double? Northings => (this[3] as StepNumber)?.Value;
    public double? OrthogonalHeight => (this[4] as StepNumber)?.Value;
    public double? XAxisAbscissa => (this[5] as StepNumber)?.Value;
    public double? XAxisOrdinate => (this[6] as StepNumber)?.Value;
    public double? Scale => (this[7] as StepNumber)?.Value;

    public IfcMapConversion(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
