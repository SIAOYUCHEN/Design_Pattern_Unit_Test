namespace CommandV1;

public class Fan
{
    private int _level; // {0, 1, 2, 3}

    public int GetLevel() => _level;

    public void NextLevel()
    {
        _level = (_level + 1) % 4;
        Console.WriteLine($"【 Fan 】Level -> {_level}");
    }

    public void PreviousLevel()
    {
        _level = _level - 1 == -1 ? 3 : _level - 1;
        Console.WriteLine($"【 Fan 】Level -> {_level}");
    }
}