using Ara3D.StepParser;

namespace Ara3D.IfcParser;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1501")]
public class IfcSite : IfcSpatialStructureElement
{
  public string? RefLatitude => (this[9] as StepList)?.ToPlaneAngle();
  public string? RefLongitude => (this[10] as StepList)?.ToPlaneAngle();
  public double? RefElevation => (this[11] as StepNumber)?.Value;
  public string? LandTitleNumber => (this[12] as StepString)?.Value.ToString();
  public StepId? SiteAddress => this[13] as StepId;

  public IfcSite(IfcGraph graph, StepInstance lineData)
    : base(graph, lineData)
  {
  }
}