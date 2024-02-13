using CommandV1;

namespace CommandV3;

public class FanNextLevelCommand : ICommand
{
    private readonly Fan _fan;

    public FanNextLevelCommand(Fan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.NextLevel();
    }

    public void Undo()
    {
        _fan.PreviousLevel();
    }
}