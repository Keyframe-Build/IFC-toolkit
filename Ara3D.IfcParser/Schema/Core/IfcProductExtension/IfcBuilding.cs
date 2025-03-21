using System;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcBuilding : IfcSpatialStructureElement
{
    [Obsolete("This attribute is deprecated and shall no longer be used")]
    public double? ElevationOfRefHeight => (this[9] as StepNumber)?.Value;

    [Obsolete("This attribute is deprecated and shall no longer be used")]
    public double? ElevationOfTerrain => (this[10] as StepNumber)?.Value;

    [Obsolete("This attribute is deprecated and shall no longer be used")]
    public StepId? PostalAddress => this[11] as StepId;

    public IfcBuilding(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
