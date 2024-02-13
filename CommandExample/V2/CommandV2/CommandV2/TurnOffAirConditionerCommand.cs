using CommandV1;

namespace CommandV2;

public class TurnOffAirConditionerCommand : ICommand
{
    private readonly AirConditioner _ac;

    public TurnOffAirConditionerCommand(AirConditioner ac)
    {
        _ac = ac;
    }

    public void Execute()
    {
        _ac.TurnOff();
    }
}