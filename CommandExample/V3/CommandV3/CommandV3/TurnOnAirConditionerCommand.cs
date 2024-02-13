using CommandV1;

namespace CommandV3;

public class TurnOnAirConditionerCommand : ICommand
{
    private readonly AirConditioner _ac;

    public TurnOnAirConditionerCommand(AirConditioner ac)
    {
        _ac = ac;
    }

    public void Execute()
    {
        _ac.TurnOn();
    }

    public void Undo()
    {
        _ac.TurnOff();
    }
}