using System;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcRailway : IfcSpatialStructureElement
{
    public StepSymbol? PredefinedType => this[9] as StepSymbol;

    public IfcRailway(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
