using CommandV1;

namespace CommandV2;

public class FanPreviousLevelCommand : ICommand
{
    private readonly Fan _fan;

    public FanPreviousLevelCommand(Fan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.PreviousLevel();
    }
}