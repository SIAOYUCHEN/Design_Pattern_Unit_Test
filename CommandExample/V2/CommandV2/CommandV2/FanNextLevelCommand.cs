using CommandV1;

namespace CommandV2;

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
}