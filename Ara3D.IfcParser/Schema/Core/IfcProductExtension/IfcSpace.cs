using System;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcSpace : IfcSpatialStructureElement
{
    public StepSymbol? PredefinedType => this[9] as StepSymbol;
    public double? ElevationWithFlooring => (this[10] as StepNumber)?.Value;

    public IfcSpace(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
