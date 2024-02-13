using CommandV1;

namespace CommandV3;

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

    public void Undo()
    {
        _tv.TurnOff();
    }
}