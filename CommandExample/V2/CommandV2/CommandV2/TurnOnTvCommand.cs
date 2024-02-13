using CommandV1;

namespace CommandV2;

public class TurnOnTvCommand : ICommand
{
    private readonly Television _tv;

    public TurnOnTvCommand(Television tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.TurnOn();
    }
}