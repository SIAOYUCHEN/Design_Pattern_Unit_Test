namespace CommandV1;

public class AirConditioner
{
    private bool _on;

    public bool IsOn() => _on;

    public void TurnOn()
    {
        _on = true;
        Console.WriteLine("【 AC 】Turned ON.");
    }

    public void TurnOff()
    {
        _on = false;
        Console.WriteLine("【 AC 】Turned OFF.");
    }
}