using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcGeometricRepresentationContext : IfcRepresentationContext
{
  public int? CoordinateSpaceDimension => (this[2] as StepInteger)?.Value;
  public double? Precision => (this[3] as StepNumber)?.Value;
  public StepId? WorldCoordinateSystem => this[4] as StepId;
  public StepId? TrueNorth => this[5] as StepId;

  public IfcGeometricRepresentationContext(IfcGraph graph, StepInstance lineData)
    : base(graph, lineData)
  {
  }
}