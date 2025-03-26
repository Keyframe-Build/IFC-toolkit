using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcCompoundPlaneAngleMeasure
{
    public int Degrees;
    public int Minutes;
    public int Seconds;
    public int? MillionthSeconds;

    public IfcCompoundPlaneAngleMeasure(StepList list)
    {
        Degrees = (list.Values[0] as StepInteger).Value;
        Minutes = (list.Values[1] as StepInteger).Value;
        Seconds = (list.Values[2] as StepInteger).Value;
        MillionthSeconds = (list.Values[3] as StepInteger)?.Value;
    }

    public override string ToString()
    {
        return MillionthSeconds is null
            ? $"{Degrees}° {Minutes}' {Seconds}\""
            : $"{Degrees}° {Minutes}' {Seconds}\" {MillionthSeconds}";
    }
}
