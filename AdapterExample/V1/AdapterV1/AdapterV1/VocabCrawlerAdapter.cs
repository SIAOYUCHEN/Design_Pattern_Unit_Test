namespace AdapterV1;

public class VocabCrawlerAdapter : IVocabDictionary
{
    private readonly SuperVocabCrawler _superVocabCrawler = new SuperVocabCrawler();

    public Word Lookup(string wordSpelling)
    {
        try
        {
            SuperWord superWord = _superVocabCrawler.Crawl(wordSpelling).Result; // Assuming Crawl is an async method
            return ConvertToWord(superWord);
        }
        catch (YouSpellItWrongException e)
        {
            throw new WordNotExistsException(wordSpelling, e);
        }
    }

    private Word ConvertToWord(SuperWord superWord)
    {
        string spelling = superWord.Raw;
        var definitions = new Dictionary<Word.PartOfSpeech, List<string>>();

        foreach (var definitionLine in superWord.Definitions)
        {
            var splits = definitionLine.Split(new[] { ' ' }, 2);
            var partOfSpeech = ConvertPartOfSpeech(splits[0]);
            var definition = splits.Length > 1 ? splits[1] : "";
            if (!definitions.ContainsKey(partOfSpeech))
            {
                definitions[partOfSpeech] = new List<string>();
            }
            definitions[partOfSpeech].Add(definition);
        }

        return new Word(spelling, definitions);
    }

    private Word.PartOfSpeech ConvertPartOfSpeech(string partOfSpeech)
    {
        return partOfSpeech.ToLower() switch
        {
            "noun" => Word.PartOfSpeech.Noun,
            "verb" => Word.PartOfSpeech.Verb,
            "adverb" => Word.PartOfSpeech.Adv,
            "adjective" => Word.PartOfSpeech.Adj,
            "article" => Word.PartOfSpeech.Article,
            "preposition" => Word.PartOfSpeech.Preposition,
            "conjunction" => Word.PartOfSpeech.Conjunction,
            "interjection" => Word.PartOfSpeech.Interjection,
            _ => throw new ArgumentException($"Unsupported partOfSpeech '{partOfSpeech}'.")
        };
    }
}