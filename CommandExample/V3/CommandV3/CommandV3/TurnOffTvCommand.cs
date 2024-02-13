using CommandV1;

namespace CommandV3;

public class TurnOffTvCommand : ICommand
{
    private readonly Television _tv;

    public TurnOffTvCommand(Television tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.TurnOff();
    }

    public void Undo()
    {
        _tv.TurnOn();
    }
}