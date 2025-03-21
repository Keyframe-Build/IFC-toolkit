using System;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcMarineFacility : IfcSpatialStructureElement
{
    public StepSymbol? PredefinedType => this[9] as StepSymbol;

    public IfcMarineFacility(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
