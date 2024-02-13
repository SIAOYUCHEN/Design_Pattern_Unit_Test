using CommandV1;

namespace CommandV3;

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

    public void Undo()
    {
        _ac.TurnOn();
    }
}