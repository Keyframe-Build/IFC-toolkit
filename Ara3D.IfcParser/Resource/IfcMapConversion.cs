using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcMapConversion : IfcCoordinateOperation
{
  public double? Eastings => (this[2] as StepNumber)?.Value;
  public double? Northings => (this[3] as StepNumber)?.Value;
  public double? OrthogonalHeight => (this[4] as StepNumber)?.Value;
  public double? XAxisAbscissa => (this[5] as StepNumber)?.Value;
  public double? XAxisOrdinate => (this[6] as StepNumber)?.Value;
  public double? Scale => (this[7] as StepNumber)?.Value;

  public IfcMapConversion(IfcGraph graph, StepInstance lineData)
    : base(graph, lineData)
  {
    if (SourceCRS is not null)
    {
      // Add this map conversion as a child of the geometric representation context
      graph.AddRelation(new IfcRelation(graph, lineData, SourceCRS, new StepList(new StepId(Id).AsList())));
    }
    if (TargetCRS is not null)
    {
      // Add this map conversion as a child of the geometric representation context
      graph.AddRelation(new IfcRelation(graph, lineData, new StepId(Id), new StepList(TargetCRS.AsList())));
    }
  }
}
