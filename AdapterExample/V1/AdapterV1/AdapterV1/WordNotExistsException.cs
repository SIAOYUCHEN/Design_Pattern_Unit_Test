namespace AdapterV1;

public class WordNotExistsException : Exception
{
    public string WordSpelling { get; }

    public WordNotExistsException(string wordSpelling)
        : base($"Word not found: {wordSpelling}")
    {
        WordSpelling = wordSpelling;
    }

    public WordNotExistsException(string wordSpelling, Exception innerException)
        : base($"Word not found: {wordSpelling}", innerException)
    {
        WordSpelling = wordSpelling;
    }
}