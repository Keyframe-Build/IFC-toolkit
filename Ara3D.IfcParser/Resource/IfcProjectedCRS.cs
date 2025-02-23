using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcProjectedCRS : IfcCoordinateReferenceSystem
{
  public string? VerticalDatum => (this[3] as StepString)?.Value.ToString();
  public string? MapProjection => (this[4] as StepString)?.Value.ToString();
  public string? MapZone => (this[5] as StepString)?.Value.ToString();
  public StepId? MapUnit => this[6] as StepId;

  public IfcProjectedCRS(IfcGraph graph, StepInstance lineData)
    : base(graph, lineData)
  {
  }
}
