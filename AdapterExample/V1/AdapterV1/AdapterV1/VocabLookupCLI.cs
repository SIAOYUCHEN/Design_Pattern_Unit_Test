namespace AdapterV1;

public class VocabLookupCLI
{
    private readonly IVocabDictionary _dictionary;

    public VocabLookupCLI(IVocabDictionary dictionary)
    {
        _dictionary = dictionary;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("Lookup a word: ");
            string spelling = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(spelling))
            {
                try
                {
                    Word word = _dictionary.Lookup(spelling);
                    Console.WriteLine(word);
                }
                catch (WordNotExistsException e)
                {
                    Console.WriteLine($"Can't find the word '{spelling}'.");
                }
            }
        }
    }
}