namespace AdapterV1;

public class SuperWord
{
    public string Raw { get; }
    public List<string> Definitions { get; }

    public SuperWord(string raw, List<string> definitions)
    {
        Raw = raw;
        Definitions = definitions;
    }
}