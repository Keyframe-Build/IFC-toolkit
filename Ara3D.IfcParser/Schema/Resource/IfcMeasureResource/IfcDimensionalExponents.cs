using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcDimensionalExponents : IfcNode
{
    int LengthExponent => (this[0] as StepInteger).Value;
    int MassExponent => (this[1] as StepInteger).Value;
    int TimeExponent => (this[2] as StepInteger).Value;
    int ElectricCurrentExponent => (this[3] as StepInteger).Value;
    int ThermodynamicTemperatureExponent => (this[4] as StepInteger).Value;
    int AmountOfSubstanceExponent => (this[5] as StepInteger).Value;
    int LuminousIntensityExponent => (this[6] as StepInteger).Value;

    public IfcDimensionalExponents(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
