namespace CommandV3;

public interface ICommand
{
    public void Execute();
    public void Undo();
}