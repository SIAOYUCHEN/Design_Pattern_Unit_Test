namespace CommandV3;

public class Controller
{
    private readonly ICommand[] commands = new ICommand[6];
    private readonly Stack<ICommand> s1 = new Stack<ICommand>();
    private readonly Stack<ICommand> s2 = new Stack<ICommand>();

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
            ICommand command = commands[button];
            command.Execute();
            s1.Push(command);
            s2.Clear();
        }
        else
        {
            throw new ArgumentException($"Button {button} unsupported or not set.", nameof(button));
        }
    }

    public void Undo()
    {
        if (s1.Count > 0)
        {
            ICommand previousCommand = s1.Pop();
            previousCommand.Undo();
            s2.Push(previousCommand);
        }
    }

    public void Redo()
    {
        if (s2.Count > 0)
        {
            ICommand nextCommand = s2.Pop();
            nextCommand.Execute();
            s1.Push(nextCommand);
        }
    }
}