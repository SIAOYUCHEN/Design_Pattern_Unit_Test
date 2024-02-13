namespace CommandV2;

public class Controller
{
    private readonly ICommand[] commands = new ICommand[6];

    public void SetCommand(int button, ICommand command)
    {
        if (button >= 0 && button < commands.Length)
        {
            commands[button] = command;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(button), "Button index is out of range.");
        }
    }

    public void Press(int button)
    {
        if (button >= 0 && button < commands.Length && commands[button] != null)
        {
            commands[button].Execute();
        }
        else
        {
            throw new ArgumentException($"Button {button} unsupported or not set.");
        }
    }
}