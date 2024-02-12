namespace CommandV1;

public class Television
{
    private bool _on;

    public bool IsOn() => _on;

    public void TurnOn()
    {
        _on = true;
        Console.WriteLine("【 TV 】Turned ON.");
    }

    public void TurnOff()
    {
        _on = false;
        Console.WriteLine("【 TV 】Turned OFF.");
    }
}